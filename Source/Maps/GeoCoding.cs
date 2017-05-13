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
        /// <summary>
        /// Turn Geopoint into human-friendly addresses.
        /// </summary>
        /// <param name="pointToReverseGeocode">Geopoint to be reversed into human-address.</param>
        /// <returns></returns>
        public static async Task<string> ConvertGeopointToAddress(Geopoint pointToReverseGeocode)
        {
            // Reverse geocode the specified geographic location.
            MapLocationFinderResult result =
                  await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

            // If the query returns results, display the name of the town
            // contained in the address of the first result.
            string resultAddress = null;
            if (result.Status == MapLocationFinderStatus.Success)
            {
                if (result.Locations.Any()) resultAddress = result.Locations[0].Address.FormattedAddress;
                return resultAddress;
            }
            return null;
        }

        /// <summary>
        /// Convert Geopoint into Country Name of that location.
        /// </summary>
        /// <param name="pointToReverseGeocode"></param>
        /// <returns></returns>
        public static async Task<string> ConvertGeopointToCountry(Geopoint pointToReverseGeocode)
        {
            // Reverse geocode the specified geographic location.
            MapLocationFinderResult result =
                  await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

            string resultCountry = null;
            if (result.Status == MapLocationFinderStatus.Success)
            {
                if (result.Locations.Any()) resultCountry = result.Locations[0].Address.Country;
                return resultCountry;
            }
            return null;
        }

        public static async Task<string> ConvertGeopointToCity(Geopoint pointToReverseGeocode)
        {
            // Reverse geocode the specified geographic location.
            MapLocationFinderResult result =
                  await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

            string resultCity = null;
            if (result.Status == MapLocationFinderStatus.Success)
            {
                if (result.Locations.Any()) resultCity = result.Locations[0].Address.Country;
                return resultCity;
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
                if (result.Locations.Any())
                {
                    GeopointResult = new Geopoint(new BasicGeoposition
                    {
                        Latitude = result.Locations[0].Point.Position.Latitude,
                        Longitude = result.Locations[0].Point.Position.Longitude
                    });
                    return GeopointResult;
                }
                // Search is succeed, but yields no result.
                Utilities.Dialog.ShowDialog("Sorry. Cannot find your location.\nPlease try again with more details.");
                return GeopointResult;
            }
            // Search is failed. (maybe due to input faults, or connection errors)
            else
            {
                //Say that we cannot find the location
                Utilities.Dialog.ShowDialog("Sorry. Cannot find your location.\nPlease check your internet connection and try again.");
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
