using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.User.Common.Enum;
using WindowsStore.Client.User.Common.Infrastructure;

namespace WindowsStore.Client.User.Common.PresentationModel
{
    public class Person : BindableBase
    {
        public int Id { get; set; }
        public string PrimaryEmail { get; set; }

        // Membership Info
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsLockedOut { get; set; }
        public bool IsDeveloper { get; set; }
        public string DisplayName {
            get {
                return this is NaturalPerson ? (this as NaturalPerson).FullName : (this as LegalPerson).Name;
            }
        } 
    }
}
