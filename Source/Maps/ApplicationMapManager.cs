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
            mapIcon1.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/push-pin-64.png"));
            mapIcon1.CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible;

            mapIcon1.Location = location;
            mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1);

            mapIcon1.Title = title;
            mapIcon1.ZIndex = 0;

            // Add the MapIcon to the map.
            myMap.MapElements.Add(mapIcon1);

            // Center the map over the POI.
            myMap.Center = location;
        }
    }
}
