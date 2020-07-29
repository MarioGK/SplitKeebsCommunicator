using System.Runtime.InteropServices;
using SplitKeebsCommunicator.HID.Enumerations;

namespace SplitKeebsCommunicator.HID.Structs
{
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct RawMouse
    {
        [MarshalAs(UnmanagedType.U2)] [FieldOffset(0)]
        public RawInputMouseFlags usFlags;

        [MarshalAs(UnmanagedType.U4)] [FieldOffset(4)]
        public uint ulButtons;

        [FieldOffset(4)] public RawMouseButtons buttonsStr;

        [MarshalAs(UnmanagedType.U4)] [FieldOffset(8)]
        public uint ulRawButtons;

        [MarshalAs(UnmanagedType.U4)] [FieldOffset(12)]
        public int lLastX;

        [MarshalAs(UnmanagedType.U4)] [FieldOffset(16)]
        public int lLastY;

        [MarshalAs(UnmanagedType.U4)] [FieldOffset(20)]
        public uint ulExtraInformation;
    }
}