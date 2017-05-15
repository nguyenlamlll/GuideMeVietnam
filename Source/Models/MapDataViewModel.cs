using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietTravel;
using VietTravel.DBModels;

namespace Source.Models
{
    public class MapDataViewModel
    {
        //private static int LocalMapID = 0;

        //public int GetCurrentMapID()
        //{
        //    LocalMapID++;
        //    return LocalMapID;
        //}

        public MapDataViewModel() { }

        public MapDataViewModel(MAP map)
        {
            this.mapID = map.mapID;
            this.mapName = map.mapName;
            this.longtitude = map.longtitude;
            this.latitude = map.latitude;
        }
        public short mapID { get; set; }
        public string mapName { get; set; }
        public Nullable<decimal> longtitude { get; set; }
        public Nullable<decimal> latitude { get; set; }
    }

    public class MapDataContext
    {

        public List<MapDataViewModel> GetAll
        {
            get
            {
                List<MapDataViewModel> listPlanTrip = new List<MapDataViewModel>();

                using (var db = new VietTravelDBContext())
                {
                    foreach (var map in db.MAPs)
                    {
                        listPlanTrip.Add(new MapDataViewModel(map));
                    }
                }

                return listPlanTrip;
            }
        }
    }
}
