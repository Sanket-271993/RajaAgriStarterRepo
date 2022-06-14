using RajaAgriApp.Common;

namespace RajaAgriApp.Common
{
    public class ServiceUrl
    {
        public static readonly string Token = URLEnvironment.TokenConnection + ServiceName.Token;
      //  public static readonly string Login = URLEnvironment.Connection + ServiceName.Login;
        public static readonly string FarmerRegister = URLEnvironment.Connection + ServiceName.RegisterFarmer;
        public static readonly string Home = URLEnvironment.Connection + ServiceName.Home;
        public static readonly string ProductDetail = URLEnvironment.Connection + ServiceName.ProductDetail;
        public static readonly string Dealer = URLEnvironment.Connection + ServiceName.Dealer;
        public static readonly string ProductRating = URLEnvironment.Connection + ServiceName.ProductRating;
        public static readonly string RegisterProduct = URLEnvironment.Connection + ServiceName.RegisterProduct;
        public static readonly string ProductType = URLEnvironment.Connection + ServiceName.ProductType;
        public static readonly string RequestStatus = URLEnvironment.Connection + ServiceName.RequestStatus;
        public static readonly string CreateNewServiceRequest = URLEnvironment.Connection + ServiceName.CreateNewServiceRequest;
        public static readonly string ProblemTypes = URLEnvironment.Connection + ServiceName.ProblemTypes;
        public static readonly string OrderHistory = URLEnvironment.Connection + ServiceName.OrderHistory;

    }
}
