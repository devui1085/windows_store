using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.User.Common.Enum;

namespace WindowsStore.Client.User.Common.Infrastructure
{
    public class QueryParametersBase
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
