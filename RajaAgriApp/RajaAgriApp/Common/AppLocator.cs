using Autofac;
using Database;
using RajaAgriApp.Controller;
using RajaAgriApp.Services;
using System;

namespace RajaAgriApp.Common
{
    public class AppLocator
    {
        private static AppLocator _instance;

        public static AppLocator Instance
        {
            get
            {
                return _instance ?? (_instance = new AppLocator());
            }
        }

        private IContainer _container;


        public AppLocator()
        {
            
        }

        public void Register() 
        {

            var builder = new ContainerBuilder();
            builder.RegisterType<AuthenticatClientHelper>().As<IClientHelper>();
            builder.RegisterType<ApiHelper>().As<IApiHelper>();

            builder.RegisterType<LoginService>().As<ILoginService>();
            builder.RegisterType<LoginController>().As<ILoginController>();

            builder.RegisterType<FarmerRegisterService>().As<IFarmerRegisterService>();
            builder.RegisterType<FarmerRegisterController>().As<IFarmerRegisterController>();


            builder.RegisterType<HomeService>().As<IHomeService>();
            builder.RegisterType<HomeController>().As<IHomeController>();

            builder.RegisterType<ProductDetailsService>().As<IProductDetailsService>();
            builder.RegisterType<ProductDetailsController>().As<IProductDetailsController>();


            builder.RegisterType<DealerService>().As<IDealerService>();
            builder.RegisterType<DealerController>().As<IDealerController>();

            builder.RegisterType<ReviewService>().As<IReviewService>();
            builder.RegisterType<ReviewController>().As<IReviewController>();

            builder.RegisterType<ProductTypeService>().As<IProductTypeService>();
            builder.RegisterType<ProductRegisterService>().As<IProductRegisterService>();
            builder.RegisterType<ProductRegisterController>().As<IProductRegisterController>();


            
            builder.RegisterType<NewServiceRequestService>().As<INewServiceRequestService>();
            builder.RegisterType<TypeOfProblemService>().As<ITypeOfProblemService>();
            builder.RegisterType<NewServicRequestController>().As<INewServicRequestController>();

            builder.RegisterType<ServiceRequestService>().As<IServiceRequestService>();
            builder.RegisterType<ServicRequestController>().As<IServicRequestController>();
            
            // builder.RegisterType<CompanyDbRepo>().AsSelf();


            _container = builder.Build();

          
            Console.ReadLine();
        }

        public T GetInstance<T>()where T:class
        {
            return _container.Resolve<T>();
        }
    }
}
