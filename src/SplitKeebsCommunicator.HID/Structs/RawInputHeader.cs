using System;
using System.Runtime.InteropServices;
using SplitKeebsCommunicator.HID.Enumerations;

namespace SplitKeebsCommunicator.HID.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RawInputHeader
    {
        [MarshalAs(UnmanagedType.U4)]
        public RawInputDeviceType dwType;
        [MarshalAs(UnmanagedType.U4)]
        public int dwSize;
        public IntPtr hDevice;
        [MarshalAs(UnmanagedType.U4)]
        public int wParam;
    }
}