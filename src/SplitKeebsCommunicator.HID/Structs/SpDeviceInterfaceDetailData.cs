using System;
using System.Runtime.InteropServices;

namespace SplitKeebsCommunicator.HID.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SpDeviceInterfaceDetailData
    {
        public UInt32 cbSize;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        public string DevicePath;
    }
}