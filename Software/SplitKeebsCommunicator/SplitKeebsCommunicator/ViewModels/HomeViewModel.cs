using FontAwesome5;
using SplitKeebsCommunicator.Bases;

namespace SplitKeebsCommunicator.ViewModels
{
    public class HomeViewModel : BaseMenuItem
    {
        public HomeViewModel(MainViewModel mainViewModel) : base(mainViewModel)
        {
            Icon    = EFontAwesomeIcon.Solid_Home;
            Label   = "Home";
            ToolTip = "The Home";
        }

        public string Test { get; set; }
    }
}