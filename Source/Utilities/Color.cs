using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Utilities
{
    class Color
    {
        /// <summary>
        /// Get Accent Color.
        /// Documented at: https://docs.microsoft.com/en-us/windows/uwp/style/color
        /// </summary>
        public static Windows.UI.Color GetAccentColor()
        {
            var uiSettings = new Windows.UI.ViewManagement.UISettings();
            Windows.UI.Color color = uiSettings.GetColorValue(Windows.UI.ViewManagement.UIColorType.Accent);
            return color;
        }
        public static Windows.UI.Color GetForegroundColor()
        {
            var uiSettings = new Windows.UI.ViewManagement.UISettings();
            Windows.UI.Color color = uiSettings.GetColorValue(Windows.UI.ViewManagement.UIColorType.Foreground);
            return color;
        }
        public static Windows.UI.Color GetBackgroundColor()
        {
            var uiSettings = new Windows.UI.ViewManagement.UISettings();
            Windows.UI.Color color = uiSettings.GetColorValue(Windows.UI.ViewManagement.UIColorType.Background);
            return color;
        }
        public static Windows.UI.Color GetComplementColor()
        {
            var uiSettings = new Windows.UI.ViewManagement.UISettings();
            Windows.UI.Color color = uiSettings.GetColorValue(Windows.UI.ViewManagement.UIColorType.Complement);
            return color;
        }
    }
}
