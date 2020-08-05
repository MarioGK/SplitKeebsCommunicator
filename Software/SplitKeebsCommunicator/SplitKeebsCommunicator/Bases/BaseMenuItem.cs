using FontAwesome5;
using MahApps.Metro.Controls;
using Prism.Mvvm;
using SplitKeebsCommunicator.ViewModels;

namespace SplitKeebsCommunicator.Bases
{
    /// <summary>
    /// Implement the IHamburgerMenuItemBase to allow set the Visibility of the item itself.
    /// </summary>
    public abstract class BaseMenuItem : BindableBase, IHamburgerMenuItemBase
    {
        private EFontAwesomeIcon _icon;
        private object _label;
        private object _toolTip;
        private bool _isVisible = true;

        public BaseMenuItem(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }

        public MainViewModel MainViewModel { get; }

        public EFontAwesomeIcon Icon
        {
            get => _icon;
            protected set => SetProperty(ref _icon, value);
        }

        public object Label
        {
            get => _label;
            protected set => SetProperty(ref _label, value);
        }

        public object ToolTip
        {
            get => _toolTip;
            protected set => SetProperty(ref _toolTip, value);
        }

        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }
    }
}