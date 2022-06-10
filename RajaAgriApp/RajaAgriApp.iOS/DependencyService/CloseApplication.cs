using Foundation;
using RajaAgriApp.AppDependencyService;
using RajaAgriApp.iOS.DependencyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UIKit;
[assembly: Xamarin.Forms.Dependency(typeof(CloseApplication))]
namespace RajaAgriApp.iOS.DependencyService
{
    public class CloseApplication : ICloseApplication
    {
        public void CloseApp()
        {
            Thread.CurrentThread.Abort();
        }
    }
}