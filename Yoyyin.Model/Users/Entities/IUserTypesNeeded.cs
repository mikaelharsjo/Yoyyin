using System.Collections.Generic;

namespace Yoyyin.Model.Users.Entities
{
    public interface IUserTypesNeeded
    {
        IEnumerable<int> UserTypeIds { get; set; }
        //Dictionary<int, string> UserTypesNeededDescriptions { get; set; }
        bool WantsFinancing();
    }
}