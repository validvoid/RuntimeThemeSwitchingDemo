using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RuntimeThemeSwitchingDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Desktop")
            {
                var view = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
                ApplicationViewTitleBar titleBar = view.TitleBar;
                if (titleBar != null)
                {
                    titleBar.BackgroundColor = Color.FromArgb(0, 0, 0, 0);
                    titleBar.ForegroundColor = Colors.White;
                    titleBar.ButtonBackgroundColor = Color.FromArgb(0, 0, 0, 0);
                    titleBar.ButtonInactiveBackgroundColor = Color.FromArgb(0, 0, 0, 0);
                    titleBar.ButtonForegroundColor = Color.FromArgb(0xff, 0xaf, 0xaf, 0xaf);
                }

                CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;

                //Window.Current.SetTitleBar(UIElement);
            }
        }

        private async void toggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (tgsFade.IsOn)
            {
                await Task.Delay(200);
                var overlay = new WindowShotOverlay();
                await overlay.PrepareShot();
                overlay.ShowOverlay();
                ThemeManager.SwitchTheme(tgsNightMode.IsOn ? 1 : 0);
                overlay.FadeIntoTheme();

            }
            else
            {
                ThemeManager.SwitchTheme(tgsNightMode.IsOn ? 1 : 0);
            }
        }
    }
}
