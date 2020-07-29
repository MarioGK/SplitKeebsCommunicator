using System;
using System.Runtime.InteropServices;
using SplitKeebsCommunicator.HID.Enumerations;

namespace SplitKeebsCommunicator.HID.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RawInputDeviceList
    {
        public IntPtr hDevice;
        public RawInputDeviceType dwType;
    }
}