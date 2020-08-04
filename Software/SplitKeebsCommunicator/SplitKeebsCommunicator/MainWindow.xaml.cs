using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FontAwesome5;
using Notifications.Wpf.Core;

namespace SplitKeebsCommunicator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly NotificationManager _notificationManager;

        public MainWindow(NotificationManager notificationManager)
        {
            _notificationManager = notificationManager;
            Icon = ImageAwesome.CreateImageSource(EFontAwesomeIcon.Regular_Keyboard, Brushes.White);
            InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            await _notificationManager.ShowAsync(new NotificationContent
            {
                Title = "Sample notification",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Type = NotificationType.Information
            });
        }
    }
}