using System.Text;
using SplitKeebsCommunicator.HID.Structs;

namespace SplitKeebsCommunicator.HID.Models
{
    public class Device
    {
        public string Name { get; private set; }
        public string FriendlyName { get; private set; }
        public string Manufacturer { get; private set; }
        public string Product { get; private set; }
        public ushort VendorId { get; private set; }
        public ushort ProductId { get; private set; }
        public ushort Version { get; private set; }
        public int ButtonCount { get; private set; }

        public RidDeviceInfo DeviceInfo { get; set; }
        
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("[HID Device]");
            stringBuilder.AppendLine("HID Device: " + FriendlyName);
            stringBuilder.AppendLine("Name: " + Name);
            stringBuilder.AppendLine("Manufacturer: " + Manufacturer);
            stringBuilder.AppendLine("Product: " + Product);
            stringBuilder.AppendLine("VendorID: " + VendorId.ToString("X4"));
            stringBuilder.AppendLine("ProductID: " + ProductId.ToString("X4"));
            stringBuilder.AppendLine("Version: " + Version);

            return stringBuilder.ToString();
        }
    }
}