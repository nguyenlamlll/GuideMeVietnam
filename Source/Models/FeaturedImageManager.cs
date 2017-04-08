using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source.Models.EnumTypes;
using System.Collections.ObjectModel;

namespace Source.Models
{
    public class FeaturedImageManager
    {

        public static void GetAllFeaturedImages(ObservableCollection<FeaturedImage> images)
        {
            var allImages = FillList();
            images.Clear();
            allImages.ForEach(p => images.Add(p));
        }
        public static List<FeaturedImage> FillList()
        {
            var images = new List<FeaturedImage>();
            string hagiang_test = ProvincesCategory.HaGiang.ToString();

            images.Add(new FeaturedImage("hanoi", ProvincesCategory.HaNoi));
            images.Add(new FeaturedImage("saigon", ProvincesCategory.SaiGon));
            images.Add(new FeaturedImage("ninhbinh", ProvincesCategory.NinhBinh));
            images.Add(new FeaturedImage("hue", ProvincesCategory.Hue));

            /*
            string[] provinceNames = Enum.GetNames(typeof(ProvincesCategory));
            for (int i = 0; i < provinceNames.Count(); i++)
            {
                string uri = String.Format("/Assets/Images/Provinces/{0}/{1}.jpg", 
                    provinceNames[i],);
                
                images.Add(new FeaturedImage(provinceNames[i], ProvincesCategory.HaNoi));
            }
            */
            return images;
        }

    }
}
