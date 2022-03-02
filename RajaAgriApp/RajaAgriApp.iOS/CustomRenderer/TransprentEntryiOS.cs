using Foundation;
using RajaAgriApp.CustomControl;
using RajaAgriApp.iOS.CustomRenderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TransprantEntry), typeof(TransprentEntryiOS))]
namespace RajaAgriApp.iOS.CustomRenderer
{
    public class TransprentEntryiOS:EntryRenderer
    {
        public TransprentEntryiOS()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if(Control!=null)
            {
                Control.BackgroundColor=UIColor.FromCGColor(Color.Transparent.ToCGColor()); 
            }
        }
    }
}