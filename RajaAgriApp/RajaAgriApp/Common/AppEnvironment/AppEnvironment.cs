using System;
using System.Collections.Generic;
using System.Text;

namespace RajaAgriApp.Common
{
    public class AppEnvironment
    {
        //New Url
        public readonly static string BASE_API_URL_DEV = "https://www.payrec.siemens.co.in/RajaAgriAPI/api/data/";//dev
        //QA
        public readonly static string BASE_API_URL_QA = "https://www.payrec.siemens.co.in/RajaAgriAPI/api/data/";//Qa
        //New Prod
        public readonly static string BASE_API_URL_PROD = "https://www.payrec.siemens.co.in/RajaAgriAPI/api/data/";//prod

        public readonly static string BASE_API_URL_Token = "https://www.payrec.siemens.co.in/RajaAgriAPI/";//prod
    }
}
