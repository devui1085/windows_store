using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsStore.Client.Admin.Common.Enum
{
    public enum AppType
    {
        Application = 1,
        Game = 2
    }

    public enum Sexuality
    {
        Male = 1,
        Female = 2
    }

    public enum UserAccountStatus
    {
        Activated = 1,
        NotActivated = 2,
        Blocked = 3
    }
}
