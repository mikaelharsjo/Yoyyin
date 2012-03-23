using System;
using System.Collections.Generic;
using System.Web;
using Autofac;
using Autofac.Integration.Web;
using Yoyyin.Data;
using Yoyyin.Domain;
using Yoyyin.Domain.Services;
using Yoyyin.Web.Helpers;

namespace Yoyyin.Web
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {

        // Provider that holds the application container.
        static IContainerProvider _containerProvider;

        // Instance property that will be used by Autofac HttpModules
        // to resolve and inject dependencies.
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        void Application_Start(object sender, EventArgs e)
        {
            _containerProvider = new ContainerProvider(Configuration.Configuration.Container);

            // Inversion of Control - Container setup
            // Build up your application container and register your dependencies.
            //var builder = new ContainerBuilder();

            //builder.RegisterModule<YoyyinModule>();


            //builder.RegisterType<MultipleMatcher>().As<IMultipleMatcher>();
            
            // Once you're done registering things, we set the container
            // provider up with our registrations.
            //var container = builder.Build();
            //_containerProvider = new ContainerProvider(container);

            var routeHelper = new RouteHelper(new CachedItemProvider<IEnumerable<IUser>>(),
                                              Configuration.Configuration.Container.Resolve<IUserService>());
            routeHelper.AddRoutes();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            var exception = Server.GetLastError();
            string message = exception.Message + "\n" + exception.Source + "\n" + exception.StackTrace + "\n" + exception.TargetSite;

            if (exception.InnerException == null) return;
            if (!exception.InnerException.Message.Contains("File does not exist") &&
                exception.GetType() != typeof (HttpUnhandledException) &&
                exception.InnerException.GetType() != typeof (HttpUnhandledException))
            {
                message += "\n" + exception.InnerException.Message;
                var mailHelper = new MailHelper();
                mailHelper.SendErrorMail(message);
            }
        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }
    }
}
