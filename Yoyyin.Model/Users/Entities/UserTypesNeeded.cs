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

        //public IEnumerable<string> GetUserTypeTitles()
        //{
        //    return UserTypeIds.Select(ToTitle);
        //}

        //private string ToTitle(UserTypes userTypes)
        //{
        //    switch (userTypes)
        //    {
        //        case UserTypes.Innovator:
        //            return "Innovat�r/Uppfinnare";
        //        case UserTypes.Entrepreneur:
        //            return "F�retagare/Entrepren�r";
        //        case UserTypes.Investor:
        //            return "Finansi�r";
        //        case UserTypes.Businessman:
        //            return "F�retagare";
        //        case UserTypes.Retiring:
        //            return "F�retagare";
        //        case UserTypes.Financing:
        //            return "Finansi�r/Drake/�ngel";
        //        default:
        //            return "Detta borde aldrig h�nda";
        //    }
        //}
    }
}