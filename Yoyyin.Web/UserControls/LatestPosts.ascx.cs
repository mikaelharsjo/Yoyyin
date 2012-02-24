using System;
using Yoyyin.Domain.Services;
using Yoyyin.PresentationModel;

namespace Yoyyin.Web.UserControls
{
    public partial class LatestPosts : UserControlWithDependenciesInjected
    {
        public IQAService IqaService { get; set; }
        public IPostPresenter PostPresenter { get; set; }
        public const int MaxQuestionLength = 120;
        public const int MaxPosts = 5;
        protected void Page_Load(object sender, EventArgs e)
        {
            lstForum.DataSource = PostPresenter.Presentate(IqaService.GetLatestPosts(MaxPosts));
            lstForum.DataBind();
        }
    }
}