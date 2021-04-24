using System;

namespace WindowsStore.Client.Admin.Common.Model
{
    public class StoreApp
    {
        public Guid Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AppCategory AppCategory { get; set; }
        public byte[] IconBytes { get; set; }

    }
}
