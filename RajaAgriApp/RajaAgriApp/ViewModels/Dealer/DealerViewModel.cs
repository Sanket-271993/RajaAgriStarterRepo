using RajaAgriApp.Common;
using RajaAgriApp.Controller;
using RajaAgriApp.Models;
using RajaAgriApp.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    public class DealerViewModel : BaseViewModel
    {
        private IDealerController _dealerController;

        private ObservableCollection<DealerModel> _dealers;
        public ObservableCollection<DealerModel> Dealers
        { 
            get { return _dealers; } 
            set { SetProperty(ref _dealers, value); } 
        }
        public ICommand OnItemCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public DealerViewModel()
        {
            SetTitle();
            InitController();
            InitCommand();
            //GetDealerDetails();
        }

        private void SetTitle()
        {
            Title = AppResource.TitleDealers;
            IsMenuVisable = false;
            IsTranslateVisable = true;
        }
        private void InitCommand()
        {
            OnItemCommand = new Command<DealerModel>(OnItemClick);
            SearchCommand = new Command(OnSearchClick);
        }

        private void OnSearchClick(object obj)
        {
           //
        }

        private void InitController()
        {
            _dealerController = AppLocator.Instance.GetInstance<IDealerController>();
        }

        private void OnItemClick(DealerModel obj)
        {
            //
        }

        private void GetDealerDetails()
        {
            List<DealerModel> _dealerModels = new List<DealerModel>();
            _dealerModels.Add(new DealerModel() { DealerId = 1, DealerName = "Raj Kumar", PhoneNumber = "1234567890", Rating = 1 });
            _dealerModels.Add(new DealerModel() { DealerId = 2, DealerName = "Sanket Kumar", PhoneNumber = "1234567890", Rating = 1 });
            _dealerModels.Add(new DealerModel() { DealerId = 3, DealerName = "Jyoti Kumari", PhoneNumber = "1234567890", Rating = 1 });
            _dealerModels.Add(new DealerModel() { DealerId = 4, DealerName = "Raj Kumar", PhoneNumber = "1234567890", Rating = 1 });
            _dealerModels.Add(new DealerModel() { DealerId = 5, DealerName = "Suraj Kumar", PhoneNumber = "1234567890", Rating = 1 });

            Dealers = new ObservableCollection<DealerModel>(_dealerModels);
        }

        

        public async void GetDealerServiceCall()
        {
            try
            {
                if (IsConnected)
                {

                    AppIndicater.Instance.Show();
                    var response = await _dealerController.GetDealer();
                     AppIndicater.Instance.Dismiss();
                    if (response != null && response.Distributors?.Count > 0)
                    {
                        Dealers = new ObservableCollection<DealerModel>(response.Distributors);
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
