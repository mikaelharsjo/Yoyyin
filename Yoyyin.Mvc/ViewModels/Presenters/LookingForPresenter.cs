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
            if (lookingFor == null) { return new LookingFor(); }

            return new LookingFor() { Text = lookingFor.ToString() };
        }
    }
}