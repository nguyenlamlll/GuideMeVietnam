using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Source.Utilities
{
    /// <summary>
    /// Access to LocalFolder, LocalCache and TemporaryFolder.
    /// Documented at: https://blogs.windows.com/buildingapps/2016/05/10/getting-started-storing-app-data-locally/#fa7jDRbilUjtbJdY.97
    /// </summary>
    public static class LocalDataAccess
    {
        private static StorageFolder localFolder = ApplicationData.Current.LocalFolder;

        private static StorageFolder localCacheFolder = ApplicationData.Current.LocalCacheFolder;
      
        private static StorageFolder roamingFolder = ApplicationData.Current.RoamingFolder;
  
        private static StorageFolder temporaryFolder = ApplicationData.Current.TemporaryFolder;

        /// <summary>
        /// Write a new file to Local Folder. Will replace existing file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        public static async void WriteToLocalFolder(string fileName = "default.txt", string text = "Default Sample Text")
        {
            try
            {
                StorageFile sampleFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(sampleFile, text);
            }
            catch (Exception ex)
            {
                Utilities.Dialog.ShowDialog(ex.ToString(), "Error");
            }
        }

        /// <summary>
        /// Append a line of text into a file in Application's LocalFolder
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        public static async void Append(string fileName = "default.txt", string text = "")
        {
            try
            {
                StorageFile stream = await localFolder.GetFileAsync(fileName);
                await FileIO.AppendTextAsync(stream, text);
            }
            catch (Exception ex)
            {
                Utilities.Dialog.ShowDialog(ex.ToString(), "Error");
            }

        }


        public static async void DeleteAllFiles()
        {
            try
            {
                await ApplicationData.Current.ClearAsync();
            }
            catch (Exception ex)
            {
                Utilities.Dialog.ShowDialog("Unable to clear settings. This can happen when files are in use.\n"
                    + ex.ToString(), "Error");
            }
        }

        public static async void DeleteAllLocalFolderFiles()
        {
            try
            {
                await localFolder.DeleteAsync();
            }
            catch (Exception ex)
            {
                Utilities.Dialog.ShowDialog("Unable to clear settings. This can happen when files are in use.\n"
                    + ex.ToString(), "Error");
            }
        }

    }
}
