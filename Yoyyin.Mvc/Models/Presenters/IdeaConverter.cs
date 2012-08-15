using System.Collections.Generic;
using System.Linq;
using Yoyyin.Mvc.Services;

namespace Yoyyin.Mvc.Models.Presenters
{
    public class IdeaConverter
    {
        private readonly UserTypeService _userTypeService;
        private SniService _sniService;
        private readonly CommentConverter _commentConverter;

        public IdeaConverter(UserTypeService userTypeService, SniService sniService, CommentConverter commentConverter)
        {
            _userTypeService = userTypeService;
            _sniService = sniService;
            _commentConverter = commentConverter;
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
                           SniHeadTitle = _sniService.GetTitle(idea.SniHeadId),
                           Comments = idea.Comments != null ? idea.Comments.Select(_commentConverter.Convert) : new List<Comment>()
                       };
        }
    }
}