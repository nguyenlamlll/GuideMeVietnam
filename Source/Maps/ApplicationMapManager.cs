using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Services.Maps;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

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

        public static async void MyMap_MapElementClick(MapControl sender, MapElementClickEventArgs args)
        {
            MapIcon myClickedIcon = args.MapElements.FirstOrDefault(x => x is MapIcon) as MapIcon;

            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(myClickedIcon.Location);

            string address = null;
            string title = null;
            if (result.Status == MapLocationFinderStatus.Success)
            {
                address = result.Locations[0].Address.FormattedAddress;
                title = result.Locations[0].DisplayName;
            }
            User_Interfaces.ContentDialogs.MapIconClicked_Dialog pinDialog = new User_Interfaces.ContentDialogs.MapIconClicked_Dialog("Push Pin", address, myClickedIcon.Location);

            sender.Children.Add(pinDialog);
            Geopoint pointClicked = args.Location;

            BasicGeoposition displayPoint = myClickedIcon.Location.Position;
            //displayPoint.Latitude -= 0.05;
            displayPoint.Longitude -= 0.0015;
            Geopoint displayGeopoint = new Geopoint(displayPoint);
            
            MapControl.SetLocation(pinDialog, displayGeopoint);
            MapControl.SetNormalizedAnchorPoint(pinDialog, new Point(0, 0));

        }

        public static void MyMap_MapElementPointerEntered(MapControl sender, MapElementPointerEnteredEventArgs args)
        {
            /*
            //Get the MapIcon that user's pointer entered
            MapIcon myClickedIcon = sender.MapElements.FirstOrDefault(x => x is MapIcon) as MapIcon;

            Windows.UI.Color color = Utilities.Color.GetAccentColor();

            Rectangle rect = new Rectangle
            {
                Height = 100,
                Width = 100,
                Fill = new Windows.UI.Xaml.Media.SolidColorBrush(color),
                Opacity = 0.5
            };

            //Add XAML above to the map
            sender.Children.Add(rect);
            Geopoint pointClicked = args.Location;
            MapControl.SetLocation(rect, myClickedIcon.Location);
            MapControl.SetNormalizedAnchorPoint(rect, new Point(0.5, 0.5));
            */
        }

        public static void MyMap_MapElementPointerExited(MapControl sender, MapElementPointerExitedEventArgs args)
        {
            /*
            //Get the MapIcon that user's pointer entered
            MapIcon myClickedIcon = sender.MapElements.FirstOrDefault(x => x is MapIcon) as MapIcon;

            var rectangles = sender.Children.OfType<Rectangle>().ToList();
            if (rectangles != null)
            {
                foreach (Rectangle rect in rectangles)
                {
                    sender.Children.Remove(rect);
                }
                return;
            }
            return;
            */
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

        /// <summary>
        /// Decrease ZoomLevel of a MapControl.
        /// </summary>
        /// <param name="myMap">The map to be set ZoomLevel.</param>
        /// <param name="level">The decreasing amount of ZoomLevel.</param>
        /// <returns></returns>
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

        public static void SetDefaultMapSettings(MapControl map)
        {
            map.Center = DefinedGeopoints.DaNangGeoPoint;
            map.ZoomLevel = 6;
        }

        public static async Task<List<PlaceInfo>> LoadPlaceInfo(string fileName = "default.txt")
        {
            List<PlaceInfo> places = new List<PlaceInfo>();

            Uri dataUri = new Uri("ms-appx:///" + fileName);

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            if (file == null) return null;

            IList<string> lines = await FileIO.ReadLinesAsync(file);

            // In the places.txt file, each place is represented by three lines:
            // Place name, latitude, and longitude.
            for (int i = 0; i < lines.Count; i += 3)
            {
                PlaceInfo place = new PlaceInfo
                {
                    Name = lines[i],
                    Location = new PlaceLocation(double.Parse(lines[i + 1]), double.Parse(lines[i + 2]))
                };

                places.Add(place);
            }
            return places;
        }

    }
}
