using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VietTravel;
using VietTravel.DBModels;
using Windows.UI.Xaml;

namespace Source.Models
{
    public class CountryDataViewModel
    {
        public CountryDataViewModel() { }

        public CountryDataViewModel(PROVINCE pro)
        {
            this.provinceID = pro.provinceID;
            this.provinceName = pro.provinceName;
            this.suggestSentence = pro.suggestSentence;
            this.imageSource = "/Assets/Images/Provinces/" + pro.imageSource;
        }
        
        public short provinceID { get; set; }
        public string provinceName { get; set; }
        public string imageSource { get; set; }
        public string suggestSentence { get; set; }
    }

    public class CountryDataContext
    {
        string name = "";

        public CountryDataContext() { name = ""; }
        public CountryDataContext(string n) { name = n; }

        public List<CountryDataViewModel> GetListProvince
        {
            get
            {
                List<CountryDataViewModel> listProvince = new List<CountryDataViewModel>();

                using (var db = new VietTravelDBContext())
                {
                    if (name == "")
                    {
                        foreach (var pro in db.PROVINCEs)
                        {
                            listProvince.Add(new CountryDataViewModel(pro));
                        }
                    }
                    else
                    {
                        listProvince.Add(new CountryDataViewModel(db.PROVINCEs.Where(p => p.provinceName == name).FirstOrDefault()));
                    }
                }

                return listProvince;
            }
        }

        public List<string> GetListNameProvince
        {
            get
            {
                List<string> listName = new List<string>();

                using (var db = new VietTravelDBContext())
                {
                    foreach (var pro in db.PROVINCEs)
                    {
                        listName.Add(pro.provinceName);
                    }
                }

                return listName;
            }
        }
    }
}
