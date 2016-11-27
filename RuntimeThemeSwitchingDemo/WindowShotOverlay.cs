using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;

namespace RuntimeThemeSwitchingDemo
{
    public class WindowShotOverlay
    {
        private readonly RenderTargetBitmap _bitmap = new RenderTargetBitmap();
        private Popup _pop = new Popup();
        private Storyboard _sbFade = new Storyboard();
        private readonly Image _imgShot = new Image();

        public async Task PrepareShot()
        {
            double statusbarHeight = 0;
            if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
            {
                var sb = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusbarHeight = sb.OccludedRect.Height;
            }


            _pop.Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            _pop.Height = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Height;
            _pop.HorizontalAlignment = HorizontalAlignment.Stretch;
            _pop.VerticalAlignment = VerticalAlignment.Stretch;

            _pop.VerticalOffset = statusbarHeight;

            _imgShot.Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            _imgShot.Height = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Height;
            _imgShot.VerticalAlignment = VerticalAlignment.Stretch;
            _imgShot.HorizontalAlignment = HorizontalAlignment.Stretch;

            await _bitmap.RenderAsync(Window.Current.Content);
            _imgShot.Source = _bitmap;

            _pop.Child = _imgShot;

            DoubleAnimationUsingKeyFrames daukfFade = new DoubleAnimationUsingKeyFrames();

            daukfFade.KeyFrames.Add(new EasingDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(300)),
                Value = 0,
                EasingFunction = new QuinticEase() { EasingMode = EasingMode.EaseIn }
            });

            Storyboard.SetTarget(daukfFade, _imgShot);
            Storyboard.SetTargetProperty(daukfFade, "(UIElement.Opacity)");
            _sbFade.Children.Add(daukfFade);

            _sbFade.Completed += (sender, o) =>
            {
                _pop.IsOpen = false;
                _pop.Child = null;
                _pop = null;
                _sbFade = null;
                daukfFade = null;
            };
        }

        public void ShowOverlay()
        {
            _pop.IsOpen = true;
        }

        public void FadeIntoTheme()
        {
            _sbFade.Begin();
        }
    }
}

