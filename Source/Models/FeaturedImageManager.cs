using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source.Models.EnumTypes;

namespace Source.Models
{
    public class FeaturedImageManager
    {

        public static List<FeaturedImage> GetFeaturedImage()
        {
            var images = new List<FeaturedImage>();

            return images;
        }
        public static List<FeaturedImage> FillList()
        {
            var images = new List<FeaturedImage>();
            string[] provinceNames = Enum.GetNames(typeof(ProvincesCategory));
            images.Add(new FeaturedImage("hanoi", ProvincesCategory.HaNoi));

            return images;
        }

    }
}
