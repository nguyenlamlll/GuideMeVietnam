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
            //this.Width = AddressTextBlock.Width;
            this.InitializeComponent();

            // Fill title of location and its address.
            FillComponents(Title, fullAddress);

            // Update its GeoLocation
            FillGeopointLocation(point);

        }

        private void FillGeopointLocation(Geopoint point)
        {
            LongitudeTextBlock.Text = point.Position.Longitude.ToString();
            LatitudeTextBlock.Text = point.Position.Latitude.ToString();
        }

        public void FillComponents(string Title, string fullAddress)
        {
            AddressTitleTextBlock.Text = Title;
            AddressTextBlock.Text = fullAddress;
        }
        
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string stringToAppend = AddressTitleTextBlock.Text + "\n";
            try
            {
                Utilities.LocalDataAccess.Append(Models.DefaultFile.UserPlaces, AddressTitleTextBlock.Text);
            }
            catch (FileNotFoundException ex)
            {
                Utilities.Dialog.ShowDialog("Setting File Not Found. Please reset the settings and try again.\n" + ex.ToString(), "Error");
            }
            catch (Exception ex)
            {
                Utilities.Dialog.ShowDialog("Error unknown.\n" + ex.ToString(), "Error");
            }
           
        }
    }
}
