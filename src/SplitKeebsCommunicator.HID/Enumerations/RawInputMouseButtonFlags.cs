using System;
// ReSharper disable InconsistentNaming

namespace SplitKeebsCommunicator.HID.Enumerations
{
    [Flags]
    public enum RawInputMouseButtonFlags : ushort
    {
        RI_MOUSE_LEFT_BUTTON_DOWN = 1,
        RI_MOUSE_LEFT_BUTTON_UP = 2,
        RI_MOUSE_MIDDLE_BUTTON_DOWN = 16, // 0x0010
        RI_MOUSE_MIDDLE_BUTTON_UP = 32, // 0x0020
        RI_MOUSE_RIGHT_BUTTON_DOWN = 4,
        RI_MOUSE_RIGHT_BUTTON_UP = 8,
        RI_MOUSE_BUTTON_1_DOWN = RI_MOUSE_LEFT_BUTTON_DOWN, // 0x0001
        RI_MOUSE_BUTTON_1_UP = RI_MOUSE_LEFT_BUTTON_UP, // 0x0002
        RI_MOUSE_BUTTON_2_DOWN = RI_MOUSE_RIGHT_BUTTON_DOWN, // 0x0004
        RI_MOUSE_BUTTON_2_UP = RI_MOUSE_RIGHT_BUTTON_UP, // 0x0008
        RI_MOUSE_BUTTON_3_DOWN = RI_MOUSE_MIDDLE_BUTTON_DOWN, // 0x0010
        RI_MOUSE_BUTTON_3_UP = RI_MOUSE_MIDDLE_BUTTON_UP, // 0x0020
        RI_MOUSE_BUTTON_4_DOWN = 64, // 0x0040
        RI_MOUSE_BUTTON_4_UP = 128, // 0x0080
        RI_MOUSE_BUTTON_5_DOWN = 256, // 0x0100
        RI_MOUSE_BUTTON_5_UP = 512, // 0x0200
        RI_MOUSE_WHEEL = 1024, // 0x0400
    }
}