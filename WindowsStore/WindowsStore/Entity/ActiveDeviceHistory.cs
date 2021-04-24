using Store.Common.Enum;
using System;
using System.Collections.Generic;

namespace Store.DomainModel.Entity
{
    public partial class ActiveDeviceHistory
    {
        public ActiveDeviceHistory()
        {

        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ActiveDeviceCount { get; set; }
    }
}
