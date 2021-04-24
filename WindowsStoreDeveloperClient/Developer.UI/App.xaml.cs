using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.ServiceModel;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsStore.Client.Developer.Common;
using WindowsStore.Client.Developer.Logic;
using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Logic.Models;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using WindowsStore.Client.Developer.Logic.Services;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;
using WindowsStore.Client.Developer.Logic.ViewModels;
using WindowsStore.Client.Developer.UI.Services;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;
using Prism.Unity.Windows;
using Prism.Windows.AppModel;
using Prism.Windows.Navigation;
using Constants = WindowsStore.Client.Developer.Logic.Constants;
using FaultCode = WindowsStore.Client.Developer.Logic.DeveloperService.FaultCode;

namespace WindowsStore.Client.Developer.UI
{
    /// <summary>
    /// This class uses the MvvmAppBase class to bootstrap this Windows Store App with Mvvm support
    /// http://go.microsoft.com/fwlink/?LinkID=288809&clcid=0x409
    /// </summary>
    public sealed partial class App : PrismUnityApplication
    {
        // Bootstrap: App singleton service declarations
        private TileUpdater _tileUpdater;

        public IEventAggregator EventAggregator { get; set; }

        // Documentation on navigation between pages is at http://go.microsoft.com/fwlink/?LinkID=288815&clcid=0x409
        protected override  Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            if (!string.IsNullOrEmpty(args?.Arguments))
            {
                // The app was launched from a Secondary Tile
                // Navigate to the item's page
                NavigationService.Navigate("SignIn", args.Arguments);
            }
            else
            {
                NavigationService.Navigate("Main", null);
            }

            // show navigation back button for application
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            Window.Current.Activate();
            return Task.FromResult<object>(null);
        }



        private Type Resolve(string name)
        {
            return Type.GetType(string.Format("{0}.Views.{1}Page", this.GetType().Namespace, name));
        }

        public void CreateNewNavigationFrame(Frame frame)
        {
           var nav = new FrameNavigationService(new FrameFacadeAdapter(frame), Resolve, this.SessionStateService);
           Container.RegisterInstance<INavigationService>(nav);
        }

        protected override void OnRegisterKnownTypesForSerialization()
        {
            SessionStateService.RegisterKnownType(typeof(UserInfo));
            SessionStateService.RegisterKnownType(typeof (User));
            SessionStateService.RegisterKnownType(typeof(Dictionary<string, Collection<string>>));
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            EventAggregator = new EventAggregator();

            Container.RegisterInstance<ISessionStateService>(SessionStateService);
            Container.RegisterInstance<IEventAggregator>(EventAggregator);
            Container.RegisterInstance<IResourceLoader>(new ResourceLoaderAdapter(new ResourceLoader()));
            Container.RegisterType<IAccountService, AccountService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IAppService, AppService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ICredentialStore, RoamingCredentialStore>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ICacheService, TemporaryFolderCacheService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ISecondaryTileService, SecondaryTileService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IAlertMessageService, AlertMessageService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IClientDeveloperService, DeveloperServiceProxy>(new ContainerControlledLifetimeManager());
            Container.RegisterType<INaturalPersonUserControlViewModel,NaturalPersonUserControlViewModel>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ILegalPersonUserControlViewModel, LegalPersonUserControlViewModel>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ICredentialUserControlViewModel, CredentialUserControlViewModel>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IVersionUserControlViewModel, VersionUserControlViewModel>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ISignInViewModel,SignInPageViewModel>(new ContainerControlledLifetimeManager());
            // Register repositories

            // Register web service proxies

            // Register child view models

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewModelTypeName = string.Format(CultureInfo.InvariantCulture, "WindowsStore.Client.Developer.Logic.ViewModels.{0}ViewModel, WindowsStore.Client.Developer.Logic, Version=1.0.0.0, Culture=neutral", viewType.Name);
                var viewModelType = Type.GetType(viewModelTypeName);
                if (viewModelType == null)
                {
                    viewModelTypeName = string.Format(CultureInfo.InvariantCulture, "WindowsStore.Client.Developer.Logic.ViewModels.{0}ViewModel, WindowsStore.Client.Developer.Logic, Version=1.0.0.0, Culture=neutral", viewType.Name);
                    viewModelType = Type.GetType(viewModelTypeName);
                }

                return viewModelType;
            });

            // Documentation on working with tiles can be found at http://go.microsoft.com/fwlink/?LinkID=288821&clcid=0x409
            _tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication();
            _tileUpdater.StartPeriodicUpdate(new Uri(Constants.DeveloperTileUpdaterUrl + "/api/TileNotification"), PeriodicUpdateRecurrence.HalfHour);
            var resourceLoader = Container.Resolve<IResourceLoader>();

            // subscribe App_UnhandledException
            //
            this.UnhandledException += App_UnhandledException;
            return base.OnInitializeAsync(args);
        }

        private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.Exception;

            var resourceLoader = (IResourceLoader) Container.Resolve(typeof (IResourceLoader));
            var navigationService = (INavigationService) Container.Resolve(typeof (INavigationService));
            var accountService = (IAccountService) Container.Resolve(typeof (IAccountService));

            if (ex is FaultException<GeneralInternalFault>)
            {
                var exception = ex as FaultException<GeneralInternalFault>;
                switch (exception.Detail.FaultCode)
                {
                    case FaultCode.InvalidVerificationCode:

                        break;
                    case FaultCode.VerificationCodeExpired:
                        break;
                    case FaultCode.Unauthorized:
                        ShowErrorMessage(resourceLoader.GetString("UnauthorizedMessage"),
                            resourceLoader.GetString("SystemError"));
                        navigationService.ClearHistory();
                        accountService.SignOut();
                        navigationService.Navigate(ViewNames.SignIn, null);
                        break;
                    case FaultCode.NotAuthenticated:

                        break;
                }
            }
            else if (ex is CommunicationException)
            {
                ShowErrorMessage(resourceLoader.GetString("NoInternetAccess"), resourceLoader.GetString("SystemError"));
            }
            else
            {
                ShowErrorMessage(resourceLoader.GetString("SystemErrorHappend"), resourceLoader.GetString("SystemError"));
            }

            e.Handled = true;
        }

        private void ShowErrorMessage(string errorMessage, string title)
        {
            IAlertMessageService alertMessageService = (IAlertMessageService) Container.Resolve(typeof (IAlertMessageService));

            alertMessageService.ShowAsync(errorMessage, title, DialogCommands.CloseDialogCommand);
        }
    }
}
