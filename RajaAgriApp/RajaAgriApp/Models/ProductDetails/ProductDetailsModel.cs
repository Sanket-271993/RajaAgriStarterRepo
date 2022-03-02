using RajaAgriApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RajaAgriApp.Models
{
    public class ProductDetailsModel
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string ProductName   { get; set; }
    }

    public class DropDownModel:BaseViewModel
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public bool IsCheckBoxItem { get; set; } = false;
        private bool _isSelectedItem;
        public bool  IsSelectedItem 
        {
            get { return _isSelectedItem; }
            set { SetProperty(ref _isSelectedItem, value); }
        }
    }
}
