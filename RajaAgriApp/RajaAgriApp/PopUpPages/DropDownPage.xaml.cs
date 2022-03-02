using RajaAgriApp.Common;
using RajaAgriApp.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RajaAgriApp.PopUpPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DropDownPage : PopupPage
    {
        public event EventHandler ItemSelectionClick;
        public ObservableCollection<DropDownModel> DropDownDataList { get; set; }
        private DropDownType _dropDownType;

        private List<DropDownModel> _dropDownModels;
        private int _margin;

        public int Margin
        {
            get
            {
                return _margin;
            }
            set
            {
                _margin = value;
                OnPropertyChanged(nameof(Margin));  
            }
        }


    
       

        public DropDownPage(List<DropDownModel> DataSource,DropDownType dropDownType)
        {

            InitializeComponent();
            _dropDownModels = DataSource;
            SetDropDownData();
            Margin= (int)dropDownType;
            _dropDownType = dropDownType;
            this.BindingContext = this;
           
        }

       
        private void SetDropDownData()
        {
            if (_dropDownModels != null)
            {
                DropDownDataList = new ObservableCollection<DropDownModel>(_dropDownModels);
            }

        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            DropDownModel DropDownItem = (DropDownModel)(((TappedEventArgs)e).Parameter);
            SetAllUnSelected();
            DropDownItem.IsSelectedItem = !DropDownItem.IsSelectedItem;
            ItemSelectionClick.Invoke(this, new DropDownEventArg() {DropDownType=_dropDownType, SelectedData=DropDownItem});
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

        private void CheckBoxItem_Tapped(object sender, EventArgs e)
        {
            //DropDownModel DropDownItem = (DropDownModel)(((TappedEventArgs)e).Parameter);
            //SetAllUnSelected();
            //DropDownItem.IsSelectedItem = !DropDownItem.IsSelectedItem;
            //ItemSelectionClick.Invoke(this, new DropDownEventArg() { DropDownType = _dropDownType, SelectedData = DropDownItem });
            //Dismiss();
        }

        //private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        //{
        //     TapGestureRecognizer_Tapped(sender, System.EventArgs e)

        //    var checkItem = (((CheckedChangedEventArgs)e).);
        //    SetAllUnSelected();
        //    DropDownItem.IsSelectedItem = ((CheckedChangedEventArgs)e).Value;
        //    ItemSelectionClick.Invoke(this, new DropDownEventArg() { DropDownType = _dropDownType, SelectedData = DropDownItem });
        //    Dismiss();
        //}
    }
}