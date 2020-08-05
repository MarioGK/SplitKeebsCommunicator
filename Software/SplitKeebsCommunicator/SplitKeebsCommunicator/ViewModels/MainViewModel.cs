using System.Collections.ObjectModel;
using Prism.Mvvm;
using SplitKeebsCommunicator.Bases;

namespace SplitKeebsCommunicator.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private ObservableCollection<BaseMenuItem> _menuItems;
        private ObservableCollection<BaseMenuItem> _menuOptionItems;

        public MainViewModel()
        {
            CreateMenuItems();
        }

        public ObservableCollection<BaseMenuItem> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }

        public ObservableCollection<BaseMenuItem> MenuOptionItems
        {
            get => _menuOptionItems;
            set => SetProperty(ref _menuOptionItems, value);
        }

        public void CreateMenuItems()
        {
            MenuItems = new ObservableCollection<BaseMenuItem>
            {
                new LayoutViewModel(this),
                new HomeViewModel(this),
                new DeviceViewModel(this),
                new MacrosViewModel(this)
            };

            MenuOptionItems = new ObservableCollection<BaseMenuItem>
            {
                new SettingsViewModel(this)
            };
        }
    }
}