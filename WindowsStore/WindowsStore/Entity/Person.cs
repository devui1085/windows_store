using System.Collections.Generic;

namespace Store.DomainModel.Entity
{
    public partial class Person
    {
        public Person()
        {
            this.Apps = new List<App>();
            this.Contacts = new List<Contact>();
            this.Roles = new List<Role>();
            this.Ratings = new List<Rating>();
        }

        public int Id { get; set; }
        public string PrimaryEmail { get; set; }
        public virtual ICollection<App> Apps { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual Membership Membership { get; set; }
    }
}
