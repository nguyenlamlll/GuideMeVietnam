using Source.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TravelGuide.Utilities;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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
        public static Geopoint Location = null;
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
            Location = point;
            FillGeopointLocation(point);

            JournalRelativePanel.Visibility = Visibility.Collapsed;
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

        private async void AddJournalButton_Checked(object sender, RoutedEventArgs e)
        {
            // JournalRelativePanel.Visibility = Visibility.Visible;
            // this.Height += 10;
            // this.Height += JournalRelativePanel.Height;

            // Open Text Editor Window.
            var currentAV = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            var newAV = Windows.ApplicationModel.Core.CoreApplication.CreateNewView();
            await newAV.Dispatcher.RunAsync(
                            Windows.UI.Core.CoreDispatcherPriority.Normal,
                            async () =>
                            {
                                var newWindow = Window.Current;
                                var newAppView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
                                newAppView.Title = "Journal Editor";

                                var frame = new Frame();
                                frame.Navigate(typeof(TextEditorPage), Location);
                                newWindow.Content = frame;
                                newWindow.Activate();

                                await Windows.UI.ViewManagement.ApplicationViewSwitcher.TryShowAsStandaloneAsync(
                                    newAppView.Id,
                                    Windows.UI.ViewManagement.ViewSizePreference.UseMinimum,
                                    currentAV.Id,
                                    Windows.UI.ViewManagement.ViewSizePreference.UseMinimum);
                            });
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
            if (selectedText != null)
            {
                Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                charFormatting.Bold = Windows.UI.Text.FormatEffect.Toggle;
                selectedText.CharacterFormat = charFormatting;
            }
        }

        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
            if (selectedText != null)
            {
                Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                charFormatting.Italic = Windows.UI.Text.FormatEffect.Toggle;
                selectedText.CharacterFormat = charFormatting;
            }
        }

        private void UnderlineButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
            if (selectedText != null)
            {
                Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                if (charFormatting.Underline == Windows.UI.Text.UnderlineType.None)
                {
                    charFormatting.Underline = Windows.UI.Text.UnderlineType.Single;
                }
                else
                {
                    charFormatting.Underline = Windows.UI.Text.UnderlineType.None;
                }
                selectedText.CharacterFormat = charFormatting;
            }
        }

        private async void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            // Open a text file.
            Windows.Storage.Pickers.FileOpenPicker open =
                new Windows.Storage.Pickers.FileOpenPicker();
            open.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            open.FileTypeFilter.Add(".rtf");

            Windows.Storage.StorageFile file = await open.PickSingleFileAsync();

            if (file != null)
            {
                try
                {
                    Windows.Storage.Streams.IRandomAccessStream randAccStream =
                await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

                    // Load the file into the Document property of the RichEditBox.
                    editor.Document.LoadFromStream(Windows.UI.Text.TextSetOptions.FormatRtf, randAccStream);
                }
                catch (Exception)
                {
                    ContentDialog errorDialog = new ContentDialog()
                    {
                        Title = "File open error",
                        Content = "Sorry, I couldn't open the file.",
                        PrimaryButtonText = "Ok"
                    };

                    await errorDialog.ShowAsync();
                }
            }
        }

        private async void SaveAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Storage.Pickers.FileSavePicker savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;

            // Dropdown of file types the user can save the file as
            savePicker.FileTypeChoices.Add("Rich Text", new List<string>() { ".rtf" });

            // Default file name if the user does not type one in or select a file to replace
            savePicker.SuggestedFileName = "New Document";

            Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                // Prevent updates to the remote version of the file until we
                // finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(file);
                // write to file
                Windows.Storage.Streams.IRandomAccessStream randAccStream =
                    await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);

                editor.Document.SaveToStream(Windows.UI.Text.TextGetOptions.FormatRtf, randAccStream);

                // Let Windows know that we're finished changing the file so the
                // other app can update the remote version of the file.
                Windows.Storage.Provider.FileUpdateStatus status = await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
                if (status != Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    Windows.UI.Popups.MessageDialog errorBox =
                        new Windows.UI.Popups.MessageDialog("File " + file.Name + " couldn't be saved.");
                    await errorBox.ShowAsync();
                }
            }
        }

        private void editor_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            /*
            if (e.Key == Windows.System.VirtualKey.Space)
            {
                string currentText = null;
                editor.Document.GetText(Windows.UI.Text.TextGetOptions.None, out currentText);
                editor.Document.SetText(Windows.UI.Text.TextSetOptions.None, currentText + " ");
            }
            */
        }
        // Open text editor that allows user to write the location's journal.
        // Save in a separated file with 3 lines: Latitude, Longitude, and The journal itself.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteIconButton_Click(object sender, RoutedEventArgs e)
        {
            MapIconDeleting?.Invoke(sender, Location);

        }

        public static event TypedEventHandler<object, Geopoint> MapIconDeleting;


        /// <summary>
        /// Get all locations into a list. 
        /// Delete current location from the list then overwrite the file with newly created list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DeleteLocationButton_Click(object sender, RoutedEventArgs e)
        {
            List<PlaceInfo> list = await ApplicationMapManager.LoadPlaceInfo(Models.DefaultFile.UserPlaces);
            List<PlaceInfo> storedList = list;
            foreach (PlaceInfo place in list)
            {
                //Delete this location from the list
                if (place.Location.Geopoint.Position.Latitude == Location.Position.Latitude &&
                    place.Location.Geopoint.Position.Longitude == Location.Position.Longitude)
                {
                    list.Remove(place);
                    Utilities.LocalDataAccess.WriteToLocalFolder(Models.DefaultFile.UserPlaces, ""); //Overwrite current file with an empty one.
                    string stringToAppend = string.Empty;

                    await list.ForEachAsync(async i =>
                    {
                        await Utilities.LocalDataAccess.AppendAsync(i.Name + "\n" + i.Location.Geopoint.Position.Latitude + "\n" +
                            i.Location.Geopoint.Position.Longitude + "\n", Models.DefaultFile.UserPlaces);
                    });

                    DeleteIconButton_Click(sender, e);
                    break;
                }
            }
        }

    }
}
