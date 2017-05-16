using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietTravel;
using VietTravel.DBModels;

namespace GuideTravel.Models
{
    public class ReviewViewModel
    {
        private short locationId;
        //Init
        public ReviewViewModel() { }
        public ReviewViewModel(short locationId)
        {
            this.locationId = locationId;
        }

        public string TotalNumberReview
        {
            get
            {
                using (var db = new VietTravelDBContext())
                {
                    var numOfReview = db.APPRECIATIONs
                        .Where(b => b.locationID == this.locationId)
                        .Count();

                    return numOfReview.ToString();
                }
            }
        }

        public List<APPRECIATION> ListReview
        {
            get
            {
                using (var db = new VietTravelDBContext())
                {
                    var list = db.APPRECIATIONs
                        .Where(b => b.locationID == this.locationId)
                        .OrderByDescending(b => b.appreciaID)
                        .ToList();

                    return list;
                }
            }
        }
    }
}
