using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.Admin.Common.ExtensionMethod;
using WindowsStore.Client.Admin.Common.Model;
using WindowsStore.Client.Admin.Common.Model.Security;
using WindowsStore.Client.Admin.RemoteService.Service;
using WindowsStore.Client.Admin.UI.Infrastructure.ModelLocalizer;
using WindowsStore.Client.Admin.UI.View.Interface;

namespace WindowsStore.Client.Admin.UI.ViewModel
{
    public class UserManagementPageViewModel
    {
        public IUserManagementPage View { get; set; }
        public ObservableCollection<Person> Users { get; set; }
        public ObservableCollection<NaturalPerson> NaturalUsers { get; set; }
        public ObservableCollection<LegalPerson> LegalUsers { get; set; }
        public NaturalPerson SelectedNaturalPerson { get; set; }
        public LegalPerson SelectedLegalPerson { get; set; }

        public UserManagementPageViewModel()
        {
            NaturalUsers = new ObservableCollection<NaturalPerson>();
            LegalUsers = new ObservableCollection<LegalPerson>();
        }

        public async Task LoadUsersAsync()
        {
            Users = new ObservableCollection<Person>(await UserManagementService.Instance.GetUsersAsync());
            Users.Where(user => user.IsNaturalPerson)
                .Select(user => user.NaturalPerson)
                .ForEach(naturalPerson =>
                {
                    naturalPerson.LocalizeProperties();
                    NaturalUsers.Add(naturalPerson);
                });
            Users.Where(user => !user.IsNaturalPerson)
                .Select(user => user.LegalPerson)
                .ForEach(legalPerson =>
                {
                    legalPerson.LocalizeProperties();
                    LegalUsers.Add(legalPerson);
                });
        }

        public async Task DeleteSelectedNaturalPerson()
        {
            await UserManagementService.Instance.DeletePersonAsync(SelectedNaturalPerson.GetPerson());
        }

        public async Task DeleteSelectedLegalPerson()
        {
            await UserManagementService.Instance.DeletePersonAsync(SelectedLegalPerson.GetPerson());
        }

    }
}
