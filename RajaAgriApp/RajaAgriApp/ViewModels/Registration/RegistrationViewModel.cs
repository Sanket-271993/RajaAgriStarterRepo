using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    public class RegistrationViewModel:BaseViewModel
    {

        public  ICommand FilePickerCommand { get; set; }
        public ICommand OnSubmitCommand { get; set; }

        public new ICommand MultiLanguageCommand { get; set; }

        
        public RegistrationViewModel()
        {
            Title = "Registration Page";
            InitCommand();
        }

        private void InitCommand()
        {
            FilePickerCommand = new Command(FilePickerClick);
            OnSubmitCommand=new Command(OnSubmitClick);
            MultiLanguageCommand = new Command(OnMultiLangClick);
        }

        private void OnMultiLangClick(object obj)
        {
           //
        }

        private void OnSubmitClick(object obj)
        {
           //
        }

        private void FilePickerClick(object obj)
        {
            SetFilePicker();
        }

        private async void SetFilePicker()
        {
            try
            {
                FileData fileData = await CrossFilePicker.Current.PickFile();
                string fileName = fileData.FileName;
                string contents = System.Text.Encoding.UTF8.GetString(fileData.DataArray);

                System.Console.WriteLine("File name chosen: " + fileName);
                System.Console.WriteLine("File data: " + contents);

            }
            catch (Exception e)
            {
                System.Console.WriteLine("Exception choosing file: " + e.ToString());
            }
        }
    }
}
