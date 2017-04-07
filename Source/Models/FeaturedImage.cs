using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source.Models.EnumTypes;

namespace Source.Models
{
    public class FeaturedImage
    {
        public string ImageTitle { get; set; }
        public ProvincesCategory Province { get; set; }
        public string ImageFile { get; set; }
        public FeaturedImage(string title, ProvincesCategory province)
        {
            ImageTitle = title;
            Province = province;
            ImageFile = String.Format("/Assets/Images/Provinces/{0}/{1}.jpg", province, title);
        }
    }

}
