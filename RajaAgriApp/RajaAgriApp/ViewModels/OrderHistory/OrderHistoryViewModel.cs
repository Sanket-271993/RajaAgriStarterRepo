using RajaAgriApp.AppDependencyService;
using RajaAgriApp.Common;
using RajaAgriApp.Controller;
using RajaAgriApp.Models;
using RajaAgriApp.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace RajaAgriApp.ViewModels
{
    public class OrderHistoryViewModel:BaseViewModel
    {
        private IOrderHistoryController _orderHistoryController;


        private ObservableCollection<HistoryOrderModel> _historyOrderModels;
        public ObservableCollection<HistoryOrderModel> OrderHistorys
        {
            get { return _historyOrderModels; }
            set { SetProperty(ref _historyOrderModels, value); }
        }
        public ICommand OnInvoiceDownloadCommand { get; set; }
        public OrderHistoryViewModel()
        {
            InitController();
            InitCommand();
            SetTitle();
        }

        private void SetTitle()
        {
            Title = AppResource.TitlePurchaseHistory;
            IsMenuVisable = false;
            IsTranslateVisable = true;
        }
        private void InitCommand()
        {
            OnInvoiceDownloadCommand = new Command<HistoryOrderModel>(OnInvoiceDownloadClick);
           
        }

        private void OnInvoiceDownloadClick(HistoryOrderModel  historyOrder)
        {
            if(!string.IsNullOrEmpty(historyOrder.InvoiceImage))
            {
                ConverBase64ToImage(historyOrder.InvoiceImage);
                SetSnackBarMessage("Download Successfully!");
            }
            else
            {
                SetAlertPopup("Invoice not available!");
            }
        }

        private void InitController()
        {
            _orderHistoryController=AppLocator.Instance.GetInstance<IOrderHistoryController>();
        }


       

        public async void SetOrderHistoryServiceCall()
        {
            try
            {
                if (IsConnected)
                {

                    AppIndicater.Instance.Show();
                    var response = await _orderHistoryController.GetOrderHistory();
                    AppIndicater.Instance.Dismiss();
                    if (response != null && response.Products?.Count > 0)
                    {
                        OrderHistorys = new ObservableCollection<HistoryOrderModel>(response.Products);
                    }
                    else
                    {
                        SetAlertPopup("Order History not found!");
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

       
        public async void ConverBase64ToImage(string base64BinaryStr)
        {
            try
            {
                byte[] imageByte = Convert.FromBase64String(base64BinaryStr);

                //  string directory = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, Android.OS.Environment.DirectoryDownloads);

             // await  DownloadPdfFileAsync(imageByte, "Product_Invoice.jpg");
                DependencyService.Get<IMediaService>().SaveImageFromByte(imageByte, "Product_Invoice.jpg");
                //string documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures));
                //string localFilename = "Product_Invoice.jpg";
                //string localPath = Path.Combine(documentsPath, localFilename);
               // File.WriteAllBytes(localPath, imageByte);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        private async Task<string> DownloadPdfFileAsync(byte[] imageByte, string fileName)
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);

            if (File.Exists(filePath))
                return filePath;

            //var httpClient = new HttpClient();
           // var pdfBytes = await httpClient.GetByteArrayAsync("ENTER YOUR URL TO THE PDF FILE HERE");

            try
            {
                File.WriteAllBytes(filePath, imageByte);

                return filePath;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }

            return null;
        }

    }
}
