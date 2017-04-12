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
        /// Location of Red River
        /// </summary>
        public static readonly Geopoint RedRiverGeoPoint = new Geopoint(new BasicGeoposition() { Latitude = 21.053187, Longitude = 105.855448 });

        /// <summary>
        /// Location of Da Nang 16.043353, 108.188852
        /// </summary>
        public static readonly Geopoint DaNangGeoPoint = new Geopoint(new BasicGeoposition() { Latitude = 16.043353, Longitude = 108.188852 });

    }
}
