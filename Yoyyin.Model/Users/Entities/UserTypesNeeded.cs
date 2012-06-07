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
        //            return "Innovatör/Uppfinnare";
        //        case UserTypes.Entrepreneur:
        //            return "Företagare/Entreprenör";
        //        case UserTypes.Investor:
        //            return "Finansiär";
        //        case UserTypes.Businessman:
        //            return "Företagare";
        //        case UserTypes.Retiring:
        //            return "Företagare";
        //        case UserTypes.Financing:
        //            return "Finansiär/Drake/Ängel";
        //        default:
        //            return "Detta borde aldrig hända";
        //    }
        //}
    }
}