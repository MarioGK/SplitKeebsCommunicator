using System;
// ReSharper disable InconsistentNaming

namespace SplitKeebsCommunicator.HID.Enumerations
{
    [Flags]
    public enum RawInputMouseFlags : ushort
    {
        MOUSE_MOVE_RELATIVE = 0,
        MOUSE_MOVE_ABSOLUTE = 1,
        MOUSE_VIRTUAL_DESKTOP = 2,
        MOUSE_ATTRIBUTES_CHANGED = 4,
    }
}