using System.Runtime.InteropServices;

namespace SplitKeebsCommunicator.HID.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RawHid
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint dwSizeHid;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwCount;
    }
}