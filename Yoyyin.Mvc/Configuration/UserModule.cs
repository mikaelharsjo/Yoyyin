﻿using System.Web;
using System.Web.Mvc;
using Autofac;
using Kiwi.Prevalence;
using Yoyyin.Importing;
using Yoyyin.Model.Importers;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.Commands;
using Yoyyin.Model.Users.Services;
using Yoyyin.Mvc.Models;
using Yoyyin.Mvc.Models.Converters;
using Yoyyin.Mvc.Providers.Markup;
using Yoyyin.Mvc.Services;
using CurrentUserService = Yoyyin.Mvc.Services.CurrentUserService;

namespace Yoyyin.Mvc.Configuration
{
    public class UserModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.Register(c => new RepositoryConfiguration { Marshal = new NoMarshal()})
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

            builder.RegisterType<UserTypeService>();
            builder.RegisterType<SniService>();

            builder.RegisterType<CommentConverter>();
            builder.RegisterType<IdeaConverter>();
            builder.RegisterType<UserConverter>();


            builder.RegisterType<UserTypesNeededMarkupProvider>().As<IUserTypesNeededMarkupProvider>();
            builder.RegisterType<CurrentUserService>();
        }
    }
}