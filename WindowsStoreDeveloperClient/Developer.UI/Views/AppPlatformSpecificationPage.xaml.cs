using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.Developer.Common.Enum;
using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsStore.Client.Developer.UI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppPlatformSpecificationPage : Page
    {
        public AppPlatformSpecificationPage()
        {
            this.InitializeComponent();

        
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            LoadPage();
        }
        private void LoadPage()
        {
            var context = (IAppPlatformSpecificationPageViewModel) this.DataContext;

            if (context.AppDetail.AppPlatformSpecification.CpuArchitectureFlags != null)
            {
                var cpuArchitectureFlags = context.AppDetail.AppPlatformSpecification.CpuArchitectureFlags.Value;

                Arm.IsChecked = cpuArchitectureFlags.HasFlag(CpuArchitecture.Arm);
                X64.IsChecked = cpuArchitectureFlags.HasFlag(CpuArchitecture.X64);
                X86.IsChecked = cpuArchitectureFlags.HasFlag(CpuArchitecture.X86);
            }

            var platformCategories = context.AppDetail.AppPlatformSpecification.PlatformCategories;
            foreach (var platformId in platformCategories)
            {
                var categoryName = Enum.Parse(typeof (PlatformCategory), platformId.ToString()).ToString();
                context.AddPlatformToDectionary(categoryName, platformId);

                ((CheckBox)FindName(categoryName)).IsChecked = true;
            }
       
        }

        private void CpuArchitectureCheckbox_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
          
            var checkbox = (CheckBox)sender;

            CpuArchitecture cpuArchitecture =  CpuArchitecture.None;

            switch (checkbox.Name)
            {
                case "Arm":
                    cpuArchitecture =  CpuArchitecture.Arm;
                    break;
                case "X64":
                    cpuArchitecture =  CpuArchitecture.X64;
                    break;
                case "X86":
                    cpuArchitecture = CpuArchitecture.X86;
                    break;
            }

            var viewModel = (IAppPlatformSpecificationPageViewModel)this.DataContext;

            if (checkbox.IsChecked.Value)
                viewModel.AddCpuArchitecture(cpuArchitecture);
            else
                viewModel.RemoveCpuArchitecture(cpuArchitecture);
        }

        private void PlatformCategoryCheckbox_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var checkbox = (CheckBox) sender;
            var platformCategory = (PlatformCategory) Enum.Parse(typeof (PlatformCategory), checkbox.Name);

            var viewModel = (IAppPlatformSpecificationPageViewModel) this.DataContext;

            if (checkbox.IsChecked.Value)
                viewModel.AddPlatformToDectionary(checkbox.Name, (int) platformCategory);
            else
                viewModel.RemovePlatformFromDictionary(checkbox.Name);
        }

        private void Windows10Universal_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Windows10Desktop.IsEnabled =
                Windows10Mobile.IsEnabled =
                    Windows10XBox.IsEnabled =
                        Windows10Iot.IsEnabled =
                            Windows10HoloLens.IsEnabled = false;
        }

        private void Windows10Universal_Unchecked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Windows10Desktop.IsEnabled =
                Windows10Mobile.IsEnabled =
                    Windows10XBox.IsEnabled =
                        Windows10Iot.IsEnabled =
                            Windows10HoloLens.IsEnabled = true;
        }
    }
}
