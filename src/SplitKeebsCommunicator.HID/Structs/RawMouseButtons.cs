using System.Runtime.InteropServices;
using SplitKeebsCommunicator.HID.Enumerations;

namespace SplitKeebsCommunicator.HID.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RawMouseButtons
    {
        [MarshalAs(UnmanagedType.U2)]
        public RawInputMouseButtonFlags usButtonFlags;
        [MarshalAs(UnmanagedType.U2)]
        public ushort usButtonData;
    }
}