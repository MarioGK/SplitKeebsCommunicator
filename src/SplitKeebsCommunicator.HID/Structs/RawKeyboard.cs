using System.Runtime.InteropServices;
using SplitKeebsCommunicator.HID.Enumerations;

namespace SplitKeebsCommunicator.HID.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RawKeyboard
    {
        [MarshalAs(UnmanagedType.U2)]
        public ushort MakeCode;
        [MarshalAs(UnmanagedType.U2)]
        public RawInputKeyFlags Flags;
        [MarshalAs(UnmanagedType.U2)]
        public ushort Reserved;
        [MarshalAs(UnmanagedType.U2)]
        public ushort VKey;
        [MarshalAs(UnmanagedType.U4)]
        public uint Message;
        [MarshalAs(UnmanagedType.U4)]
        public uint ExtraInformation;
    }
}