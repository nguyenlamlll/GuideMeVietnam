using Source.Models;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Source.User_Interfaces
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Country : Page
    {
        CountryDataContext dataContext = new CountryDataContext();

        private Storyboard expand;
        private Storyboard shrink;

        public Country()
        {
            this.InitializeComponent();
            lvListProvince.DataContext = dataContext;         
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                lvListProvince.DataContext = null;
                lvListProvince.DataContext = new CountryDataContext(e.Parameter.ToString());
            }
        }

        private void Grid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            
            //image_Transform1.CenterX = imageVN.ActualWidth / 2;
            //image_Transform1.CenterY = imageVN.ActualHeight / 2;
            //image_Transform1.ScaleX *= 1.2;
            //image_Transform1.ScaleY *= 1.2;
    
        }

        private void Grid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            //image_Transform1.ScaleX = 1;
            //image_Transform1.ScaleY = 1;
        }

        private void lvListProvince_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(User_Interfaces.Province), (e.ClickedItem as CountryDataViewModel).provinceID);
            //Console.Write((e.ClickedItem as ProvinceViewModel).provinceID);
        }

        private void image_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            expand = ((e.OriginalSource as Image).Resources.ElementAt(0).Value as Storyboard);
            shrink = ((e.OriginalSource as Image).Resources.ElementAt(1).Value as Storyboard);

            expand.Begin();
        }

        private void image_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            shrink.Begin();
        }
    }
}
