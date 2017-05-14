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
using winsdkfb;
using winsdkfb.Graph;
using System.Diagnostics;
using Windows.Security.Authentication.Web;
using Windows.Globalization;

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

        //Param Login to Facebook
        FBSession sess = FBSession.ActiveSession;

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
                        FirstFrame.Navigate(typeof(User_Interfaces.Country));
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

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (LogInTimes == 1)
            {
                // Create user's settings for the first time launched
                this.CreateUserSettings();
                Utilities.Dialog.ShowDialog("Created 1st-time settings", "Settings Created");
            }

            //Check LoggedIn facebook
            FBSession session = FBSession.ActiveSession;
            await session.LoginAsync();

            if (session.LoggedIn)
            {
                profilePic.UserId = session.User.Id;
                userProfilePic.UserId = profilePic.UserId;
                userNameFB.Text = sess.User.Name;

                fbLogin.IsEnabled = false;
                profilePic.IsEnabled = true;
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

            //bool x = await Utilities.LocalDataAccess.IsExisted("UserPlaces.txt");
            //Utilities.LocalDataAccess.WriteToLocalFolder(DefaultFile.UserPlaces, "");
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

        // <! Some method related Facebook
        private async void fbLogin_Click(object sender, RoutedEventArgs e)
        {
            //Init Login to Facebook
            sess.FBAppId = "479074892435352";
            string SID = WebAuthenticationBroker.GetCurrentApplicationCallbackUri().ToString();
            sess.WinAppId = SID;

            List<String> permissionList = new List<String>();
            permissionList.Add("public_profile");
            FBPermissions permissions = new FBPermissions(permissionList);

            // Login to Facebook
            FBResult result = await sess.LoginAsync(permissions, SessionLoginBehavior.WebView);
            if (result.Succeeded)
            {
                FBUser user = sess.User;
                profilePic.UserId = sess.User.Id;
                userProfilePic.UserId = profilePic.UserId;
                userNameFB.Text = sess.User.Name;

                profilePic.IsEnabled = true;
                fbLogin.IsEnabled = false;
            }
            else
            {
                //Login failed
            }
        }

        private void profilePic_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if (!popupProfile.IsOpen)
                popupProfile.IsOpen = true;
        }

        private async void btnLogoutFB_Click(object sender, RoutedEventArgs e)
        {
            if (popupProfile.IsOpen)
                popupProfile.IsOpen = false;

            await sess.LogoutAsync();

            profilePic.UserId = "";

            fbLogin.IsEnabled = true;
            profilePic.IsEnabled = false;
        }

        private async void btnChangeFB_Click(object sender, RoutedEventArgs e)
        {
            if (popupProfile.IsOpen)
                popupProfile.IsOpen = false;

            this.btnLogoutFB_Click(sender, e);
            await sess.TryRefreshAccessToken();
            this.fbLogin_Click(sender, e);
        }

        private void btnToFB_Click(object sender, RoutedEventArgs e)
        {
            Launch(sess.User.Link);
        }

        async void Launch(string url)
        {
            var uri = new Uri(url);

            var success = await Windows.System.Launcher.LaunchUriAsync(uri);

            if (success)
            {
                // URI launched
            }
            else
            {
                // URI launch failed
            }
        }

        private void Grid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            if (popupProfile.IsOpen)
                popupProfile.IsOpen = false;
        }


        //Some method related Facebook !>
    }
}
