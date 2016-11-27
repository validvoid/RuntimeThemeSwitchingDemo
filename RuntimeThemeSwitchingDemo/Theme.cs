using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace RuntimeThemeSwitchingDemo
{
    public class Theme
    {
        public String ThemeName { get; set; }

        public Color AccentColor { get; set; }
        public SolidColorBrush AccentBrush => new SolidColorBrush(AccentColor);

        public Color HeadTextColor { get; set; }
        public SolidColorBrush HeadTextBrush => new SolidColorBrush(HeadTextColor);

        public Color PrimaryTextColor { get; set; }
        public SolidColorBrush PrimaryTextBrush => new SolidColorBrush(PrimaryTextColor);

        public Color SecondaryTextColor { get; set; }
        public SolidColorBrush SecondaryTextBrush => new SolidColorBrush(SecondaryTextColor);

        public Color PrimaryButtonBackgroundColor { get; set; }
        public SolidColorBrush PrimaryButtonBackgroundBrush => new SolidColorBrush(PrimaryButtonBackgroundColor);

        public Color PrimaryButtonForegroundColor { get; set; }
        public SolidColorBrush PrimaryButtonForegroundBrush => new SolidColorBrush(PrimaryButtonForegroundColor);

        public Color PrimaryButtonBorderColor { get; set; }
        public SolidColorBrush PrimaryButtonBorderBrush => new SolidColorBrush(PrimaryButtonBorderColor);

        public Color SecondaryButtonBackgroundColor { get; set; }
        public SolidColorBrush SecondaryButtonBackgroundBrush => new SolidColorBrush(SecondaryButtonBackgroundColor);

        public Color SecondaryButtonForegroundColor { get; set; }
        public SolidColorBrush SecondaryButtonForegroundBrush => new SolidColorBrush(SecondaryButtonForegroundColor);

        public Color SecondaryButtonBorderColor { get; set; }
        public SolidColorBrush SecondaryButtonBorderBrush => new SolidColorBrush(SecondaryButtonBorderColor);

        public Color PageBackgroundColor { get; set; }
        public SolidColorBrush PageBackgroundBrush => new SolidColorBrush(PageBackgroundColor);

        public Color RightPanelBackgroundColor { get; set; }
        public SolidColorBrush RightPanelBackgroundBrush => new SolidColorBrush(RightPanelBackgroundColor);

        public Color DividerColor { get; set; }
        public SolidColorBrush DividerBrush => new SolidColorBrush(DividerColor);

        public LinearGradientBrush DividerShadowBrush { get; set; }

        public double PrimaryTextSize { get; set; }

        public double SecondaryTextSize { get; set; }

        public double Head1TextSize { get; set; }

        public double Head2TextSize { get; set; }

        public double Head3TextSize { get; set; }

        public FontFamily PrimaryTextFontFamily { get; set; }

        public FontFamily SecondaryTextFontFamily { get; set; }

        public LinearGradientBrush TopToolbarBrush { get; set; }

        public Color TopToolbarBorderColor { get; set; }

        public SolidColorBrush TopToolbarBorderBrush => new SolidColorBrush(TopToolbarBorderColor);

        public Color TopToolbarButtonBackgroundColor { get; set; }
        public SolidColorBrush TopToolbarButtonBackgroundBrush => new SolidColorBrush(TopToolbarButtonBackgroundColor);

        public Color TopToolbarButtonForegroundColor { get; set; }
        public SolidColorBrush TopToolbarButtonForegroundBrush => new SolidColorBrush(TopToolbarButtonForegroundColor);

        public Color TopToolbarButtonBorderColor { get; set; }
        public SolidColorBrush TopToolbarButtonBorderBrush => new SolidColorBrush(TopToolbarButtonBorderColor);
    }

    public class ThemeCollection : List<Theme> { }
}
