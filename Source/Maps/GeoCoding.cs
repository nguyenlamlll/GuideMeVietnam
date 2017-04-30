using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Services.Maps;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;

namespace Source.Maps
{
    /// <summary>
    /// Provide geographical coordinates corresponding to a location, and vice versa.
    /// </summary>
    public static class GeoCoding
    {
        public static async Task<string> ConvertGeopointToAddress(Geopoint pointToReverseGeocode)
        {
            // Reverse geocode the specified geographic location.
            MapLocationFinderResult result =
                  await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

            // If the query returns results, display the name of the town
            // contained in the address of the first result.
            if (result.Status == MapLocationFinderStatus.Success)
            {
                string resultAddress = result.Locations[0].Address.ToString();
                return resultAddress;
            }
            return null;
        }


        /// <summary>
        /// Convert an user-friendly address to GeoPoint (Example Use: To display on a map.)
        /// </summary>
        /// 
        /// <param name="queryHint">
        /// The nearby location to use as a query hint.
        /// </param>
        /// 
        /// <param name="addressToGeocode">
        /// 
        /// </param>
        public static async Task<Geopoint> ConvertAddressToGeoPoint(Geopoint queryHintPoint, string addressToGeocode)
        {
            Geopoint GeopointResult = null;
    
            // Geocode the specified address, using the specified reference point
            // as a query hint. Return no more than 3 results.
            MapLocationFinderResult result =
                  await MapLocationFinder.FindLocationsAsync(
                                    addressToGeocode,
                                    queryHintPoint,
                                    3);

            // If the query returns results, display the coordinates
            // of the first result.
            if (result.Status == MapLocationFinderStatus.Success)
            {
                //Pass the result into a retriever-method
                var dialog = new MessageDialog("Found it!");
                await dialog.ShowAsync();

                GeopointResult = new Geopoint(new BasicGeoposition
                {
                    Latitude = result.Locations[0].Point.Position.Latitude,
                    Longitude = result.Locations[0].Point.Position.Longitude
                });
                return GeopointResult;
            }
            else
            {
                //Say that we cannot find the location
                var dialog = new MessageDialog("Sorry. Cannot find your location.");
                await dialog.ShowAsync();
                return GeopointResult;
            }
        }

        public static async void ShowMsgBox()
        {
            var dialog = new MessageDialog("ShowMsgBox");
            await dialog.ShowAsync();
        } 
    }
}
