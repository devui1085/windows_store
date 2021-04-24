using System;

namespace Store.Common.Enum
{
    [Flags]
    public enum CpuArchitecture : byte
    {
        None = 0,
        Arm = 1,
        X86 = 2,
        X64 = 4
    }
}
