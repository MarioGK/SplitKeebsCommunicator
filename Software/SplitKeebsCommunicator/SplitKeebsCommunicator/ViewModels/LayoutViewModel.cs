using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using FontAwesome5;
using SplitKeebsCommunicator.Bases;
using SplitKeebsCommunicator.Models;

namespace SplitKeebsCommunicator.ViewModels
{
    public class LayoutViewModel : BaseMenuItem
    {
        private Layout _currentLayout;

        public Layout CurrentLayout
        {
            get => _currentLayout;
            set => SetProperty(ref _currentLayout, value);
        }
        
        public LayoutViewModel(MainViewModel mainViewModel) : base(mainViewModel)
        {
            CurrentLayout = JsonSerializer.Deserialize<Layout>(File.ReadAllText("layout.json"));
            CurrentLayout.ReOrderZIndex();
            Icon = EFontAwesomeIcon.Solid_Language;
            Label = "Layout";
            ToolTip = "The App settings";
        }
    }
}