using System.Threading.Tasks;
using WindowsStore.Client.Developer.Logic.Models;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;
using Prism.Windows.Mvvm;

namespace WindowsStore.Client.Developer.Logic.ViewModels
{
    public class LegalPersonUserControlViewModel : ViewModelBase, ILegalPersonUserControlViewModel
    {
        #region Constructor

        public LegalPersonUserControlViewModel(IClientDeveloperService developerService)
        {
            this.LegalPerson = new LegalPerson();
            _developerService = developerService;
        }
        #endregion

        #region Services

        private IClientDeveloperService _developerService;

        #endregion

        #region Fields


        #endregion

        #region Properties    

        public LegalPerson LegalPerson { get; }

        public string Password { get; set; }

        #endregion

        #region Methods

        public async Task ProcessFormAsync()
        {
            await _developerService.RegisterLegalPersonAsync(this.LegalPerson, Password);
        }

        public bool ValidateForm()
        {
            return this.LegalPerson.ValidateProperties();
        }
        #endregion

        #region Commands

        #endregion

        #region Actions

        #endregion
    }
}
