using System;
using Yoyyin.Domain;
using Yoyyin.Domain.Matching;
using Yoyyin.Domain.Services;
using Yoyyin.Domain.Users;

namespace Yoyyin.Web.UserControls
{
    public partial class MatcherControl : System.Web.UI.UserControl
    {
        public string FirstUserId { get; set; }
        public string SecondUserId { get; set; }
        
        private IUser _firstUser;
        private IUser _secondUser;

        private Matcher _matcher;
        public IUserService UserService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (FirstUserId == string.Empty || SecondUserId == string.Empty)
                return;
            
            _firstUser = UserService.GetUser(new Guid(FirstUserId));
            _secondUser = UserService.GetUser(new Guid(SecondUserId));

            firstUserImage.User = _firstUser;
            secondUserImage.User = _secondUser;

            _matcher = new Matcher(_firstUser, _secondUser);
            litMatchResult.Text = _matcher.GetResultsAsHtmlTable();

            litFirstUser.Text = GetUserNameText(_firstUser);
            litSecondUser.Text = GetUserNameText(_secondUser);
        }

        private string GetUserNameText(IUser user)
        {
            return user.GetDisplayName() + "<br />" + user.City;
        }
    }
}