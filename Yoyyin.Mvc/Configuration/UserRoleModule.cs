using Autofac;
using Yoyyin.Mvc.Models.UserRoles;

namespace Yoyyin.Mvc.Configuration
{
    public class UserRoleModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(c => new UserRoles()
                                      {
                                          {"mimmertim@gmail.com", new []{"admin"}},
                                          {"mikaelharsjo@gmail.com", new []{"admin"}}
                                      })
                .As<IUserRoles>()
                .SingleInstance();

            builder.RegisterType<Authorizer>()
                .As<IAuthorizer>()
                .SingleInstance();
        }
    }
}