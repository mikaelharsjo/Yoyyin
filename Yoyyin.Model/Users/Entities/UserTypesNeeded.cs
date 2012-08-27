using System.Collections.Generic;
using Yoyyin.Model.Users.Enumerations;
using System.Linq;

namespace Yoyyin.Model.Users.Entities
{
    public class UserTypesNeeded : IUserTypesNeeded
    {
        public UserTypesNeeded()
        {
            UserTypeIds = new int[0];
        }

        public IEnumerable<int> UserTypeIds { get; set; }
        //public Dictionary<int, string> UserTypesNeededDescriptions { get; set; }

        public bool WantsFinancing()
        {
            // TODO: this is ugly
            return UserTypeIds.Contains(3);
        }
    }
}