using System.Collections.Specialized;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Common.Logging;
using Common.Logging.Log4Net;
using CommonServiceLocator.SpringAdapter;
using log4net.Config;
using Microsoft.Practices.ServiceLocation;
using MvcContrib.ControllerFactories;
using MvcContrib.Services;
using MvcContrib.Spring;
using Spring.Context.Support;

namespace SpringWorkshop.CrossCutting.Bootstrapping
{
    public class StartUp
    {
        public static void Init()
        {
            ConfigureRoutes();
            ConfigureDependencies();
            ConfigureLogging();
        }

        private static void ConfigureRoutes()
        {
            AreaRegistration.RegisterAllAreas();
            RouteCollection routes = RouteTable.Routes;
            routes.Clear();
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );

        }

        private static void ConfigureDependencies()
        {
            WebApplicationContext webApplicationContext = ContextRegistry.GetContext() as WebApplicationContext;
            DependencyResolver.InitializeWith(new SpringDependencyResolver(webApplicationContext));
            ControllerBuilder.Current.SetControllerFactory(typeof(IoCControllerFactory));
            
            ServiceLocator.SetLocatorProvider(() => new SpringServiceLocatorAdapter(webApplicationContext));
        }

        private static void ConfigureLogging()
        {
            NameValueCollection properties = new NameValueCollection();
            properties["configType"] = "EXTERNAL";
            LogManager.Adapter = new Log4NetLoggerFactoryAdapter(properties);

            Assembly assembly = Assembly.GetExecutingAssembly();
            System.IO.Stream stream = assembly.GetManifestResourceStream("SpringWorkshop.CrossCutting.Logging.Log4Net.xml");
            XmlConfigurator.Configure(stream);
        }
    }
}
