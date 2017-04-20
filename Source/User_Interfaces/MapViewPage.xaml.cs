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
            myMap.MapServiceToken = "hFGoiz2f7LfL3WGcHktx~3PNh4h7P9rbooQhDYm1P6g~AgQEVrfjHiWpJwYbSuW-65CUw_RRyCUTexdBwAJsxsRJ5bUTSQsQYRtD7TiHUZXv";
        }
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
            // Specify a known location.
            Geopoint snPoint = DefinedGeopoints.RedRiverGeoPoint;

            // Create a MapIcon.
            MapIcon mapIcon1 = new MapIcon();
            mapIcon1.Location = snPoint;
            mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
            mapIcon1.Title = "Space Needle";
            mapIcon1.ZIndex = 0;

            // Add the MapIcon to the map.
            myMap.MapElements.Add(mapIcon1);

            // Center the map over the POI.
            myMap.Center = snPoint;
            myMap.ZoomLevel = 14;

            //var dialog = new MessageDialog("Pin Added!");
            //await dialog.ShowAsync();

        }

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


        private void ZoomInButton_Click(object sender, RoutedEventArgs e)
        {
            myMap.ZoomLevel += 0.5;
        }

        private void ZoomOutButton_Click(object sender, RoutedEventArgs e)
        {
            myMap.ZoomLevel -=0.5;
        }
    }
}
