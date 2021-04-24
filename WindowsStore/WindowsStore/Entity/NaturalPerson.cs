using Store.Common.Enum;
using System;

namespace Store.DomainModel.Entity
{
    public partial class NaturalPerson : Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Sexuality? Sexuality { get; set; }
        public Nullable<byte> Age { get; set; }
        public string NationalCode { get; set; }


        public string FullName
        {
            get
            {
                return string.Format($"{FirstName} {LastName}");
            }
        }
    }
}
