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
        /// <summary>
        /// App data that survives through application's sessions. Can be backed up by the system.
        /// </summary>
        private static StorageFolder localFolder = ApplicationData.Current.LocalFolder;

        /// <summary>
        /// App data that you want persisted across app sessions, but that should not be backed up by the system.
        /// </summary>
        private static StorageFolder localCacheFolder = ApplicationData.Current.LocalCacheFolder;
      
        private static StorageFolder roamingFolder = ApplicationData.Current.RoamingFolder;

        private static ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        /// <summary>
        /// Temporary Folder is subject to change when the application is not in use. Use with caution!
        /// Don't save anything valuable here.
        /// </summary>
        private static StorageFolder temporaryFolder = ApplicationData.Current.TemporaryFolder;

        public static async Task<bool> IsExisted(string fileName = "")
        {
            try
            {
                StorageFile stream = await localFolder.GetFileAsync(fileName);
                if (stream != null) return true;
            }
            catch
            {
                return false;
            }
            return false;
        }


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
        /// Read first line from a file in Local Folder.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static async Task<string> ReadLineFromLocalFolder(string fileName = "default.txt")
        {
            StorageFile sampleFile = await localFolder.GetFileAsync(fileName);
            string fileContent = await FileIO.ReadTextAsync(sampleFile);
            return fileContent;
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
                if (stream != null) await FileIO.AppendTextAsync(stream, text);
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
                foreach (StorageFile file in await localFolder.GetFilesAsync())
                {
                    if (file.Name == Models.DefaultFile.UserActivities) continue;
                    await file.DeleteAsync();
                }
                //await localFolder.DeleteAsync();
                //localFolder = ApplicationData.Current.LocalFolder;
            }
            catch (Exception ex)
            {
                Utilities.Dialog.ShowDialog("Unable to clear settings. This can happen when files are in use.\n"
                    + ex.ToString(), "Error");
            }
        }
        public static async void DeleteAllLocalCacheFolder()
        {
            try
            {
                await localCacheFolder.DeleteAsync();
                localCacheFolder = ApplicationData.Current.LocalCacheFolder;
            }
            catch (Exception ex)
            {
                Utilities.Dialog.ShowDialog("Unable to clear settings. This can happen when files are in use.\n"
                    + ex.ToString(), "Error");
            }
        }

        public static bool IsLocalsettingsExist(string settingName = "")
        {
            var value = localSettings.Values[settingName];
            if (value != null) return true;
            return false;
        }


        /// <summary>
        /// Write an integer to a setting slot in Local.
        /// </summary>
        /// <param name="valueToWrite"></param>
        /// <param name="settingName"></param>
        public static void WriteToLocalSettings(int valueToWrite, string settingName = "")
        {
            var value = localSettings.Values[settingName];
            if (value == null)
            {
                localSettings.Values[settingName] = valueToWrite;
            }
        }

        /// <summary>
        /// If Setting Slot has a value, return that number. If not, return -1.
        /// </summary>
        /// <param name="settingName"></param>
        /// <returns></returns>
        public static int ReadFromLocalSettings(string settingName = "")
        {
            var value = localSettings.Values[settingName];
            if (value != null)
            {
                return (int)value;
            }
            return -1;
        }

        /*
        public static async void DeleteAllLocalSettings()
        {
            //await ApplicationData.Current.ClearAsync(ApplicationDataLocality.Local);
            localSettings.DeleteContainer("");
            localSettings = ApplicationData.Current.LocalSettings;
        }
        */
    }
}
