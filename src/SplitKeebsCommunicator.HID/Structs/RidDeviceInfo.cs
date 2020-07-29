using System.Runtime.InteropServices;
using SplitKeebsCommunicator.HID.Enumerations;

namespace SplitKeebsCommunicator.HID.Structs
{
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct RidDeviceInfo
    {
        [FieldOffset(0)]
        public uint cbSize;
        [MarshalAs(UnmanagedType.U4)]
        [FieldOffset(4)]
        public RawInputDeviceType dwType;
        [FieldOffset(8)]
        public RidDeviceInfoMouse mouse;
        [FieldOffset(8)]
        public RidDeviceInfoKeyboard keyboard;
        [FieldOffset(8)]
        public RidDeviceInfoHid hid;
    }
}