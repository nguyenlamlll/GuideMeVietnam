using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Source.DBModels;
using Source.Models;
using Source.Maps;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Source.User_Interfaces
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IconListViewPage : Page
    {
        private List<PlaceInfo> places;
        public IconListViewPage()
        {
            this.InitializeComponent();
            
            LoadSavedLocations();
        }

        private async void LoadSavedLocations()
        {
            MapIconListView.ItemsSource = await PlaceInfoManager.GetAllPlaces();

        }


        private void MapIconListView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
