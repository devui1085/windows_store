using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.Admin.Common.Enum;

namespace WindowsStore.Client.Admin.Common.Model
{
    public class NaturalPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public byte? Age { get; set; }
        public string LastName { get; set; }
        public string PrimaryEmail { get; set; }
        public Sexuality Sexuality { get; set; }
        public string NationalCode { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsLockedOut { get; set; }
        public bool IsDeveloper { get; set; }

        // Localized Properties
        public string IsAdminText { get; set; }
        public string IsLockedOutText { get; set; }
        public string IsDeveloperText { get; set; }

        public Person GetPerson()
        {
            return new Person()
            {
                Id = this.Id,
                IsNaturalPerson = true,
                NaturalPerson = this
            };
        }
    }
}
