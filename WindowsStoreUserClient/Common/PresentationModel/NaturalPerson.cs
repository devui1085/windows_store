using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.User.Common.Enum;

namespace WindowsStore.Client.User.Common.PresentationModel
{
    public class NaturalPerson : Person
    {
        public string FirstName { get; set; }
        public byte? Age { get; set; }
        public string LastName { get; set; }
        public Sexuality Sexuality { get; set; }
        public string NationalCode { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
