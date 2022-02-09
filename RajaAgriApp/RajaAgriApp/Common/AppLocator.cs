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
