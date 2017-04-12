using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Source.Maps
{
    public static class DefinedGeopoints
    {
        /// <summary>
        /// Location of Red River 21.053187, 105.855448
        /// </summary>
        public static readonly Geopoint RedRiverGeoPoint = new Geopoint(new BasicGeoposition() { Latitude = 21.053187, Longitude = 105.855448 });

        /// <summary>
        /// Location of Da Nang 16.043353, 108.188852
        /// </summary>
        public static readonly Geopoint DaNangGeoPoint = new Geopoint(new BasicGeoposition() { Latitude = 16.043353, Longitude = 108.188852 });

        /// <summary>
        /// Location of Saigon 10.801314, 106.659504
        /// </summary>
        public static readonly Geopoint SaiGonGeoPoint = new Geopoint(new BasicGeoposition() { Latitude = 10.801314, Longitude = 106.659504 });
    }
}
