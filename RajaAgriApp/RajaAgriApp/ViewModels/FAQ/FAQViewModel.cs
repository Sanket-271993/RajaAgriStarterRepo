using RajaAgriApp.Common;
using RajaAgriApp.Controller;
using RajaAgriApp.Models;
using RajaAgriApp.Resources;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    [QueryProperty("FAQCategoryId", "FAQCategoryIdParameter")]
    public class FAQViewModel : BaseViewModel
    {
        private IFAQController _fAQController;

        private ObservableCollection<FAQ> _fAQs;

        public ObservableCollection<FAQ> FAQs
        {
            get { return _fAQs; }
            set
            {
                SetProperty(ref _fAQs, value);
                
            }
        }



        private string _fAQCategoryId;

        public string FAQCategoryId
        {
            get { return _fAQCategoryId; }
            set { SetProperty(ref _fAQCategoryId, value);
                SetFAQServiceCall(Convert.ToInt32(value));
            }
        }

        public FAQViewModel()
        {
            _fAQController = AppLocator.Instance.GetInstance<IFAQController>();
            Title = AppResource.TitleFAQQuestionAndAnswer;
            IsTranslateVisable = false;
        }

        public async void SetFAQServiceCall(int FAQCategoryId)
        {
            try
            {
                if (IsConnected)
                {

                    AppIndicater.Instance.Show();
                    var response = await _fAQController.GetFAQ(FAQCategoryId);
                    AppIndicater.Instance.Dismiss();
                    if (response != null && response.FAQ?.Length > 0)
                    {
                        FAQs = new ObservableCollection<FAQ>(response.FAQ);
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
