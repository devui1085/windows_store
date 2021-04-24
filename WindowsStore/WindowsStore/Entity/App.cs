using Store.Common.Enum;
using System;
using System.Collections.Generic;

namespace Store.DomainModel.Entity
{
    public partial class App
    {
        public App()
        {
            this.Screenshots = new List<Screenshot>();
            this.AppVersions = new List<AppVersion>();
            this.Platforms = new List<Platform>();
            this.Ratings = new List<Rating>();

            this.Name = this.Description = string.Empty;
            this.CpuArchitectureFlags = CpuArchitecture.None;
        }

        public int Id { get; set; }
        public Guid Guid  { get; set; }
        public int AppCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Icon128X128 { get; set; }
        public byte[] Icon256X256 { get; set; }
        public int DeveloperId { get; set; }
        public CpuArchitecture? CpuArchitectureFlags { get; set; }
        public AppState State { get; set; }
        public int Price { get; set; }
        public Person Developer { get; set; }
        public AppCategory AppCategory { get; set; }
        public FeaturedApp FeaturedApp { get; set; }

        public virtual ICollection<Screenshot> Screenshots { get; set; }
        public virtual ICollection<AppVersion> AppVersions { get; set; }
        public virtual ICollection<Platform> Platforms { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
