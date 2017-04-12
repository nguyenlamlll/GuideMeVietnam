using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Source.User_Interfaces
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapViewPage : Page
    {
        public MapViewPage()
        {
            this.InitializeComponent();
            myMap.MapServiceToken = "hFGoiz2f7LfL3WGcHktx~3PNh4h7P9rbooQhDYm1P6g~AgQEVrfjHiWpJwYbSuW-65CUw_RRyCUTexdBwAJsxsRJ5bUTSQsQYRtD7TiHUZXv";
        }
        private void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
        private void addXamlChildrenButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mapItemButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void PinImage_Tapped(object sender, TappedRoutedEventArgs e)
        {

            var dialog = new MessageDialog("Pin Added!");
            await dialog.ShowAsync();
        }  
    }
}
