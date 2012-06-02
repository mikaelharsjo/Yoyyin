using System.Collections.Generic;
using Yoyyin.Model.Users.Enumerations;
using System.Linq;

namespace Yoyyin.Model.Users.Entities
{
    public interface IUserTypesNeeded
    {
        IEnumerable<UserTypes> UserTypeIds { get; set; }
        Dictionary<UserTypes, string> UserTypesNeededDescriptions { get; set; }
        bool WantsFinancing();
    }

    public class UserTypesNeeded : IUserTypesNeeded
    {
        public IEnumerable<UserTypes> UserTypeIds { get; set; }

        public Dictionary<UserTypes, string> UserTypesNeededDescriptions { get; set; }

        public bool WantsFinancing()
        {
            return UserTypeIds.Contains(UserTypes.Financing);
        }
    }

    //public class NullUserTypesNeeded : IUserTypesNeeded
    //{
    //    public Dictionary<UserTypes, string> UserTypesNeededDescriptions
    //    {
    //        get { return new Dictionary<UserTypes, string>(); }
    //        set { }
    //    }

    //    public IEnumerable<UserTypes> UserTypeIds
    //    {
    //        get { return new UserTypes[0]; }
    //        set { }
    //    }
    //}
}