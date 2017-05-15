using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietTravel;
using VietTravel.DBModels;

namespace Source.Models
{ 
    public class LocationDataContext
    {
        private short locationId;
        private short articleId;
        //init
        public LocationDataContext() { }
        public LocationDataContext(short locaId)
        {
            this.locationId = locaId;
        }

        public short LocationId
        {
            get
            {
                return this.locationId;
            }
        }

        //
        public LOCATION GetLocation
        {
            get
            {
                using (var db = new VietTravelDBContext())
                {
                    return db.LOCATIONS.Find(locationId);
                }
            }
        }

        public string LocationName
        {
            get
            {
                return GetLocation.locationName;             
            }
        }

        public string Address
        {
            get
            {  
                return GetLocation.locationAddress;         
            }
        }

        public string Description
        {
            get
            {
                using (var db = new VietTravelDBContext())
                {
                    var article = db.ARTICLEs
                        .Where(b => b.locationID == locationId)
                        .FirstOrDefault();

                    this.articleId = article.articleID;

                    return article.content;
                }
            }
        }

        public string Website
        {
            get
            {    
                return GetLocation.website;         
            }
        }

        public List<string> ListImage
        {
            get
            {
                List<string> listImageSource = new List<string>();

                using (var db = new VietTravelDBContext())
                {
                    var listImage = db.IMAGES
                        .Where(b => b.articleID == this.articleId)
                        .ToList();

                    var provinName = db.PROVINCEs.Find(GetLocation.provinceID).provinceName;                

                    string localSource = "/Assets/Images/Locations/In" + provinName.Replace(" ", String.Empty) + "/";

                    foreach (var img in listImage)
                    {
                        listImageSource.Add(localSource + img.imageSource);
                    }

                    return listImageSource;
                }
            }
        }
    }
}
