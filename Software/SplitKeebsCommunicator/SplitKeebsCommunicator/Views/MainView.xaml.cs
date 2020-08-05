using System.Windows;
using System.Windows.Media;
using FontAwesome5;
using Notifications.Wpf.Core;

namespace SplitKeebsCommunicator.Views
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView
    {
        private readonly NotificationManager _notificationManager;

        public MainView(NotificationManager notificationManager)
        {
            _notificationManager = notificationManager;
            Icon                 = ImageAwesome.CreateImageSource(EFontAwesomeIcon.Regular_Keyboard, Brushes.White);
            InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            await _notificationManager.ShowAsync(new NotificationContent
            {
                Title   = "Sample notification",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Type    = NotificationType.Information
            });
        }
    }
}