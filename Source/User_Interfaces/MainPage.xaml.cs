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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Source
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<MenuItem> MenuItems;
        public MainPage()
        {
            this.InitializeComponent();
            FirstFrame.Navigate(typeof(User_Interfaces.BlankPage1));

            //MenuItems = new List<MenuItem>();
            MenuItems = MenuItemManager.GetMenuItems();



        }
        /// <summary>
        /// Disable Mainpage's search box.
        /// </summary>
        public void DisableSearchBox()
        {
            SearchAutoSuggestBox.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// Enable Mainpage's search box
        /// </summary>
        public void EnableSearchBox()
        {
            SearchAutoSuggestBox.Visibility = Visibility.Visible;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            Splitter.IsPaneOpen = !Splitter.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstFrame.CanGoBack)
            {
                FirstFrame.GoBack();
            }
        }

        private void SearchAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

        }

        private void SearchAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

        }

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //string itemClicked = e.ClickedItem.ToString();
            //Title.Text = itemClicked;
            //Button button = sender as Button;
            //MenuItem item = button.DataContext as MenuItem;

            //ListView listview = sender as ListView;
            //MenuItem item = listvi as MenuItem;
            var menuItem = (MenuItem)e.ClickedItem;
            switch (menuItem.Category)
            {
                case MenuItemCategory.Homepage:
                    {
                        this.EnableSearchBox();
                        FirstFrame.Navigate(typeof(User_Interfaces.HomePage));
                        break;
                    }
                case MenuItemCategory.Map:
                    {
                        this.DisableSearchBox(); //MapViewPage has its own Search Box for places, addresses.
                        FirstFrame.Navigate(typeof(User_Interfaces.MapViewPage));
                        break;
                    }
                case MenuItemCategory.About:
                    {
                        this.EnableSearchBox();
                        break;
                    }
                case MenuItemCategory.Photos:
                    {
                        this.EnableSearchBox();
                        break;
                    }
                case MenuItemCategory.Posts:
                    {
                        this.DisableSearchBox(); //HCM
                        FirstFrame.Navigate(typeof(User_Interfaces.HoChiMinh));
                        break;
                    }
                case MenuItemCategory.Settings:
                    {
                        this.EnableSearchBox();
                        break;
                    }
                default:
                    {
                        throw new Exception("Navigation Bar Message Unknown.");
                    }
            }
        }

        private void NavigationButtons_Click(object sender, RoutedEventArgs e)
        {
            //ItemClickEventArgs eventArg = new ItemClickEventArgs();
            //MenuItemsListView_ItemClick(this, eventArg);
           
        }
    }
}
