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
    public class ServiceRequestViewModel : BaseViewModel
    {
        private IServicRequestController _servicRequestController;
        private ObservableCollection<ServiceRequestModel> _serviceRequests;
        public ObservableCollection<ServiceRequestModel> ServiceRequests
        {
            get { return _serviceRequests; }
            set { SetProperty(ref _serviceRequests, value);}
        }
        private bool _isExistingRequest=true;

        public bool IsExistingRequestShow
        {
            get { return _isExistingRequest; }
            set { SetProperty(ref _isExistingRequest, value); }
        }

        public ICommand OnNewRequestCommand { get; set; }
        public ServiceRequestViewModel()
        {
            Title = AppResource.TitleServiceRequest;
            IsTranslateVisable = true;
            InitController();
            InitCommand();
            
        }


        private void InitController()
        {
            _servicRequestController = AppLocator.Instance.GetInstance<IServicRequestController>();
        }

        private void InitCommand()
        {
            OnNewRequestCommand = new Command(OnNewRequestClick);
        }

        private async void OnNewRequestClick(object obj)
        {
            await ShellRoutingService.Instance.NavigateTo($"{nameof(NewServiceRequestPage)}");
        }

        public async void GetServicRequestServiceCall()
        {
            try
            {
                if (IsConnected)
                {

                    AppIndicater.Instance.Show();
                    var response = await _servicRequestController.GetServiceRequest();
                    AppIndicater.Instance.Dismiss();
                    if (response != null && response.ServiceRequests?.Count > 0)
                    {
                        IsExistingRequestShow = false;
                        ServiceRequests = new ObservableCollection<ServiceRequestModel>(response.ServiceRequests);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //private void GetExistingRequestData()
        //{
        //    List<ServiceRequestModel> serviceRequests = new List<ServiceRequestModel>
        //    {
        //        new ServiceRequestModel()
        //        {
        //            ProductName = "FASD2 Starter",
        //            ProductProblem = "Weld issue",
        //            RequestNumber = "02220202022020",
        //            RequestStatus = "Pending",
        //            SerialNumber = "252525",
        //            RequestTime=DateTime.Now.ToShortDateString()

        //        },
        //        new ServiceRequestModel()
        //        {
        //            ProductName = "FASD2 Starter",
        //            ProductProblem = "Weld issue",
        //            RequestNumber = "02220202022020",
        //            RequestStatus = "Pending",
        //            SerialNumber = "252525",
        //              RequestTime=DateTime.Now.ToShortDateString()
        //        },
        //        new ServiceRequestModel()
        //        {
        //            ProductName = "FASD2 Starter",
        //            ProductProblem = "Weld issue",
        //            RequestNumber = "02220202022020",
        //            RequestStatus = "Pending",
        //            SerialNumber = "252525",
        //              RequestTime=DateTime.Now.ToShortDateString()
        //        }
        //    };
        //    ServiceRequests = new ObservableCollection<ServiceRequestModel>(serviceRequests);
        //}
    }
}
