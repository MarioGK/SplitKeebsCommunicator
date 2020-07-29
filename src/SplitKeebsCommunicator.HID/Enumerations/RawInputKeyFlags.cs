using System;
// ReSharper disable InconsistentNaming

namespace SplitKeebsCommunicator.HID.Enumerations
{
    [Flags]
    public enum RawInputKeyFlags : ushort
    {
        RI_KEY_MAKE = 0,
        RI_KEY_BREAK = 1,
        RI_KEY_E0 = 2,
        RI_KEY_E1 = 4,
    }
}