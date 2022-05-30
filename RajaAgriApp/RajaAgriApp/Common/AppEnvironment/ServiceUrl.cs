﻿using RajaAgriApp.Common;

namespace RajaAgriApp.Common
{
    public class ServiceUrl
    {
        public static readonly string Token = URLEnvironment.TokenConnection + ServiceName.Token;
      //  public static readonly string Login = URLEnvironment.Connection + ServiceName.Login;
        public static readonly string FarmerRegister = URLEnvironment.Connection + ServiceName.RegisterFarmer;
    }
}
