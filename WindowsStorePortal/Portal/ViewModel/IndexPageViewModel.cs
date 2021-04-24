using System.Collections.Generic;
using Store.Portal.Models;

namespace Store.Portal.ViewModel
{
    public class IndexPageViewModel
    {
        // برنامه های ویژه
        public IEnumerable<StoreApp> SpecialApps { get; set; }

        // برنامه های جدید
        public IEnumerable<StoreApp> NewApps { get; set; }

        // برنامه های پر طرفدار
        public IEnumerable<StoreApp> MostPopularApps { get; set; }

        // برنامه های برگزیده
        public IEnumerable<StoreApp> ChosenApps { get; set; }

        // برنامه های در حال پیشرفت
        public IEnumerable<StoreApp> RisingApps { get; set; }
        // بازی های ویژه
        public IEnumerable<StoreApp> SpecialGames { get; set; }


    }
}