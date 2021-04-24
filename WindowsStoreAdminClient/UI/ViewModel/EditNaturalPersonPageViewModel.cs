using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.Admin.Common.Enum;
using WindowsStore.Client.Admin.Common.Model;
using WindowsStore.Client.Admin.Common.Model.Security;
using WindowsStore.Client.Admin.RemoteService.Service;
using WindowsStore.Client.Admin.UI.Infrastructure;
using WindowsStore.Client.Admin.UI.View.Interface;

namespace WindowsStore.Client.Admin.UI.ViewModel
{
    public class EditNaturalPersonPageViewModel
    {
        //public ILoginPage View { get; set; }
        public bool UpdateMode { get; set; }
        public NaturalPerson NaturalPerson { get; set; }
        public IEnumerable<EnumTextValuePair<Sexuality>> SexualityValues { get; set; }


        public EditNaturalPersonPageViewModel()
        {
            SexualityValues = EnumHelper.GetTextValuePairs<Sexuality>();
            NaturalPerson = new NaturalPerson();
            NaturalPerson.IsDeveloper = true;
        }

        public async Task CommitAsync()
        {
            if (UpdateMode)
                await UserManagementService.Instance.UpdateNaturalPersonAsync(NaturalPerson);
            else
                await UserManagementService.Instance.RegisterNaturalPersonAsync(NaturalPerson);
        }
    }
}
