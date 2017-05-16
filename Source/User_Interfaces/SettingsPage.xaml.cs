using Source.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
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
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            LocalDataAccess.DeleteAllFiles();
            Dialog.ShowDialog("Local Settings Reset! Please restart the application to make new settings apply.");
        }
        public static event EventHandler ResetDataEvent;
        private void ResetDataButton_Click(object sender, RoutedEventArgs e)
        {
            // Delete all files except for UserActivities.txt
            LocalDataAccess.DeleteAllLocalFolderFiles();
            Dialog.ShowDialog("Local Data Reset.");

            // Create all default files.
            ResetDataEvent?.Invoke(this, null);

        }

        private void ChooseMapButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MapManager.ShowDownloadedMapsUI();
            }
            catch (Exception ex)
            {
                Dialog.ShowDialog("Error unknown.\n" + ex.ToString(), "Error");
            }
        }

        private void DefaultLocationButton_Click(object sender, RoutedEventArgs e)
        {

        }

        public static event EventHandler MapThemeChangedToLight;
        public static event EventHandler MapThemeChangedToDark;

        private void MapThemeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = e.AddedItems[0] as ComboBoxItem;
            if (comboBoxItem == null) return;
            var content = comboBoxItem.Content as string;
            if (content != null && content.Equals("Light"))
            {
                // Invoke event. Change map theme to light.
                MapThemeChangedToLight?.Invoke(this, null);
            }
            if (content != null && content.Equals("Dark"))
            {
                // Invoke event. Change map theme to dark.
                MapThemeChangedToDark?.Invoke(this, null);
            }
        }
    }
}
