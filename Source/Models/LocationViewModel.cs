using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietTravel;
using VietTravel.DBModels;

namespace Source.Models
{
    public class LocationViewModel
    {
        public LocationViewModel() { }
        public LocationViewModel(LOCATION loc)
        {
            locationName = loc.locationName;
            using (var db = new VietTravelDBContext())
            {
                var image = db.IMAGES.Find( (short)((loc.locationID - 1) * 3 + 1) );
                imageSource = "/Assets/Images/Locations/InHoChiMinh/" + image.imageSource;
            }
        }

        public string locationName { get; set; }
        public string imageSource { get; set; }
    }

    public class LocationDAL
    {
        public List<LocationViewModel> GetLocation
        {
            get
            {
                List<LocationViewModel> listLocation = new List<LocationViewModel>();

                using (var db = new VietTravelDBContext())
                {
                    foreach (var loc in db.LOCATIONS)
                    {
                        listLocation.Add(new LocationViewModel(loc));
                    }
                }

                return listLocation;
            }
        }
    }
}
