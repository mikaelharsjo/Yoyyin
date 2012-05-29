using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using FizzWare.NBuilder;
using Kiwi.Prevalence;
using Yoyyin.Importing;
using Yoyyin.Model;
using Yoyyin.Model.Importers;
using Yoyyin.Model.Users;

namespace Yoyyin.Mvc.Configuration
{
    public class UserModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<RepositoryConfiguration>()
                .OnActivating(
                    c =>
                    c.Instance.CommandSerializer = new DependecyInjectingCommandSerializer(c.Instance.CommandSerializer))
                .As<IRepositoryConfiguration>();

            builder.Register(c => new ModelFactory<UserModel>(() => new UserModel())).As<IModelFactory<UserModel>>();

            //builder.RegisterType<UserRepository>()
            //    .OnActivated(c => c.Instance.Path = c.Context.Resolve<HttpServerUtilityBase>().MapPath(@"~\App_Data\yoyyin"))
            //    .As<IUserRepository>(); //.SingleInstance();

            builder.RegisterType<UserImporter>().As<IUserImporter>();
            builder.RegisterType<UserRepository>()
                .OnActivated(c => c.Instance.Path = c.Context.Resolve<HttpServerUtilityBase>().MapPath(@"~\App_Data\users"))
                .As<IUserRepository>() ; //.SingleInstance();
        }
    }
}