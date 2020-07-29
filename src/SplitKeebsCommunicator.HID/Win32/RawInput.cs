using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using SplitKeebsCommunicator.HID.Enumerations;
using SplitKeebsCommunicator.HID.Models;
using SplitKeebsCommunicator.HID.Structs;

namespace SplitKeebsCommunicator.HID.Win32
{
    /// <summary>
    /// Provide some utility functions for raw input handling.
    /// </summary>
    static public class RawInput
    {
        // Flags controlling what is included in the device information set built by SetupDiGetClassDevs
        public const int DigcfDefault = 0x00000001;       // only valid with DIGCF_DEVICEINTERFACE
        public const int DigcfPresent = 0x00000002;
        public const int DigcfAllClasses = 0x00000004;
        public const int DigcfProfile = 0x00000008;
        public const int DigcfDeviceInterface = 0x00000010;

        public static Guid GuidDevInterfaceKeyboard = new Guid("884b96c3-56ef-11d1-bc8c-00a0c91405dd");
        public static Guid GuidDevInterfaceMouse = new Guid("378DE44C-56EF-11D1-BC8C-00A0C91405DD");
        
                    [DllImport(@"hid.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern void HidD_GetHidGuid(out Guid gHid);


            [DllImport("hid.dll")]
            public extern static bool HidD_SetOutputReport(
                IntPtr hidDeviceObject,
                byte[] lpReportBuffer,
                uint reportBufferLength);


            // --------------------------------------------------------------------------------
            [DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr SetupDiCreateDeviceInfoList(
                ref Guid classGuid,
                IntPtr hwndParent
            );

            [DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr SetupDiCreateDeviceInfoList(
                IntPtr classGuid,
                IntPtr hwndParent
            );
            // --------------------------------------------------------------------------------

            [DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern Boolean SetupDiEnumDeviceInfo(
                IntPtr deviceInfoSet,
                UInt32 memberIndex,
                ref SpDevinfoData deviceInfoData
            );

            // --------------------------------------------------------------------------------

            // Not tested
            [DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
            static extern int CM_Get_Device_ID(int dnDevInst, StringBuilder buffer, int bufferLen, int ulFlags);

            // --------------------------------------------------------------------------------

            [DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr SetupDiGetClassDevs(
                ref Guid classGuid,
                [MarshalAs(UnmanagedType.LPTStr)] string enumerator,
                IntPtr hwndParent,
                UInt32 flags
            );

            [DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr SetupDiGetClassDevs(
                IntPtr classGuid,
                [MarshalAs(UnmanagedType.LPTStr)] string enumerator,
                IntPtr hwndParent,
                UInt32 flags
            );

            // --------------------------------------------------------------------------------

            [DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern Boolean SetupDiEnumDeviceInterfaces(
                IntPtr hDevInfo,
                IntPtr devInvo,
                ref Guid interfaceClassGuid,
                UInt32 memberIndex,
                ref SpDeviceInterfaceData deviceInterfaceData
            );

            [DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern Boolean SetupDiEnumDeviceInterfaces(
                IntPtr hDevInfo,
                ref SpDevinfoData devInvo,
                ref Guid interfaceClassGuid,
                UInt32 memberIndex,
                ref SpDeviceInterfaceData deviceInterfaceData
            );

            // --------------------------------------------------------------------------------

            [DllImport(@"setupapi.dll", SetLastError = true)]
            public static extern Boolean SetupDiGetDeviceInterfaceDetail(
                IntPtr hDevInfo,
                ref SpDeviceInterfaceData deviceInterfaceData,
                IntPtr deviceInterfaceDetailData,
                UInt32 deviceInterfaceDetailDataSize,
                out UInt32 requiredSize,
                IntPtr deviceInfoData
            );

            [DllImport(@"setupapi.dll", SetLastError = true)]
            public static extern Boolean SetupDiGetDeviceInterfaceDetail(
                IntPtr hDevInfo,
                ref SpDeviceInterfaceData deviceInterfaceData,
                ref SpDeviceInterfaceDetailData deviceInterfaceDetailData,
                UInt32 deviceInterfaceDetailDataSize,
                out UInt32 requiredSize,
                IntPtr deviceInfoData
            );


            [DllImport(@"setupapi.dll", SetLastError = true)]
            public static extern Boolean SetupDiGetDeviceInterfaceDetail(
                IntPtr hDevInfo,
                ref SpDeviceInterfaceData deviceInterfaceData,
                ref SpDeviceInterfaceDetailData deviceInterfaceDetailData,
                UInt32 deviceInterfaceDetailDataSize,
                out UInt32 requiredSize,
                ref SpDevinfoData deviceInfoData
            );

            [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern bool SetupDiGetDeviceInstanceId(
                IntPtr deviceInfoSet,
                ref SpDevinfoData deviceInfoData,
                StringBuilder deviceInstanceId,
                int deviceInstanceIdSize,
                out int requiredSize
            );

            [DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern Boolean SetupDiDestroyDeviceInfoList(IntPtr hDevInfo);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aRawInputHandle"></param>
        /// <param name="aRawInput"></param>
        /// <param name="rawInputBuffer">Caller must free up memory on the pointer using Marshal.FreeHGlobal</param>
        /// <returns></returns>
        public static bool GetRawInputData(IntPtr aRawInputHandle, ref RawInput aRawInput, ref IntPtr rawInputBuffer)
        {
            bool success = true;
            rawInputBuffer = IntPtr.Zero;

            try
            {
                uint dwSize = 0;
                uint sizeOfHeader = (uint)Marshal.SizeOf(typeof(RawInputHeader));

                //Get the size of our raw input data.
                Win32.Function.GetRawInputData(aRawInputHandle, Const.RID_INPUT, IntPtr.Zero, ref dwSize, sizeOfHeader);

                //Allocate a large enough buffer
                rawInputBuffer = Marshal.AllocHGlobal((int)dwSize);

                //Now read our RAWINPUT data
                if (Win32.Function.GetRawInputData(aRawInputHandle, RID_INPUT, rawInputBuffer, ref dwSize, (uint)Marshal.SizeOf(typeof(RawInputHeader))) != dwSize)
                {
                    return false;
                }

                //Cast our buffer
                aRawInput = (Rawinput)Marshal.PtrToStructure(rawInputBuffer, typeof(Rawinput));
            }
            catch
            {
                Debug.WriteLine("GetRawInputData failed!");
                success = false;
            }

            return success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hDevice"></param>
        /// <param name="deviceInfo"></param>
        /// <returns></returns>
        public static bool GetDeviceInfo(IntPtr hDevice, ref RID_DEVICE_INFO deviceInfo)
        {
            bool success = true;
            IntPtr deviceInfoBuffer = IntPtr.Zero;
            try
            {
                //Get Device Info
                uint deviceInfoSize = (uint)Marshal.SizeOf(typeof(RID_DEVICE_INFO));
                deviceInfoBuffer = Marshal.AllocHGlobal((int)deviceInfoSize);

                int res = Win32.Function.GetRawInputDeviceInfo(hDevice, Win32.RawInputDeviceInfoType.RIDI_DEVICEINFO, deviceInfoBuffer, ref deviceInfoSize);
                if (res <= 0)
                {
                    Debug.WriteLine("WM_INPUT could not read device info: " + Marshal.GetLastWin32Error().ToString());
                    return false;
                }

                //Cast our buffer
                deviceInfo = (RID_DEVICE_INFO)Marshal.PtrToStructure(deviceInfoBuffer, typeof(RID_DEVICE_INFO));
            }
            catch
            {
                Debug.WriteLine("GetRawInputData failed!");
                success = false;
            }
            finally
            {
                //Always executes, prevents memory leak
                Marshal.FreeHGlobal(deviceInfoBuffer);
            }


            return success;
        }

        /// <summary>
        /// Fetch pre-parsed data corresponding to HID descriptor for the given HID device.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static IntPtr GetPreParsedData(IntPtr hDevice)
        {
            uint ppDataSize = 0;
            int result = Win32.Function.GetRawInputDeviceInfo(hDevice, RawInputDeviceInfoType.RIDI_PREPARSEDDATA, IntPtr.Zero, ref ppDataSize);
            if (result != 0)
            {
                Debug.WriteLine("Failed to get raw input pre-parsed data size: " + result + " : " + Marshal.GetLastWin32Error());
                return IntPtr.Zero;
            }

            IntPtr ppData = Marshal.AllocHGlobal((int)ppDataSize);
            result = Win32.Function.GetRawInputDeviceInfo(hDevice, RawInputDeviceInfoType.RIDI_PREPARSEDDATA, ppData, ref ppDataSize);
            if (result <= 0)
            {
                Debug.WriteLine("Failed to get raw input pre-parsed data: " + result + " : " + Marshal.GetLastWin32Error());
                return IntPtr.Zero;
            }
            return ppData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static string GetDeviceName(IntPtr device)
        {
            uint deviceNameSize = 256;
            int result = Win32.Function.GetRawInputDeviceInfo(device, RawInputDeviceInfoType.RIDI_DEVICENAME, IntPtr.Zero, ref deviceNameSize);
            if (result != 0)
            {
                return string.Empty;
            }

            IntPtr deviceName = Marshal.AllocHGlobal((int)deviceNameSize * 2);  // size is the character count not byte count
            try
            {
                result = Win32.Function.GetRawInputDeviceInfo(device, RawInputDeviceInfoType.RIDI_DEVICENAME, deviceName, ref deviceNameSize);
                if (result > 0)
                {
                    return Marshal.PtrToStringAnsi(deviceName, result - 1); // -1 for NULL termination
                }

                return string.Empty;
            }
            finally
            {
                Marshal.FreeHGlobal(deviceName);
            }
        }


        /// <summary>
        /// Populate the given tree-view control with our Raw Input Devices.
        /// </summary>
        /// <param name="aTreeView"></param>
        public static void PopulateDeviceList(TreeView aTreeView)
        {
            //Get our list of devices
            RawInputDeviceList[] ridList = null;
            uint deviceCount = 0;
            int res = Win32.Function.GetRawInputDeviceList(ridList, ref deviceCount, (uint)Marshal.SizeOf(typeof(RawInputDeviceList)));
            if (res == -1)
            {
                //Just give up then
                return;
            }

            ridList = new RawInputDeviceList[deviceCount];
            res = Win32.Function.GetRawInputDeviceList(ridList, ref deviceCount, (uint)Marshal.SizeOf(typeof(RawInputDeviceList)));
            if (res != deviceCount)
            {
                //Just give up then
                return;
            }

            //For each our device add a node to our treeview
            foreach (RawInputDeviceList device in ridList)
            {
                Device hidDevice;

                //Try create our HID device.
                try
                {
                    hidDevice = new Device(device.hDevice);
                }
                catch /*(System.Exception ex)*/
                {
                    //Just skip that device then
                    continue;
                }

                TreeNode node = null;
                if (hidDevice.Product != null && hidDevice.Product.Length > 1)
                {
                    //Add the devices with a proper name at the top
                    node = aTreeView.Nodes.Insert(0, hidDevice.Name, hidDevice.FriendlyName);
                }
                else
                {
                    //Add other once at the bottom
                    node = aTreeView.Nodes.Add(hidDevice.Name, hidDevice.FriendlyName);
                }

                //Each device root node keeps a reference to our HID device
                node.Tag = hidDevice;

                //Populate device properties
                node.Nodes.Add("Manufacturer: " + hidDevice.Manufacturer);
                node.Nodes.Add("Product ID: 0x" + hidDevice.ProductId.ToString("X4"));
                node.Nodes.Add("Vendor ID: 0x" + hidDevice.VendorId.ToString("X4"));
                node.Nodes.Add("Version: " + hidDevice.Version);
                node.Nodes.Add(hidDevice.DeviceInfo.dwType.ToString());
                if (hidDevice.DeviceInfo.dwType == RawInputDeviceType.RIM_TYPEHID)
                {
                    node.Nodes.Add("UsagePage / UsageCollection: 0x" + hidDevice.DeviceInfo.hid.usUsagePage.ToString("X4") + " / 0x" + hidDevice.Info.hid.usUsage.ToString("X4"));
                }

                if (hidDevice.InputCapabilitiesDescription != null)
                {
                    node.Nodes.Add(hidDevice.InputCapabilitiesDescription);
                }

                //Add button count
                node.Nodes.Add("Button Count: " + hidDevice.ButtonCount);

                //Those can be joystick/gamepad axis
                if (hidDevice.InputValueCapabilities != null)
                {
                    foreach (HIDP_VALUE_CAPS caps in hidDevice.InputValueCapabilities)
                    {
                        string des = SharpLib.Hid.Device.InputValueCapabilityDescription(caps);
                        if (des != null)
                        {
                            node.Nodes.Add(des);
                        }
                    }

                }

                node.Nodes.Add(hidDevice.Name);
            }
        }

    }
}