using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Linq;
using System.Web;
using Autofac;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Data.EntityFramework.Repositories;
using Yoyyin.Domain.Factories;
using Yoyyin.Domain.QA;
using Yoyyin.Domain.Services;
using Yoyyin.Domain.Users;
using Yoyyin.PresentationModel;
using Yoyyin.Web.Helpers;

namespace Yoyyin.Web.Configuration
{
    public class YoyyinModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // repositories (Repository Pattern)
            //builder.RegisterType<YoyyinEntities1>();
            string connectionString = ConfigurationManager.ConnectionStrings["Entities"].ToString();
            builder.Register(c => new EntityConnection(connectionString));
            builder.RegisterType<ObjectContext>();
            /*builder.RegisterType<EFQARepository>().As<IQARepository>();
            builder.RegisterType<EFSniHeadRepository>().As<ISniHeadRepository>();
            builder.RegisterType<EFUserRepository>().As<IUserRepository>();
            builder.RegisterType<EFUserVisitsRepository>().As<IVisitsRepository>();
            builder.RegisterType<EFCommentsRepository>().As<ICommentsRepository>();
            builder.RegisterType<EFUserBookmarksRepository>().As<IBookmarkRepository>();
            builder.RegisterType<EFUserMessagesRepository>().As<IUserMessagesRepository>();*/
            builder.RegisterType<EFUserRepository>().As<IUserRepository>();
            builder.RegisterType<EFQuestionRepository>().As<IQuestionRepository>();
            builder.RegisterType<EFRepository<Answer>>().As<IRepository<Answer>>();
            builder.RegisterType<EFBookmarkRepository>().As<IBookmarkRepository>();
            builder.RegisterType<EFVisitRepository>().As<IVisitRepository>();
            builder.RegisterType<EFRepository<SniHead>>().As<IRepository<SniHead>>();
            builder.RegisterType<EFMessageRepository>().As<IMessageRepository>();

            // factories (Factory method pattern)
            builder.RegisterType<CategoryFactory>();

            // site configuration
            builder.RegisterType<CurrentUser>().As<ICurrentUser>();

            // services
            //builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<QAService>().As<IQAService>();
            builder.RegisterType<SniHeadService>().As<ISniHeadService>();
            builder.RegisterType<VisitsService>().As<IVisitsService>();
            builder.RegisterType<UserService>().As<IUserService>();

            // misc
            builder.RegisterType<NewestMembersHelper>();
            builder.RegisterType<OnlineImageProvider>().As<IOnlineImageProvider>();

            // presenters (Pesentation Model)
            builder.RegisterType<UserPresenter>().As<IUserPresenter>();
            builder.RegisterType<PostPresenter>().As<IPostPresenter>();
            builder.RegisterType<VisitPresenter>().As<IVisitPresenter>();
            builder.RegisterType<CommentPresenter>().As<ICommentPresenter>();
            builder.RegisterType<BookmarkPresenter>().As<IBookmarkPresenter>();
            builder.RegisterType<MessagePresenter>().As<IMessagePresenter>();
            builder.RegisterType<QuestionPresenter>().As<IQuestionPresenter>();
        }
    }
}