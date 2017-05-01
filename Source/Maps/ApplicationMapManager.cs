using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls.Maps;

namespace Source.Maps
{
    public static class ApplicationMapManager
    {

        /// <summary>
        /// Add a static MapIcon at a desired Geopoint location to a MapControl.
        /// </summary>
        /// <param name="myMap"> The map where this function adds Icon. </param>
        /// <param name="location"> The location where this function adds Icon. </param>
        /// <param name="title"> (Optional) Title of the MapIcon. </param>
        public static void AddStaticMapIcon(MapControl myMap, Geopoint location, string title = "")
        {
            // Create a MapIcon.
            MapIcon mapIcon1 = new MapIcon();

            //Set Image for the MapIcon
            //mapIcon1.Title = GeoCoding.
            mapIcon1.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/push-pin-64.png"));
            mapIcon1.CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible;

            mapIcon1.Location = location;
            mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1);

            mapIcon1.Title = title;
            mapIcon1.ZIndex = 0;

            // Add the MapIcon to the map.
            myMap.MapElements.Add(mapIcon1);



        }

        public static void MyMap_MapElementClick(MapControl sender, MapElementClickEventArgs args)
        {
            Utilities.Dialog.ShowDialog("Map Element Click");
            MapIcon myClickedIcon = args.MapElements.FirstOrDefault(x => x is MapIcon) as MapIcon;
        }
        public static void MyMap_MapElementPointerEntered(MapControl sender, MapElementPointerEnteredEventArgs args)
        {
            MapIcon myClickedIcon = sender.MapElements.FirstOrDefault(x => x is MapIcon) as MapIcon;

            // Get Accent Color
            // For more information, visit: https://docs.microsoft.com/en-us/windows/uwp/style/color
            var uiSettings = new Windows.UI.ViewManagement.UISettings();
            Windows.UI.Color color = uiSettings.GetColorValue(Windows.UI.ViewManagement.UIColorType.Accent);

            Windows.UI.Xaml.Controls.Border border = new Windows.UI.Xaml.Controls.Border
            {
                Height = 66,
                Width = 66,
                BorderBrush = new Windows.UI.Xaml.Media.SolidColorBrush(color),
                BorderThickness = new Windows.UI.Xaml.Thickness(2),
                Opacity = 0.4
            };

            //Add XAML above to the map
            sender.Children.Add(border);
            Geopoint pointClicked = args.Location;
            MapControl.SetLocation(border, myClickedIcon.Location);
            MapControl.SetNormalizedAnchorPoint(border, new Point(0.5, 0.5));
            
        }
        public static void MyMap_MapElementPointerExited(MapControl sender, MapElementPointerExitedEventArgs args)
        {

        }


        /// <summary>
        /// Increase ZoomLevel of a MapControl.
        /// </summary>
        /// <param name="myMap">The map to be set ZoomLevel.</param>
        /// <param name="level">The increasing amount of ZoomLevel.</param>
        /// <returns></returns>
        public static bool ZoomIn(MapControl myMap, double level)
        {
            try
            {
                myMap.ZoomLevel += level;
                return true;
            }
            catch (Exception ex)
            {
                Utilities.Dialog.ShowDialog(ex.ToString());
            }
            return false;
        }

        public static bool ZoomOut(MapControl myMap, double level)
        {
            try
            {
                myMap.ZoomLevel -= level;
            }
            catch (Exception ex)
            {
                Utilities.Dialog.ShowDialog(ex.ToString());
            }
            return false;
        }
    }
}
