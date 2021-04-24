using System;

namespace Store.Portal.Models
{
    public class StoreApp
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string PriceText => Price == 0 ? "رایگان" : $"{Price} {"تومان"}";
        public string Version { get; set; }
        public Guid Guid { get; set; }
    }
}