using System.Collections.Generic;
using Yoyyin.Model.Users.Enumerations;
using System.Linq;

namespace Yoyyin.Model.Users.Entities
{
    public interface IUserTypesNeeded
    {
        IEnumerable<int> UserTypeIds { get; set; }
        Dictionary<int, string> UserTypesNeededDescriptions { get; set; }
        bool WantsFinancing();
    }
    
    public class UserTypesNeeded : IUserTypesNeeded
    {
        public IEnumerable<int> UserTypeIds { get; set; }

        public Dictionary<int, string> UserTypesNeededDescriptions { get; set; }

        public bool WantsFinancing()
        {
            // TODO: this is ugly
            return UserTypeIds.Contains(3);
        }
    }
}