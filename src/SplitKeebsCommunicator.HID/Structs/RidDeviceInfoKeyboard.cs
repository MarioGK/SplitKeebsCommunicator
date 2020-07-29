using System.Runtime.InteropServices;

namespace SplitKeebsCommunicator.HID.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RidDeviceInfoKeyboard
    {
        public uint dwType;
        public uint dwSubType;
        public uint dwKeyboardMode;
        public uint dwNumberOfFunctionKeys;
        public uint dwNumberOfIndicators;
        public uint dwNumberOfKeysTotal;
    }
}