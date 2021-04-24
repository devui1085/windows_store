using Store.Common.Enum;
using System;
using System.Collections.Generic;

namespace Store.DomainModel.Entity
{
    public partial class FeaturedApp
    {
        public FeaturedApp()
        {
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public App App { get; set; }
    }
}
