using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;

namespace TravelGuide.Maps
{
    /// <summary>
    /// Provide properties and methods to work with user's location.
    /// </summary>
    public static class Location
    {
        //public static async void GetUserLocation()
        //{
        //    var accessStatus = await Geolocator.RequestAccessAsync();
        //    switch (accessStatus)
        //    {
        //        case GeolocationAccessStatus.Allowed:
        //            //_rootPage.NotifyUser("Waiting for update...", NotifyType.StatusMessage);

        //            // If DesiredAccuracy or DesiredAccuracyInMeters are not set (or value is 0), DesiredAccuracy.Default is used.
        //            Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = _desireAccuracyInMetersValue };

        //            // Subscribe to the StatusChanged event to get updates of location status changes.
        //            geolocator.StatusChanged += OnStatusChanged;

        //            // Carry out the operation.
        //            Geoposition pos = await geolocator.GetGeopositionAsync();

        //            UpdateLocationData(pos);
        //            _rootPage.NotifyUser("Location updated.", NotifyType.StatusMessage);
        //            break;

        //        case GeolocationAccessStatus.Denied:
        //            _rootPage.NotifyUser("Access to location is denied.", NotifyType.ErrorMessage);
        //            LocationDisabledMessage.Visibility = Visibility.Visible;
        //            UpdateLocationData(null);
        //            break;

        //        case GeolocationAccessStatus.Unspecified:
        //            _rootPage.NotifyUser("Unspecified error.", NotifyType.ErrorMessage);
        //            UpdateLocationData(null);
        //            break;
        //    }
        //}
    }
}
