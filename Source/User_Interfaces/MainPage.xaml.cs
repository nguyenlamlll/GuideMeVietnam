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
using Windows.UI;
using Windows.UI.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Source
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    ///
    public sealed partial class MainPage : Page
    {
        public static MainPage Current;

        public static int LogInTimes = 0;

        private List<MenuItem> MenuItems;

        CountryDataContext countryNameDataContext = new CountryDataContext();

        //Param Login to Facebook
        FBSession sess = FBSession.ActiveSession;

        public MainPage()
        {
            this.InitializeComponent();

            // This is a static public property that allows downstream pages to get a handle to the MainPage instance
            // in order to call methods that are in this class.
            Current = this;

            FirstFrame.Navigate(typeof(User_Interfaces.BlankPage1));

            MenuItems = MenuItemManager.GetMenuItems();

            SearchAutoSuggestBox.DataContext = countryNameDataContext;

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
            var Auto = (AutoSuggestBox)sender;
            var Suggestion = countryNameDataContext.GetListNameProvince.Where(p => p.IndexOf(Auto.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToArray();
            Auto.ItemsSource = Suggestion;
        }

        private void SearchAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            this.EnableSearchBox();
            FirstFrame.Navigate(typeof(User_Interfaces.Country), args.QueryText);
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
                        this.EnableSearchBox();
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
                        this.EnableSearchBox();
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
                profilePicToolbar.UserId = session.User.Id;
                profilePicPopup.UserId = profilePicToolbar.UserId;
                userNameFB.Text = sess.User.Name;

                fbLogin.IsEnabled = false;
                profilePicToolbar.IsEnabled = true;
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


        #region Some methods relating to Facebook
        // <! Some method related Facebook
        private async void fbLogin_Click(object sender, RoutedEventArgs e)
        {
            //Init Login to Facebook
            sess.FBAppId = "1898944270325861";
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
                profilePicToolbar.UserId = sess.User.Id;
                profilePicPopup.UserId = profilePicToolbar.UserId;
                userNameFB.Text = sess.User.Name;

                profilePicToolbar.IsEnabled = true;
                fbLogin.IsEnabled = false;
            }
            else
            {
                // Log in failed
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

            profilePicToolbar.UserId = "";

            fbLogin.IsEnabled = true;
            profilePicToolbar.IsEnabled = false;
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
        #endregion


        /// <summary>
        /// Display a message to the user.
        /// This method may be called from any thread.
        /// </summary>
        /// <param name="strMessage"></param>
        /// <param name="type"></param>
        public void NotifyUser(string strMessage, NotifyType type)
        {
            // If called from the UI thread, then update immediately.
            // Otherwise, schedule a task on the UI thread to perform the update.
            if (Dispatcher.HasThreadAccess)
            {
                UpdateStatus(strMessage, type);
            }
            else
            {
                var task = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => UpdateStatus(strMessage, type));
            }
        }

        private void UpdateStatus(string strMessage, NotifyType type)
        {
            switch (type)
            {
                case NotifyType.StatusMessage:
                    StatusBorder.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    break;
                case NotifyType.ErrorMessage:
                    StatusBorder.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    break;
            }

            StatusBlock.Text = strMessage;

            // Collapse the StatusBlock if it has no text to conserve real estate.
            StatusBorder.Visibility = (StatusBlock.Text != String.Empty) ? Visibility.Visible : Visibility.Collapsed;
            if (StatusBlock.Text != String.Empty)
            {
                StatusBorder.Visibility = Visibility.Visible;
                StatusPanel.Visibility = Visibility.Visible;
            }
            else
            {
                StatusBorder.Visibility = Visibility.Collapsed;
                //StatusPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void SearchAutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {

        }
    }
    public enum NotifyType
    {
        StatusMessage,
        ErrorMessage
    };
}
