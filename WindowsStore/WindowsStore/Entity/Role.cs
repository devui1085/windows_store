using System.Collections.Generic;

namespace Store.DomainModel.Entity
{
    public partial class Role
    {
        public Role()
        {
            this.People = new List<Person>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Person> People { get; set; }

    }
}
