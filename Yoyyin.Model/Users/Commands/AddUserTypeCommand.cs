using System;
using Kiwi.Prevalence;
using Yoyyin.Model.Users.AggregateRoots;

namespace Yoyyin.Model.Users.Commands
{
    public class AddUserTypeCommand : AbstractCommand<UserModel, bool>
    {
        public AddUserTypeCommand()
        {
        }

        public AddUserTypeCommand(UserType userType)
        {
            UserType = userType;
        }

        public UserType UserType { get; set; }

        public override bool Execute(UserModel userModel)
        {
            userModel.UserTypes.Add(UserType);
            return true;
        }
    }
}