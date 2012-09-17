using System;
using Kiwi.Prevalence;
using Yoyyin.Model.Users.AggregateRoots;

namespace Yoyyin.Model.Users.Commands
{
    public class AddUserCommand : AbstractCommand<UserModel, bool>  
    {
        public AddUserCommand()
        {
        }

        public AddUserCommand(User user)
        {
            User = user;
        }

        public User User { get; set; }

        //public override Func<bool> Prepare(UserModel userModel)
        //{
        //    userModel.Users.Add(User);
        //    return () => true; 
        //}

        public override bool Execute(UserModel model)
        {
            model.Users.Add(User);
            return true;
        }
    }
}
