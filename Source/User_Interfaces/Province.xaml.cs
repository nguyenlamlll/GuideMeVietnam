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
    public sealed partial class Province : Page
    {
        private Storyboard expand;
        private Storyboard shrink;

        public Province()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.DataContext = new ProvinceDataContext((short)e.Parameter);
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

        private void lvLocation_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(User_Interfaces.Location), (e.ClickedItem as ProvinceDataViewModel).locationId);
        }
    }
}
