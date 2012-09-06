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

            return new LookingFor() { ImageUrl = "/Images/glyphicons_043_group.png", Description = lookingFor.Description() };
        }
    }
}