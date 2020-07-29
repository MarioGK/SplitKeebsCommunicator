using System.Runtime.InteropServices;

namespace SplitKeebsCommunicator.HID.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RidDeviceInfoHid
    {
        public uint dwVendorId;
        public uint dwProductId;
        public uint dwVersionNumber;
        public ushort usUsagePage;
        public ushort usUsage;
    }
}