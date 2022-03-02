using RajaAgriApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RajaAgriApp.TempleteSelector
{
    public class DropDownTempleteSelector : DataTemplateSelector
    {
        public DataTemplate CheckBoxItemTemplate { get; set; }
        public DataTemplate DropDownItemTemplate { get; set; }


        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((DropDownModel)item).IsCheckBoxItem ? CheckBoxItemTemplate : DropDownItemTemplate;
        }
    }
}
