using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GridContextMenu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<string> itemsource = new List<string> { "Hi", "Hello" };
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var currentApplicationView = ApplicationView.GetForCurrentView();
            var newCoreApplicationView = CoreApplication.CreateNewView();

            ApplicationView newApplicationView = null;
            await newCoreApplicationView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                newApplicationView = ApplicationView.GetForCurrentView();
            });


            await newCoreApplicationView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                var newWindow = Window.Current;
                var frame = new Frame();
                frame.Navigate(typeof(Assets.SecondWindow));
                newWindow.Content = frame;
                newWindow.Activate();
            });

            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newApplicationView.Id, ViewSizePreference.Default);
        }

        private void MenuFlyout_Opening(object sender, object e)
        {
        }

        private void FolderOptionsFlyout_Opened(object sender, object e)
        {

        }

        private void FolderOptionsFlyout_Closed(object sender, object e)
        {

        }
    }
}
