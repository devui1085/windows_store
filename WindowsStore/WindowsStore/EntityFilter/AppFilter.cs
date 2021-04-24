using Store.Common.Enum;
using Store.Common.Infrastructure;
using System;

namespace Store.DomainModel.EntityFilter
{
    public class AppFilter : FilterBase
    {
        public int? AppId { get; set; }
        public AppType? AppType { set; get; }
        public AppPricing? AppPricing { set; get; }
        public int? AppCategoryId { set; get; }
        public AppOrderMethod? AppOrderMethod { set; get; }
        public bool Include128X128Icon { get; set; }
        public bool Include256X256Icon { get; set; }
        public Guid? AppGuid { get; set; }
        public bool? FeaturedApp { get; set; }

    }
}
