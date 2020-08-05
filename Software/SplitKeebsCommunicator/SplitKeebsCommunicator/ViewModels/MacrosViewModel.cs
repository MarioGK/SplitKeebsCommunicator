using FontAwesome5;
using SplitKeebsCommunicator.Bases;

namespace SplitKeebsCommunicator.ViewModels
{
    public class MacrosViewModel : BaseMenuItem
    {
        public MacrosViewModel(MainViewModel mainViewModel) : base(mainViewModel)
        {
            Icon = EFontAwesomeIcon.Solid_Cog;
            Label = "Settings";
            ToolTip = "The App settings";
        }
    }
}