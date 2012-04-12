using System;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Domain;
using Microsoft.Web;
using Yoyyin.Domain.Services;
using Yoyyin.Domain.Users;
using Yoyyin.PresentationModel.MarkupProviders;
using Yoyyin.Web.Helpers;

namespace Yoyyin.Web.UserControls
{
    public partial class UserImage : UserControlWithDependenciesInjected
    {
        public FacebookImageMarkupProvider FacebookImageMarkupProvider { get; set; } 
        public Guid UserID { get; set; }
        public IUser User { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IUserService UserService { get; set; }
        public ICurrentUser CurrentUser { get; set; }
        public int Width { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            bool onlyUserIDSet = User == null && UserID != Guid.Empty;
            if (onlyUserIDSet)            
                User = UserRepository.GetUser(UserID);

            bool neitherIDorUserSet = User == null && UserID == Guid.Empty;
            if (neitherIDorUserSet)
                User = UserService.GetCurrentUser();

            if (User != null)
            {
                generatedImage.Parameters.Add(new ImageParameter() { Name = "userID", Value = User.UserId.ToString() });
                lnkUser.Attributes["href"] = "~/Member.aspx?UserID=" + User.UserId;
            }

            if (Width > 0)
            {
                generatedImage.Parameters.Add(new ImageParameter() { Name = "width", Value = Width.ToString() });
                generatedImage.Parameters.Add(new ImageParameter() { Name = "height", Value = Width.ToString() });
            }

            FacebookImageMarkupProvider = new FacebookImageMarkupProvider(User);

            if (FacebookImageMarkupProvider.ShowFaceBookImage(User))
                generatedImage.Visible = false;
        }
    }
}