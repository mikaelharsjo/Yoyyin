using System.Linq;
using System.Web;
using Yoyyin.Model.Users.Entities;
using Yoyyin.Mvc.Services;

namespace Yoyyin.Mvc.Models.Converters
{
    public class IdeaConverter
    {
        private readonly UserTypeService _userTypeService;
        private SniService _sniService;

        public IdeaConverter(UserTypeService userTypeService, SniService sniService)
        {
            _userTypeService = userTypeService;
            _sniService = sniService;
        }

        public Idea Convert(Model.Users.Entities.Idea idea)
        {
            return new Idea
                       {
                           CompanyName = idea.CompanyName,
                           Description = idea.Description,
                           Funding = idea.Funding,
                           //SniHeadId = idea.SniHeadId,
                           //SniNo = idea.SniNo,
                           Title = idea.Title,
                           UserTypesNeeded = _userTypeService.GetUserTypesAsStrings(idea.SearchProfile.UserTypesNeeded),
                           CompetencesNeeded = idea.SearchProfile.CompetencesNeeded,
                           SniHeadTitle = _sniService.GetTitle(idea.SniHeadId)
                       };
        }
    }
}