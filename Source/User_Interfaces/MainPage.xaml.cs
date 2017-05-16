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
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Source
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static int LogInTimes = 0;

        private List<MenuItem> MenuItems;

        public MainPage()
        {
            this.InitializeComponent();

            FirstFrame.Navigate(typeof(User_Interfaces.BlankPage1));

            MenuItems = MenuItemManager.GetMenuItems();

            User_Interfaces.SettingsPage.ResetDataEvent += SettingsPage_ResetDataEvent_CreateDefaultSettings;
        }

        private void SettingsPage_ResetDataEvent_CreateDefaultSettings(object sender, EventArgs e)
        {
            CreateUserPlacesFile();
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

        private async void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
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
                        FirstFrame.Navigate(typeof(User_Interfaces.Country));
                        break;
                    }
                case MenuItemCategory.Map:
                    {
                        this.DisableSearchBox(); //MapViewPage has its own Search Box for places, addresses.
                        LoadingIndicator.IsActive = true;
                        await Task.Delay(1000);
                        try
                        {
                            FirstFrame.Navigate(typeof(User_Interfaces.MapViewPage));
                        }
                        catch
                        {

                        }
                        finally
                        {
                            LoadingIndicator.IsActive = false;
                        }
                        break;
                    }
                case MenuItemCategory.About:
                    {
                        this.DisableSearchBox();
                        break;
                    }
                case MenuItemCategory.Photos:
                    {
                        this.DisableSearchBox();
                        break;
                    }
                case MenuItemCategory.Posts:
                    {
                        this.DisableSearchBox();
                        break;
                    }
                case MenuItemCategory.Settings:
                    {
                        this.DisableSearchBox();
                        FirstFrame.Navigate(typeof(User_Interfaces.SettingsPage));
                        break;
                    }
                case MenuItemCategory.Lists:
                    {
                        this.DisableSearchBox();
                        FirstFrame.Navigate(typeof(User_Interfaces.IconListViewPage));
                        break;
                    }
                default:
                    {
                        Utilities.Dialog.ShowDialog("Navigation Bar Message Unknown.\nPlease try again.", "Error");
                        break;
                    }
            }
        }

        private void NavigationButtons_Click(object sender, RoutedEventArgs e)
        {
            //ItemClickEventArgs eventArg = new ItemClickEventArgs();
            //MenuItemsListView_ItemClick(this, eventArg);

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (LogInTimes == 1)
            {
                // Create user's settings for the first time launched
                this.CreateUserSettings();
                Utilities.Dialog.ShowDialog("Created 1st-time settings", "Settings Created");
            }
        }

        /// <summary>
        /// Only used when 1st launched the application.
        /// </summary>
        private void CreateUserSettings()
        {
            try
            {
                Utilities.LocalDataAccess.WriteToLocalFolder(DefaultFile.UserActivities, LogInTimes.ToString());
                Utilities.LocalDataAccess.WriteToLocalFolder(DefaultFile.UserPlaces, "");
            }
            catch (Exception ex)
            {
                Utilities.Dialog.ShowDialog("Error unknown.\n" + ex.ToString(), "Error");
            }
        }
        private void CreateUserPlacesFile()
        {
            try
            {
                Utilities.LocalDataAccess.WriteToLocalFolder(DefaultFile.UserPlaces, "");
            }
            catch (Exception ex)
            {
                Utilities.Dialog.ShowDialog("Error unknown.\n" + ex.ToString(), "Error");
            }
        }


        private void Page_Loading(FrameworkElement sender, object args)
        {
            UpdateLoginTimes();
        }

        private void WriteLoginTimes()
        {
            LogInTimes += 1;
            Utilities.LocalDataAccess.WriteToLocalFolder(DefaultFile.UserActivities, LogInTimes.ToString());
        }
        private async Task ReadLoginTimes()
        {
            try
            {
                string text = await Utilities.LocalDataAccess.ReadLineFromLocalFolder(DefaultFile.UserActivities);
                LogInTimes = int.Parse(text);
            }
            catch
            {
                return;
            }


        }
        private async void UpdateLoginTimes()
        {
            await ReadLoginTimes();
            WriteLoginTimes();
        }
    }
}
