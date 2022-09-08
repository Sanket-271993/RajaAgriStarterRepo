using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RajaAgriApp.PopUpPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraAndFilePickerPopupPage : PopupPage
    {
        public event EventHandler CameraClick;
        public event EventHandler PickerClick;

        public CameraAndFilePickerPopupPage()
        {
            InitializeComponent();
        }

        private void Camera_Click(object sender, EventArgs e)
        {
            Dismiss();
            CameraClick.Invoke(this, e);
        }
        private void File_Click(object sender, EventArgs e)
        {
            Dismiss();
            PickerClick.Invoke(this, e);
        }

        public async void Dismiss()
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}