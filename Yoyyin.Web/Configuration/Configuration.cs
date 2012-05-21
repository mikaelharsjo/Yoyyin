using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;

namespace Yoyyin.Web.Configuration
{
    public static class Configuration
    {
        static Configuration()
        {
            // Build up your application container and register your dependencies.
            var builder = new ContainerBuilder();

            // Make sure MVC part of site works
            builder.RegisterControllers(typeof(Configuration).Assembly);

            // Register MVC infrastructure
            builder.RegisterModule(new AutofacWebTypesModule());

            builder.RegisterModule<YoyyinModule>();

            Container = builder.Build();
        }

        public static IContainer Container { get; private set; }
    }
}