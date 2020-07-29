using System;
using System.Runtime.InteropServices;

namespace SplitKeebsCommunicator.HID.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SpDevinfoData
    {
        public uint cbSize;
        public Guid ClassGuid;
        public uint DevInst;
        public IntPtr Reserved;
    }
}