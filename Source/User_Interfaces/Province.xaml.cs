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
        ProvinceDataContext dataContext;

        public Province()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            dataContext = new ProvinceDataContext((short)e.Parameter);
            this.DataContext = dataContext;
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

#region Transform MAP
        private void mapImage_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            double dblDelta_Scroll = -1 * e.GetCurrentPoint(mapImage).Properties.MouseWheelDelta;

            dblDelta_Scroll = (dblDelta_Scroll > 0) ? 1.2 : 0.8;

            double new_ScaleX = this.mapImage_Transform.ScaleX * dblDelta_Scroll;
            double new_ScaleY = this.mapImage_Transform.ScaleY * dblDelta_Scroll;

            this.mapImage_Transform.CenterX = e.GetCurrentPoint(mapImage).Position.X;
            this.mapImage_Transform.CenterY = e.GetCurrentPoint(mapImage).Position.Y;

            this.mapImage_Transform.ScaleX = new_ScaleX;
            this.mapImage_Transform.ScaleY = new_ScaleY;
        }

        private void mapImage_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            this.mapImage.Opacity = 0.4;
        }

        private void mapImage_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            this.mapImage_Transform.TranslateX += e.Delta.Translation.X;
            this.mapImage_Transform.TranslateY += e.Delta.Translation.Y;
        }

        private void mapImage_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            this.mapImage.Opacity = 1;
        }

        int countShowNotif = 0;
        private void scrollViewer_MAP_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if (countShowNotif < 1)
            {
                FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
                countShowNotif++;
            }
        }

        private void scrollViewer_MAP_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(User_Interfaces.MapViewPage), dataContext.GetProvince.provinceName);
        }
#endregion

    }
}
