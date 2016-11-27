using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace RuntimeThemeSwitchingDemo
{
    public class ThemeManager
    {
        public static void SwitchTheme(int themenum)
        {
            var controller = App.Current.Resources["ThemeController"] as ThemeController;
            if (controller == null)
                return;

            switch (themenum)
            {
                case 0:
                    controller.ActiveTheme = controller.Themes[0];
                    break;
                case 1:
                    controller.ActiveTheme = controller.Themes[1];
                    break;
                default:
                    controller.ActiveTheme = controller.Themes[0];
                    break;
            }
        }
    }

    public class ThemeController : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ThemeCollection Themes
        {
            get
            {
                return (ThemeCollection)Application.Current.Resources["Themes"];
            }
        }

        [DefaultValue("Default")]
        public String DefaultTheme { get; set; }

        private Theme activeTheme;

        public Theme ActiveTheme
        {
            get
            {
                if (activeTheme == null)
                {
                    activeTheme = Themes.FirstOrDefault(t => t.ThemeName == DefaultTheme);
                }

                return activeTheme;
            }
            set
            {
                if (activeTheme != value)
                {
                    activeTheme = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
