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

[assembly: Xamarin.Forms.Dependency(typeof(CloseApplication))]
namespace RajaAgriApp.Droid.DependencyService
{
    public class CloseApplication : ICloseApplication
    {
        public void CloseApp()
        {
            var activity = Platform.CurrentActivity;
            activity.FinishAffinity();
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}