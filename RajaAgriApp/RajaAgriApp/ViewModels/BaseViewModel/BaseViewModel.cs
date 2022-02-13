using RajaAgriApp.Models;
using RajaAgriApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace RajaAgriApp.ViewModels
{
    public class BaseViewModel : BaseNotifyPropertyChanged
    {
       

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        bool _isMenuVisable = false;
        public bool IsMenuVisable
        {
            get { return _isMenuVisable; }
            set { SetProperty(ref _isMenuVisable, value); }
        }

        bool _isTranslateVisable = true;
        public bool IsTranslateVisable
        {
            get { return _isTranslateVisable; }
            set { SetProperty(ref _isTranslateVisable, value); }
        }


        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public ICommand MultiLanguageCommand { get; set; }

        public BaseViewModel()
        {
            InitCommand();
        }

        private void InitCommand()
        {
            MultiLanguageCommand = new Command(OnMultiLanguageClick);
        }

        private void OnMultiLanguageClick(object obj)
        {
            //
        }
    }


    
}
