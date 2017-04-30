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
            myMap.MapElementClick += MyMap_MapElementClick;
            // Center the map over the POI.
            myMap.Center = location;
        }

        private static void MyMap_MapElementClick(MapControl sender, MapElementClickEventArgs args)
        {
            Utilities.Dialog.ShowDialog("Map Element Click");
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
