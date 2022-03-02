using NavistarOCCApp.Common;
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
    public class ServiceRequestViewModel:BaseViewModel
    {
        public ObservableCollection<ServiceRequestModel> ServiceRequests { get; set; }
        private bool _isExistingRequest;

        public bool IsExistingRequest
        {
            get { return _isExistingRequest; }
            set { SetProperty(ref _isExistingRequest, value); }
        }
       
         public ICommand OnNewRequestCommand { get; set; }
        public ServiceRequestViewModel()
        {
            Title = AppResource.TitleServiceRequest;
            IsTranslateVisable = true;
            InitCommand();
            GetExistingRequestData();
        }

        private void InitCommand()
        {
            OnNewRequestCommand = new Command(OnNewRequestClick);
        }

        private async void OnNewRequestClick(object obj)
        {
            await ShellRoutingService.Instance.NavigateTo($"{nameof(NewServiceRequestPage)}");
        }
       
        private void GetExistingRequestData()
        {
            List<ServiceRequestModel> serviceRequests = new List<ServiceRequestModel>
            {
                new ServiceRequestModel()
                {
                    ProductName = "FASD2 Starter",
                    ProductProblem = "Weld issue",
                    RequestNumber = "02220202022020",
                    RequestStatus = "Pending",
                    SerialNumber = "252525",
                    RequestTime=DateTime.Now.ToShortDateString()
                    
                },
                new ServiceRequestModel()
                {
                    ProductName = "FASD2 Starter",
                    ProductProblem = "Weld issue",
                    RequestNumber = "02220202022020",
                    RequestStatus = "Pending",
                    SerialNumber = "252525",
                      RequestTime=DateTime.Now.ToShortDateString()
                },
                new ServiceRequestModel()
                {
                    ProductName = "FASD2 Starter",
                    ProductProblem = "Weld issue",
                    RequestNumber = "02220202022020",
                    RequestStatus = "Pending",
                    SerialNumber = "252525",
                      RequestTime=DateTime.Now.ToShortDateString()
                }
            };
            ServiceRequests = new ObservableCollection<ServiceRequestModel>(serviceRequests);
        }
    }
}
