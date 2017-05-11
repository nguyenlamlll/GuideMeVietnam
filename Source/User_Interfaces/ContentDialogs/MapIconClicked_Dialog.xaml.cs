using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Source.User_Interfaces.ContentDialogs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapIconClicked_Dialog : Page
    {

        public MapIconClicked_Dialog()
        {
            this.InitializeComponent();

        }
        public MapIconClicked_Dialog(string Title, string fullAddress, Geopoint point)
        {
            this.InitializeComponent();
            this.Width = AddressTextBlock.Width;

            // Fill title of location and its address.
            FillComponents(Title, fullAddress);

            // Update its GeoLocation
            FillGeopointLocation(point);

        }

        /// <summary>
        /// Fill Longitude and Latitude into their own text blocks
        /// </summary>
        /// <param name="point"></param>
        private void FillGeopointLocation(Geopoint point)
        {
            if (point == null) return;

            decimal longitude = (decimal)point.Position.Longitude;
            longitude = Math.Round(longitude, 4, MidpointRounding.AwayFromZero);

            decimal latitude = (decimal)point.Position.Latitude;
            latitude = Math.Round(latitude, 4, MidpointRounding.AwayFromZero);

            LongitudeTextBlock.Text = longitude.ToString();
            LatitudeTextBlock.Text = latitude.ToString();
        }

        /// <summary>
        /// Fill in text blocks of the title and its address.
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="fullAddress"></param>
        public void FillComponents(string Title, string fullAddress)
        {
            if (Title != "") AddressTitleTextBlock.Text = Title;
            if (fullAddress != "") AddressTextBlock.Text = fullAddress;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string stringToAppend =
                AddressTitleTextBlock.Text + "\n" +
                LatitudeTextBlock.Text + "\n" +
                LongitudeTextBlock.Text + "\n";
            try
            {
                Utilities.LocalDataAccess.Append(stringToAppend, Models.DefaultFile.UserPlaces);


            }
            catch (FileNotFoundException)
            {
                Utilities.Dialog.ShowDialog("Setting Files Not Found.\nPlease reset the settings and try again.", "Error");
            }
            catch (Exception ex)
            {
                Utilities.Dialog.ShowDialog("Error unknown.\n" + ex.ToString(), "Error");
            }

        }
    }
}
