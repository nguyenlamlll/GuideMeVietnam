using Source.Utilities;
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
    }
}
