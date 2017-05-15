using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;

namespace Source.Maps
{
    class Place
    {
    }

    // A PlaceLocation represents a location in two forms:
    // Geoposition (latitude, longitude, altitude)
    // Normalized map coordinates in the unit square from (0,0) to (1,1)
    public struct PlaceLocation
    {
        public PlaceLocation(double latitude, double longitude)
        {
            Geoposition = new BasicGeoposition() { Latitude = latitude, Longitude = longitude };
            MapCoordinates = GetMapCoordinates(Geoposition);
            Geopoint = new Geopoint(Geoposition);
        }
        public BasicGeoposition Geoposition { get; }
        public Geopoint Geopoint { get; }
        public Point MapCoordinates { get; }

        static private Point GetMapCoordinates(BasicGeoposition geoposition)
        {
            // This formula comes from https://msdn.microsoft.com/en-us/library/bb259689.aspx

            // Clamp latitude to the range -85.05112878 to 85.05112878.
            // This keeps Y in range and avoids the singularity at the pole.
            double latitude = Math.Max(Math.Min(geoposition.Latitude, 85.05112878), -85.05112878);

            double sinLatitude = Math.Sin(latitude * Math.PI / 180.0);
            return new Point
            {
                X = (geoposition.Longitude + 180.0) / 360.0,
                Y = 0.5 - Math.Log((1.0 + sinLatitude) / (1.0 - sinLatitude)) / (4 * Math.PI)
            };
        }
    }

    public sealed class PlaceInfo
    {
        public string Name { get; set; }
        public PlaceLocation Location { get; set; }
    }


    // A cluster is a group of places that are at almost the same location.
    public sealed class Cluster
    {
        public PlaceLocation Location { get; set; }
        public IList<PlaceInfo> Places { get; private set; } = new List<PlaceInfo>();
    }
}
