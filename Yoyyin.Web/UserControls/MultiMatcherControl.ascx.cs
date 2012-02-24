using System;
using System.Collections.Generic;
using System.Web.UI;
using Yoyyin.Domain;
using Yoyyin.Domain.Matching;
using Yoyyin.Domain.Services;
using Yoyyin.PresentationModel;


namespace Yoyyin.Web.UserControls
{
    public partial class MultiMatcherControl : UserControlWithDependenciesInjected
    {
        public IUserService UserService { get; set; }
        public IMultipleMatcher MultipleMatcher { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            litMatchSummary.Text = MultipleMatcher.GetStats().ToString();
            litMatchSummaryPercentage.Text = MultipleMatcher.GetStats().GetStatsAsPercentage().ToString() + "%";

            var matchers = MultipleMatcher.GetSuccesFullMatches();
            var multipleMatchConverter = new MultipleMatchPresenter();
            lstMatches.DataSource = multipleMatchConverter.Convert(matchers, Current.UserID);
            lstMatches.DataBind();
        }
    }
}