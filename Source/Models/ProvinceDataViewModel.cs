using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietTravel;
using VietTravel.DBModels;

namespace Source.Models
{
    public class ProvinceDataViewModel
    {
        public ProvinceDataViewModel(string sou) { source = sou; }
        public ProvinceDataViewModel(LOCATION loc)
        {
            this.imageSource = "";
            this.provinceId = (short)loc.provinceID;
            this.locationId = (short)loc.locationID;
            this.locationName = loc.locationName;

            using (var db = new VietTravelDBContext())
            {
                this.provinceName = db.PROVINCEs.Find(this.provinceId).provinceName;

                var article = db.ARTICLEs
                    .Where(b => b.locationID == this.locationId)
                    .FirstOrDefault();

                var image = db.IMAGES
                    .Where(b => b.articleID == article.articleID)
                    .FirstOrDefault();

                string localImageSource = "/Assets/Images/Locations/In" + provinceName.Replace(" ", String.Empty) + "/";

                if (image == null)
                    this.imageSource = "";
                else
                    this.imageSource = localImageSource + image.imageSource;
            }
        }

        public short locationId { get; set; }
        public string locationName { get; set; }
        public string imageSource { get; set; }
        public string provinceName { get; set; }
        public short provinceId { get; set; }

        public string source { get; set; }
    }

    public class ProvinceDataContext
    {
        public List<ProvinceDataViewModel> Test
        {
            get
            {
                List<ProvinceDataViewModel> list = new List<ProvinceDataViewModel>();

                list.Add(new ProvinceDataViewModel("ms-appx:///Assets/Images/Countries/VietNam.jpg"));
                list.Add(new ProvinceDataViewModel("ms-appx:///Assets/Images/Countries/VietNam.jpg"));
                list.Add(new ProvinceDataViewModel("ms-appx:///Assets/Images/Countries/VietNam.jpg"));
                list.Add(new ProvinceDataViewModel("ms-appx:///Assets/Images/Countries/VietNam.jpg"));


                return list;
            }
        }

        private short provinceId;

        //init
        public ProvinceDataContext() { }
        public ProvinceDataContext(short provinceId)
        {
            this.provinceId = provinceId;
        }

        //
        public PROVINCE GetProvince
        {
            get
            {
                using (var db = new VietTravelDBContext())
                {
                    return db.PROVINCEs.Find(provinceId);
                }
            }
        }

        public string ProvinceName
        {
            get
            {
                return GetProvince.provinceName;
            }
        }

        public string SuggestSentence
        {
            get
            {        
                return GetProvince.suggestSentence;            
            }
        }

        public string Intro
        {
            get
            {
                return GetProvince.intro;        
            }
        }

        public string MapImageSource
        {
            get
            {
                return "/Assets/Images/Maps/" + GetProvince.mapImageSource;
            }
        }

        public List<ProvinceDataViewModel> GetListDiscovery
        {
            get
            {
                List<ProvinceDataViewModel> listLocation = new List<ProvinceDataViewModel>();

                using (var db = new VietTravelDBContext())
                {
                    foreach (var loc in db.LOCATIONS)
                    {
                        if (loc.typeID == 1 && loc.provinceID == provinceId)
                            listLocation.Add(new ProvinceDataViewModel(loc));
                    }
                }

                return listLocation;
            }
        }

        public List<ProvinceDataViewModel> GetListFood
        {
            get
            {
                List<ProvinceDataViewModel> listLocation = new List<ProvinceDataViewModel>();

                using (var db = new VietTravelDBContext())
                {
                    foreach (var loc in db.LOCATIONS)
                    {
                        if (loc.typeID == 2 && loc.provinceID == provinceId)
                            listLocation.Add(new ProvinceDataViewModel(loc));
                    }
                }

                return listLocation;
            }
        }

        public List<ProvinceDataViewModel> GetListPlacesToStay
        {
            get
            {
                List<ProvinceDataViewModel> listLocation = new List<ProvinceDataViewModel>();

                using (var db = new VietTravelDBContext())
                {
                    foreach (var loc in db.LOCATIONS)
                    {
                        if (loc.typeID == 3 && loc.provinceID == provinceId)
                            listLocation.Add(new ProvinceDataViewModel(loc));
                    }
                }

                return listLocation;
            }
        }


    }
}
