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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Source.User_Interfaces
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Location : Page
    {
        DispatcherTimer timer = null;
        List<string> listImage = new List<string>();
        LocationDataContext locationDC;
        int count = 0;

        public Location()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> temp = locationDC.ListImage;
            for (int i = 0; i < temp.Count; i++)
            {
                listImage.Add(temp[i]);
            }

            img.Source = new BitmapImage(new Uri("ms-appx://" + listImage[0]));
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            locationDC = new LocationDataContext((short)e.Parameter);
            this.DataContext = locationDC;

            count = 0;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += PlayListTimer_Tick;
            timer.Start();
        }

        private void PlayListTimer_Tick(object sender, object e)
        {
            if (listImage != null)
            {
                if (count == listImage.Count - 1)
                    count = -1;
                if (count < listImage.Count)
                {
                    count++;
                    ImageRotation();                    
                }
            }
        }

        private void ImageRotation()
        {
            img.Source = new BitmapImage(new Uri("ms-appx://" + listImage[count]));
            opaci.Begin();
        }
    }
}
