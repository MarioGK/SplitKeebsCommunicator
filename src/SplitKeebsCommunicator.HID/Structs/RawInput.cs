using System.Runtime.InteropServices;

namespace SplitKeebsCommunicator.HID.Structs
{
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct RawInput
    {
        [FieldOffset(0)] public RawInputHeader header;
        [FieldOffset(16)] public RawMouse mouse;
        [FieldOffset(16)] public RawKeyboard keyboard;
        [FieldOffset(16)] public RawHid hid;
    }
}