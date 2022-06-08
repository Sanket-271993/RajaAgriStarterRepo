using RajaAgriApp.Common;
using RajaAgriApp.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RajaAgriApp.PopUpPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DownloadPopUpPage : PopupPage
    {
        public event EventHandler ItemSelectionClick;
        private ObservableCollection<DropDownModel> _dropDownDataList;
        public ObservableCollection<DropDownModel> DropDownDataList
        {
            get { return _dropDownDataList; }
            set { _dropDownDataList = value;
                OnPropertyChanged(nameof(DropDownDataList));
            }
        }
        List<DropDownModel> _dropDowns;
        public DownloadPopUpPage(List<DropDownModel> dropDowns)
        {
           
            InitializeComponent();
            _dropDowns = dropDowns;
            DropDownDataList = new ObservableCollection<DropDownModel>(_dropDowns);
            this.BindingContext = this;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DropDownModel DropDownItem = (DropDownModel)(((TappedEventArgs)e).Parameter);
            SetAllUnSelected();
            DropDownItem.IsSelectedItem = !DropDownItem.IsSelectedItem;
            ItemSelectionClick.Invoke(this, new DropDownEventArg() {  SelectedData = DropDownItem });
            Dismiss();
        }

        private void SetAllUnSelected()
        {
            foreach (DropDownModel item in DropDownDataList)
            {
                item.IsSelectedItem = false;
            }
        }
        public async void Dismiss()
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}