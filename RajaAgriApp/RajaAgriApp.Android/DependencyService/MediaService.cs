using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RajaAgriApp.AppDependencyService;
using RajaAgriApp.Droid.DependencyService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using static Xamarin.Essentials.Permissions;
using Environment = System.Environment;

[assembly: Xamarin.Forms.Dependency(typeof(MediaService))]
namespace RajaAgriApp.Droid.DependencyService
{
    public class MediaService : IMediaService
    {
        Context CurrentContext => Platform.CurrentActivity;
        public async void SaveImageFromByte(byte[] imageByte, string filename)
        {
            try
            {
                var status = await CheckAndRequestPermissionAsync(new ReadWriteStoragePermission());
                if (status == PermissionStatus.Granted)
                {

                    string documentsPath = Android.OS.Environment.DirectoryPictures;

                    //var partedURL = URL.Split('/');

                    //  var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory), filename);

                    // string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures), filename);
                    //Java.IO.File storagePath = Context.StorageService(Android.OS.Environment.DirectoryPictures).
                    //  Java.IO.File storagePath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures);
                    //  Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
                    Java.IO.File path = GetPdfPath(filename);
                     File.WriteAllBytes(path.Path, imageByte);
                    //var mediaScanIntent = new Intent(Intent.ExtraIntent);
                   // mediaScanIntent.SetData(Android.Net.Uri.FromFile(new Java.IO.File(path)));
                    //CurrentContext.SendBroadcast(mediaScanIntent);
                }
                else
                {
                    //Denie
                    //IsPermission = false;
                    AppInfo.ShowSettingsUI();
                }

            }
            catch (Exception ex)
            {

            }
        }

        public static Java.IO.File GetPdfPath(string filename)
        {
            string path = Android.OS.Environment.DirectoryPictures;
            Java.IO.File file = new Java.IO.File(path, filename);
            return file;
        }


        public class ReadWriteStoragePermission : Xamarin.Essentials.Permissions.BasePlatformPermission
        {
            public override (string androidPermission, bool isRuntime)[] RequiredPermissions => new List<(string androidPermission, bool isRuntime)>
           {
                    (Android.Manifest.Permission.ReadExternalStorage, true),
                    (Android.Manifest.Permission.WriteExternalStorage, true)
            }.ToArray();
        }

        public async Task<PermissionStatus> CheckAndRequestPermissionAsync<T>(T permission)
                  where T : BasePermission
        {
            var status = await permission.CheckStatusAsync();
            if (status != PermissionStatus.Granted)
            {
                status = await permission.RequestAsync();
            }

            return status;
        }


       
    }

}