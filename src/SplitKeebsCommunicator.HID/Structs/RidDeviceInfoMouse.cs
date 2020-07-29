using System.Runtime.InteropServices;

namespace SplitKeebsCommunicator.HID.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RidDeviceInfoMouse
    {
        public uint dwId;
        public uint dwNumberOfButtons;
        public uint dwSampleRate;
        public bool fHasHorizontalWheel;
    }
}