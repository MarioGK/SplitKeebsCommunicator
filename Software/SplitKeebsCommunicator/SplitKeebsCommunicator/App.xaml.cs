using System.Windows;
using DryIoc;
using Notifications.Wpf.Core;
using Prism.DryIoc;
using Prism.Ioc;
using SplitKeebsCommunicator.Views;

namespace SplitKeebsCommunicator
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static IContainer AppContainer { get; set; }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton(typeof(NotificationManager));
            AppContainer = containerRegistry.GetContainer();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }
    }
}