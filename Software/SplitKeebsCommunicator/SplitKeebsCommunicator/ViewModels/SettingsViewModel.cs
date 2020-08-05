using FontAwesome5;
using SplitKeebsCommunicator.Bases;

namespace SplitKeebsCommunicator.ViewModels
{
    public class SettingsViewModel : BaseMenuItem
    {
        public SettingsViewModel(MainViewModel mainViewModel) : base(mainViewModel)
        {
            Icon = EFontAwesomeIcon.Solid_Cog;
            Label = "Settings";
            ToolTip = "The App settings";
        }
    }
}