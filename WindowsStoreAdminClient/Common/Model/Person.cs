using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.Admin.Common.Enum;

namespace WindowsStore.Client.Admin.Common.Model
{
    public class Person
    {
        public int Id { get; set; }
        public bool IsNaturalPerson { get; set; }
        public NaturalPerson NaturalPerson { get; set; }
        public LegalPerson LegalPerson { get; set; }
    }
}
