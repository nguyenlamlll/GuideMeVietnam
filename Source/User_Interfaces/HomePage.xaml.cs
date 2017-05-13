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
using Source.Models;
using Source.Models.EnumTypes;
using System.Collections.ObjectModel;
using Windows.UI.Core;
using Windows.Devices.Input;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Source.User_Interfaces
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        //private ObservableCollection<FeaturedImage> FeaturedImages;
        private Storyboard expand;
        private Storyboard shrink;

        public HomePage()
        {
            this.InitializeComponent();

            this.DataContext = new ProvinceDataContext();

            // Initialize FeaturedImages
            //FeaturedImages = new ObservableCollection<FeaturedImage>();
            //FeaturedImageManager.GetAllFeaturedImages(FeaturedImages);
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
