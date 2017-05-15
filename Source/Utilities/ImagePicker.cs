using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace Source.Utilities
{
    class ImagePicker
    {
        public async void SaveAnImage()
        {

            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                
            }
            else
            {
            }
        }

        public static async Task<WriteableBitmap> GetProfilePictureAsync(string userId)
        {
            StorageFolder pictureFolder = await ApplicationData.Current.LocalFolder.GetFolderAsync("ProfilePictures");
            StorageFile pictureFile = await pictureFolder.GetFileAsync(userId + ".jpg");

            using (IRandomAccessStream stream = await pictureFile.OpenAsync(FileAccessMode.Read))
            {
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                WriteableBitmap bmp = new WriteableBitmap((int)decoder.PixelWidth, (int)decoder.PixelHeight);

                await bmp.SetSourceAsync(stream);

                return bmp;
            }
        }

        public static async Task SaveBitmapToFileAsync(WriteableBitmap image, string userId = "tempUser")
        {
            StorageFolder pictureFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("ProfilePictures", CreationCollisionOption.OpenIfExists);
            var file = await pictureFolder.CreateFileAsync(userId + ".jpg", CreationCollisionOption.ReplaceExisting);

            using (var stream = await file.OpenStreamForWriteAsync())
            {
                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream.AsRandomAccessStream());
                var pixelStream = image.PixelBuffer.AsStream();
                byte[] pixels = new byte[bmp.PixelBuffer.Length];

                await pixelStream.ReadAsync(pixels, 0, pixels.Length);

                encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)image.PixelWidth, (uint)image.PixelHeight, 96, 96, pixels);

                await encoder.FlushAsync();
            }
        }
    }
}
