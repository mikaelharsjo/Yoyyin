using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yoyyin.Mvc.ViewModels.Presenters
{
    public class LookingForPresenter
    {
        public LookingFor ToViewModel(Yoyyin.Model.Users.ValueObjects.LookingFor lookingFor)
        {
            if (lookingFor == null) { lookingFor = new Yoyyin.Model.Users.ValueObjects.LookingFor(); }

            return new LookingFor() { ImageUrl = GetImage(lookingFor), Description = lookingFor.Description() };
        }

        private string GetImage(Model.Users.ValueObjects.LookingFor lookingFor)
        {
            return "/Images/" + (lookingFor.PartnerToMyIdea ? "glyphicons_064_lightbulb.png" : "") + (lookingFor.JoinOrBeJoined ? "glyphicons_043_group.png" : "") + (lookingFor.IdeasToJoin ? "glyphicons_003_user.png" : "") + (lookingFor.Investements ? "glyphicons_037_credit.png" : "");
        }
    }
}