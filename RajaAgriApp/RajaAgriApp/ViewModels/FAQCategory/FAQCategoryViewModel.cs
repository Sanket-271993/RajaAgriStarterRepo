using NavistarOCCApp.Common;
using RajaAgriApp.Common;
using RajaAgriApp.Controller;
using RajaAgriApp.Models;
using RajaAgriApp.Pages;
using RajaAgriApp.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    public class FAQCategoryViewModel:BaseViewModel
    {
        IFAQController _fAQController;
        public ICommand OnItemClick { get; set; }

        private ObservableCollection<Faqcategory> _fAQCategories;
        public ObservableCollection<Faqcategory> FAQCategories
        {
            get {  return _fAQCategories; }
            set { SetProperty(ref _fAQCategories, value); } 
        }


        public FAQCategoryViewModel()
        {
            _fAQController=AppLocator.Instance.GetInstance<IFAQController>();
            InitCommand();
            Title = AppResource.TitleFAQCategories;
            IsTranslateVisable = false;
        }


        private void InitCommand()
        {
            OnItemClick = new Command<Faqcategory>(ItemClick);
        }

        private async void ItemClick(Faqcategory faqcategory)
        {
            await ShellRoutingService.Instance.NavigateTo($"{nameof(FAQPage)}?FAQCategoryIdParameter={faqcategory.FAQCategoryId}");
        }

        public async void SetFAQCategoryServiceCall()
        {
            try
            {
                if (IsConnected)
                {

                    AppIndicater.Instance.Show();
                    var response = await _fAQController.GetFAQCategory();
                    AppIndicater.Instance.Dismiss();
                    if (response != null && response.FAQCategory?.Count > 0)
                    {
                        FAQCategories = new ObservableCollection<Faqcategory>(response.FAQCategory);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
