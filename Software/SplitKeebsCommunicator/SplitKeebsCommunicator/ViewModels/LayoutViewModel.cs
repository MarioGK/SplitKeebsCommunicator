using System.IO;
using System.Text.Json;
using FontAwesome5;
using SplitKeebsCommunicator.Bases;
using SplitKeebsCommunicator.Models;

namespace SplitKeebsCommunicator.ViewModels
{
    public class LayoutViewModel : BaseMenuItem
    {
        private Layout _currentLayout;

        public LayoutViewModel(MainViewModel mainViewModel) : base(mainViewModel)
        {
            CurrentLayout = JsonSerializer.Deserialize<Layout>(File.ReadAllText("layout.json"));
            CurrentLayout.CalculateKeysPosition();
            Icon    = EFontAwesomeIcon.Solid_Language;
            Label   = "Layout";
            ToolTip = "The App settings";
        }

        public Layout CurrentLayout
        {
            get => _currentLayout;
            set => SetProperty(ref _currentLayout, value);
        }
    }
}