using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RajaAgriApp.AppDependencyService;
using RajaAgriApp.Droid.DependencyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBarImplement))]
namespace RajaAgriApp.Droid.DependencyService
{
    public class StatusBarImplement: IStatusBarColor
    {
        WindowManagerFlags _originalFlags;
        public void HideStatusBar()
        {
           var currentWindow = GetCurrentWindow();
            var attrs = currentWindow.Attributes;
            _originalFlags = attrs.Flags;
            attrs.Flags |= Android.Views.WindowManagerFlags.Fullscreen;
            currentWindow.Attributes = attrs;
        }
        public void ShowStatusBar()
        {
            var currentWindow = GetCurrentWindow();
            var attrs = currentWindow.Attributes;
            attrs.Flags = _originalFlags;
            currentWindow.Attributes = attrs;
        }
        public void SetColoredStatusBar(string hexColor)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {

                if (Build.VERSION.SdkInt < BuildVersionCodes.M)
                {
                    return;
                }

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCurrentWindow();
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.ParseColor(hexColor));
                });
            }
        }

      

        Window GetCurrentWindow()
        {

            var window = Xamarin.Essentials.Platform.CurrentActivity.Window;

            // clear FLAG_TRANSLUCENT_STATUS flag:
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);

            // add FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS flag to the window
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            return window;
        }

    }
}