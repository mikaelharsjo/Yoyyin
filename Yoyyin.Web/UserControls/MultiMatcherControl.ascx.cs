using System;
using System.Collections.Generic;
using System.Web.UI;
using Yoyyin.Data;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Domain;
using Yoyyin.Domain.Matching;
using Yoyyin.Domain.Services;
using Yoyyin.Domain.Users;
using Yoyyin.PresentationModel;

namespace Yoyyin.Web.UserControls
{
    public partial class MultiMatcherControl : UserControlWithDependenciesInjected
    {
        public IUserService UserService { get; set; }
        public IUserRepository UserRepository { get; set; }
        public ICurrentUser CurrentUser { get; set; }
        //public IMultipleMatcher MultipleMatcher { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var multipleMatcher = new MultipleMatcher(UserService.GetCurrentUser(), UserRepository.FindAll(), UserRepository);

            litMatchSummary.Text = multipleMatcher.GetStats().ToString();
            litMatchSummaryPercentage.Text = multipleMatcher.GetStats().GetStatsAsPercentage().ToString() + "%";
            
            var matchers = multipleMatcher.GetSuccesFullMatches();

            var multipleMatchConverter = new MultipleMatchPresenter();
            lstMatches.DataSource = multipleMatchConverter.Convert(matchers, Current.UserID);
            lstMatches.DataBind();
        }
    }
}