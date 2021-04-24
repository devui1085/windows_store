using System.Threading.Tasks;
using WindowsStore.Client.Developer.Logic.Models;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;
using Prism.Windows.Mvvm;

namespace WindowsStore.Client.Developer.Logic.ViewModels
{
    public class NaturalPersonUserControlViewModel : ViewModelBase, INaturalPersonUserControlViewModel
    {
        #region Constructor

        public NaturalPersonUserControlViewModel(IClientDeveloperService developerService)
        {
            this.NaturalPerson = new NaturalPerson();
            _developerService = developerService;
        }

        #endregion

        #region Services

        private readonly IClientDeveloperService _developerService;

        #endregion

        #region Fields
        private int? _naturalPersonId;

        #endregion

        #region Properties    

        public NaturalPerson NaturalPerson { get; }

        public string Password { get; set; }

        #endregion

        #region Methods
        /*
        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            if (viewModelState != null)
            {
                base.OnNavigatedTo(e, viewModelState);

                if (e.NavigationMode == NavigationMode.Refresh)
                {
                    //// Restores the error collection manually
                    var errorsCollection = RetrieveEntityStateValue<IDictionary<string, ReadOnlyCollection<string>>>("errorsCollection", viewModelState);

                    if (errorsCollection != null)
                    {
                        this.NaturalPerson.SetAllErrors(errorsCollection);
                    }
                    // elase set defaults
                }
            }

            if (e.NavigationMode == NavigationMode.New)
            {
                //if (int.TryParse(e.Parameter.ToString(), out _naturalPersonId.Value))
                //{
                //  //  NaturalPerson = await _developerService.GetNaturalPerson(_naturalPersonId);;
                // //   return;
                //}
            }

        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);

            // Store the errors collection manually
            if (viewModelState != null)
            {
                AddEntityStateValue("errorsCollection", this.NaturalPerson.GetAllErrors(), viewModelState);
            }
        }
        */
        public async Task ProcessFormAsync()
        {
            await _developerService.RegisterNaturalPersonAsync(NaturalPerson,Password);
        }

        public bool ValidateForm()
        {
            return this.NaturalPerson.ValidateProperties();
        }

        #endregion

        #region Commands

        #endregion

        #region Actions

        #endregion
    }
}
