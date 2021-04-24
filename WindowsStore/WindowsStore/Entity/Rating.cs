using Store.Common.Enum;
using System;
using System.Collections.Generic;

namespace Store.DomainModel.Entity
{
    public sealed partial class Rating
    {
        public Rating()
        {
        }

        public int Id { get; set; }
        public int AppId { get; set; }
        public int PersonId { get; set; }
        public string Comment { get; set; }
        public byte Rate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Person Person { get; set; }
        public App App { get; set; }
    }
}
