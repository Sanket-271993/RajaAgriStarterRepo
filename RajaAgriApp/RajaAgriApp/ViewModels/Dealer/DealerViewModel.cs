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
    public class DealerViewModel:BaseViewModel
    {
       public ObservableCollection<DealerModel> Dealers { get; set; }
       public ICommand OnItemCommand { get; set; }
        public DealerViewModel()
        {
            SetTitle();
            InitCommand();
            GetDealerDetails();
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
    }
}
