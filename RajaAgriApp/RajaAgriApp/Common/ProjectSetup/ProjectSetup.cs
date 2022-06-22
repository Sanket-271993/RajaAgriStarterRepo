using Database;
using RajaAgriApp.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace NavistarOCCApp.Common
{
    public class ProjectSetup
    {

        private static ProjectSetup _instance;

        public static ProjectSetup Instance
        {
            get
            {
                return _instance ?? (_instance = new ProjectSetup());
            }
        }


        public void AppSetup()
        {
            InitializeCodeFac();
            AddDatabase();
        }

        private void AddDatabase()
        {
            DatabaseManager _databaseManager = new DatabaseManager( Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)));
            _databaseManager.SetUp();
        }

        /// <summary>
        /// Initialize the codefac
        /// </summary>
        private void InitializeCodeFac()
        {
            AppLocator.Instance.Register();
        }

        

    }
}
