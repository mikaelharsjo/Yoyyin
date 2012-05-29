using System;
using System.Linq;
using Kiwi.Prevalence;
using Yoyyin.Model.Users.AggregateRoots;

namespace Yoyyin.Model.Users
{
    public class UpdateUserCommand : AbstractCommand<UserModel, bool>
    {
        public UpdateUserCommand()
        {
            
        }

        public UpdateUserCommand(User user)
        {
            User = user;
        }

        public User User;

        public override Func<bool> Prepare(UserModel userModel)
        {
            return () =>
                       {
                           userModel.Users.Remove(userModel.Users.First(u => u.UserId == User.UserId));
                           userModel.Users.Add(User);
                           return true;
                       };
        }
    }
}
