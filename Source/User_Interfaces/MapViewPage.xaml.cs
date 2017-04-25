using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Services.Maps;
using Windows.Devices.Geolocation;
using Source.Maps;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Storage.Streams;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Source.User_Interfaces
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapViewPage : Page
    {
        public MapViewPage()
        {
            this.InitializeComponent();

            //Default Map Service Token given by Bing Map API. 
            //DO NOT ADJUST!!!
            myMap.MapServiceToken = "hFGoiz2f7LfL3WGcHktx~3PNh4h7P9rbooQhDYm1P6g~AgQEVrfjHiWpJwYbSuW-65CUw_RRyCUTexdBwAJsxsRJ5bUTSQsQYRtD7TiHUZXv";


        }

        /// <summary>
        /// Load default settings when the map is first loaded.
        /// </summary>
        private void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            myMap.Center = DefinedGeopoints.DaNangGeoPoint;
            myMap.ZoomLevel = 6;
        }
        private void addXamlChildrenButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mapItemButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PinImage_Tapped(object sender, TappedRoutedEventArgs e)
        {

            //var dialog = new MessageDialog("Pin Added!");
            //await dialog.ShowAsync();

        }

        /// <summary>
        /// Check Downloaded Maps in Windows Settings.
        /// </summary>
        private void DownloadMapButton_Click(object sender, RoutedEventArgs e)
        {
            MapManager.ShowDownloadedMapsUI();
        }

        private void MapSearchSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

        }

        private void MapSearchSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {

        }

        private async void MapSearchSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            Geopoint result = await GeoCoding.ConvertAddressToGeoPoint(myMap.Center, sender.Text);
            if (result != null)
            {
                myMap.Center = result;
                myMap.ZoomLevel = 14;
            }
            sender.Text = "";
            //Place a MapIcon at result.
        }

        /// <summary>
        /// Used to zoom in (see more details) when using the map.
        /// </summary>
        private void ZoomInButton_Click(object sender, RoutedEventArgs e)
        {
            ApplicationMapManager.ZoomIn(myMap, 0.5);
        }

        /// <summary>
        /// Used to zoom out (see less details) when using the map.
        /// </summary>
        private void ZoomOutButton_Click(object sender, RoutedEventArgs e)
        {
            ApplicationMapManager.ZoomOut(myMap, 0.5);
        }

        private async void myMap_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            /*
            Bing.Maps.Location l = new Bing.Maps.Location();
            this.MyMap.TryPixelToLocation(e.GetCurrentPoint(this.MyMap).Position, out l);
            Bing.Maps.Pushpin pushpin = new Bing.Maps.Pushpin();
            pushpin.SetValue(Bing.Maps.MapLayer.PositionProperty, l);
            this.MyMap.Children.Add(pushpin);
            */
            //string pointer = e.Pointer.ToString();
            //var dialog = new MessageDialog("Pin Added!" + pointer);
            //await dialog.ShowAsync();

        }

        private void myMap_MapTapped(MapControl sender, MapInputEventArgs args)
        {
            //Geopoint location = args.Location;
            //ApplicationMapManager.AddStaticMapIcon(myMap, location);

        }

        /// <summary>
        /// Show a context menu when Right Click/Tap on the map
        /// </summary>
        private void myMap_MapRightTapped(MapControl sender, MapRightTappedEventArgs args)
        {
            var attachedFlyout = (MenuFlyout)FlyoutBase.GetAttachedFlyout(myMap);
            attachedFlyout.ShowAt((UIElement)myMap, args.Position);
            tappedLocation = args.Location;
        }

        private Geopoint tappedLocation = null;

        private void PinDrop_MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            ApplicationMapManager.AddStaticMapIcon(myMap, tappedLocation);
        }
    }
}
