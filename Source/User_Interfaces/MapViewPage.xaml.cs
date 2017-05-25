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
using Source.User_Interfaces.ContentDialogs;

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
        /// Get Location in prev Page and show it
        /// </summary>
        /// <param name="e"></param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                Geopoint result = await GeoCoding.ConvertAddressToGeoPoint(myMap.Center, e.Parameter.ToString());

                if (result != null)
                {
                    myMap.Center = result;
                    myMap.ZoomLevel = 14;
                }
            }
        }

        public bool IsMapIconDeleting = false;

        /// <summary>
        /// Load default settings when the map is first loaded.
        /// </summary>
        private void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            myMap.MapElementClick += ApplicationMapManager.MyMap_MapElementClick;
            myMap.MapElementPointerEntered += ApplicationMapManager.MyMap_MapElementPointerEntered;
            myMap.MapElementPointerExited += ApplicationMapManager.MyMap_MapElementPointerExited;
            MapIconClicked_Dialog.MapIconDeleting += this.DeleteMapIcon;

            ApplicationMapManager.SetDefaultMapSettings(this.myMap);

            // Change Map's theme.
            SettingsPage.MapThemeChangedToLight += myMap_ChangeThemeToLight;
            SettingsPage.MapThemeChangedToDark += myMap_ChangeThemeToDark;


            LoadingIndicator.IsActive = false;

            LoadSavedLocations();
        }

        private async void LoadSavedLocations()
        {
            bool IsIconExisted = false;
            List<PlaceInfo> places = await ApplicationMapManager.LoadPlaceInfo(Models.DefaultFile.UserPlaces);
            foreach (PlaceInfo place in places)
            {
                IsIconExisted = false;
                foreach (MapIcon icon in myMap.MapElements.Where(p => p is MapIcon))
                {
                    if (place.Location.Geopoint.Position.Latitude == icon.Location.Position.Latitude
                        && place.Location.Geopoint.Position.Longitude == icon.Location.Position.Longitude)
                    {
                        IsIconExisted = true;
                        break;
                    }
                }
                if (!IsIconExisted)
                    ApplicationMapManager.AddStaticMapIcon(myMap, place.Location.Geopoint, "Saved Location");
            }
        }

        private void myMap_ChangeThemeToDark(object sender, EventArgs e)
        {
            myMap.ColorScheme = MapColorScheme.Dark;
        }

        private void myMap_ChangeThemeToLight(object sender, EventArgs e)
        {
            myMap.ColorScheme = MapColorScheme.Light;
        }

        private void mapItemButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PinImage_Tapped(object sender, TappedRoutedEventArgs e)
        {

            //var dialog = new MessageDialog("Pin Added!");
            //await dialog.ShowAsync();

        }

        private void MapSearchSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

        }

        private void MapSearchSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {

        }

        private async void MapSearchSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            try
            {
                LoadingIndicator.IsActive = true;
                await Task.Delay(1000);
                Geopoint result = await GeoCoding.ConvertAddressToGeoPoint(myMap.Center, sender.Text);
                if (result != null)
                {
                    myMap.Center = result;
                    myMap.ZoomLevel = 14;
                }

                // Clear submitted query in Autosuggest Box
                sender.Text = "";

                //Place a MapIcon at result.
                ApplicationMapManager.AddStaticMapIcon(myMap, result);
            }
            catch (ArgumentOutOfRangeException)
            {
                Utilities.Dialog.ShowDialog("Sorry. Cannot find your location.\nPlease try again with more details.", "Error");
            }
            catch (Exception ex)
            {
                Utilities.Dialog.ShowDialog("Error unknown.\n" + ex.ToString(), "Error");
            }
            finally
            {
                LoadingIndicator.IsActive = false;
            }
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

        private void MapSettingButton_Click(object sender, RoutedEventArgs e)
        {
            var attachedFlyout = (MenuFlyout)FlyoutBase.GetAttachedFlyout(MapSettingButton);
            attachedFlyout.ShowAt(MapSettingButton);
        }

        private void myMap_Loading(FrameworkElement sender, object args)
        {
            LoadingIndicator.IsActive = true;
        }

        /// <summary>
        /// Will be called when user clicks Delete button in info box of each MapIcon.
        /// This method deletes the MapIcon (where it is called).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="point">The MapIcon/Location that will be deleted.</param>
        private void DeleteMapIcon(object sender, Geopoint point)
        {
            foreach (MapIcon icon in myMap.MapElements.Where(p => p is MapIcon))
            {
                if (icon.Location == point)
                {
                    myMap.MapElements.Remove(icon);
                    foreach (MapIconClicked_Dialog infoDialog in myMap.Children.Where(p => p is MapIconClicked_Dialog))
                    {
                        myMap.Children.Remove(infoDialog);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Load all saved location onto the map (if they are not already there).
        /// </summary>
        private void LoadCollection_MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            LoadSavedLocations();
        }
    }
}
