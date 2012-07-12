using System.Web;
using System.Web.Mvc;
using Autofac;
using Kiwi.Prevalence;
using Yoyyin.Importing;
using Yoyyin.Model.Importers;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.Commands;
using Yoyyin.Mvc.Models;
using Yoyyin.Mvc.Providers.Markup;

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
                    c.Instance.CommandSerializer = new CommandSerializer()
                                                    .WithTypeAlias<AddUserCommand>("addUser")
                                                    .WithTypeAlias<AddUserTypeCommand>("addUserType")
                                                    .WithTypeAlias<AddSniHeadCommand>("addSni")
                                                    .WithTypeAlias<UpdateUserCommand>("updateUser"))
                                                    .As<IRepositoryConfiguration>();

            builder.Register(c => new ModelFactory<UserModel>(() => new UserModel())).As<IModelFactory<UserModel>>();

            builder.RegisterType<UserImporter>().As<IUserImporter>();

            builder.RegisterType<UserRepository>()
                            .OnActivated(
                                c => c.Instance.Path = DependencyResolver.Current.GetService<HttpRequestBase>().MapPath(@"~\App_Data\users"))
                            .As<IUserRepository>()
                            .SingleInstance();

            builder.RegisterType<UserConverter>();
            builder.RegisterType<UserTypesNeededMarkupProvider>().As<IUserTypesNeededMarkupProvider>();
        }
    }
}