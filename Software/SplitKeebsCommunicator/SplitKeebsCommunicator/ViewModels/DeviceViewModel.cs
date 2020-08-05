using FontAwesome5;
using SplitKeebsCommunicator.Bases;

namespace SplitKeebsCommunicator.ViewModels
{
    public class DeviceViewModel : BaseMenuItem
    {
        public DeviceViewModel(MainViewModel mainViewModel) : base(mainViewModel)
        {
            Icon    = EFontAwesomeIcon.Solid_Key;
            Label   = "Settings";
            ToolTip = "The App settings";
        }
    }
}