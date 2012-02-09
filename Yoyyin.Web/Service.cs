using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.Services;
using Yoyyin.Web.Helpers;

namespace Yoyyin.Web
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class Service
    {
        private const string UserBig = "<div><h2>{1}</h2><p>{2}</p></div>";
        private readonly IUserService _userService;
        private IBookmarksService BookmarksService { get; set; }
        private readonly MailHelper _mailHelper;
        private readonly IQAService _qaService;
        private readonly ICommentsService _commentsService;
        private readonly ICurrentUser _currentUser;
        private readonly CategoryFactory _categoryFactory;

        public Service(){}

        public Service(IUserService userService, IQAService qaService, ICurrentUser currentUser, IBookmarksService bookmarksService, ICommentsService commentsService, CategoryFactory categoryFactory)
        {
            _userService = userService;
            _qaService = qaService;
            _currentUser = currentUser;
            BookmarksService = bookmarksService;
            _commentsService = commentsService;
            _categoryFactory = categoryFactory;
            _mailHelper = new MailHelper();
        }

        [OperationContract]
        public string QuickSearch(string text)
        {
            var dict = new Dictionary<string, object> {{"Text", text}};

            return AjaxRenderer.RenderUserControl(@"~\UserControls\QuickSearch.ascx", true, dict, false);
        }

        [OperationContract]
        public string GetMailPop(int userMessagesID, Guid fromUserId, Guid toUserId)
        {
            var dict = new Dictionary<string, object>
                           {{"UserMessagesID", userMessagesID}, {"FromUserId", fromUserId}, {"ToUserId", toUserId}};

            return AjaxRenderer.RenderUserControl(@"~\UserControls\MailPop.ascx", true, dict, false);
        }

        [OperationContract]
        public string LoadComment(string userId, int textAreaWidth)
        {
            var dict = new Dictionary<string, object> {{"UserId", new Guid(userId)}, {"TextAreaWidth", textAreaWidth}};

            return AjaxRenderer.RenderUserControl(@"~\UserControls\Comments.ascx", true, dict, false);
        }

        [OperationContract]
        public string GetUserProfile(Guid userId)
        {
            var user = _userService.GetUser(userId);

            if (string.IsNullOrEmpty(user.BusinessDescription + user.BusinessTitle))
                return string.Empty;
            
            return string.Format(UserBig, "", user.BusinessTitle,
                                 user.BusinessDescription.Truncate(200), "");
        }

        [OperationContract]
        public void SendInvite(string email, string from, string fromEmail)
        {
            const string inviteBody = "{0}, {1} har bjudit in dig till Yoyyin, klicka på länken nedan för att registrera dig.<br /><a href='http://yoyyin.com/Register.aspx'>Acceptera inbjudan</a><br/><br/><i><p>Yoyyin.com är en plats för inspiration och en tjänst för er som vill finna partners för att starta upp eller utveckla sin företagsidé eller sitt företag.</p><p>Tack vare vår sök- och matchningsfunktion samt diskussionsgrupper kan ni enkelt komma i kontakt med personer som har de kompetenser och egenskaper som ni eftersöker för att utveckla er verksamhet.</p><p>Då tjänsten är i sin Betafas håller vi långsamt på och fyller på med nya medlemmar. Detta gör att interaktionen är begränsad då vår Betagrupp är relativt liten, men den kommer öka i takt med att ni återkommer med era tankar och antalet medlemmar blir fler.</p><p>Välkommen till Yoyyin!</p></i>";
            const string inviteSubject = "Inbjudan till Yoyyin";
            _mailHelper.SendMail(string.Format(inviteBody, from, fromEmail), inviteSubject, fromEmail, email,
                                WebHelpers.MailFooter2);
        }

        [OperationContract]
        public void SendMail(Guid fromUserId, Guid toUserId, string message)
        {
            _mailHelper.SendYoyyinMail(fromUserId, toUserId, message);
        }

        [OperationContract]
        public void SaveComment(Guid fromUserId, Guid toUserId, string text, int commentID)
        {
            Comment comment = _commentsService.CreateAndSaveComment(fromUserId, toUserId, text, commentID);

            if (fromUserId != toUserId)
            {
                string message = _userService.GetUser(fromUserId).GetDisplayName() + " har kommenterat din affärsidé/profil.";
                string footer = string.Format(MailHelper.MailFooter, "/Member.aspx?UserID=" + comment.User.UserId);
                _mailHelper.SendMail(message, "Ny kommentar på din affärsidé", "noreply@zitac.se", WebHelpers.GetEmail(toUserId), footer);
            }
            if (commentID > 0)
            {
                string message = _userService.GetUser(fromUserId).GetDisplayName() + " har svarat på din kommentar.";
                string footer = string.Format(MailHelper.MailFooter, "/Member.aspx?UserID=" + comment.User.UserId);
                _mailHelper.SendMail(message, "Svar på din kommentar", "noreply@zitac.se",
                                    WebHelpers.GetEmail(toUserId), footer);
            }
        }

        [OperationContract]
        public void SendMailSmtp(string fromEmail, string toEmail, string subject, string body)
        {
            _mailHelper.SendMail(body, subject, fromEmail, toEmail, string.Empty);
        }

        [OperationContract]
        public void DeleteUser(Guid userId)
        {
            _userService.DeleteUser(userId);
            WebHelpers.DeleteMembershipUser(userId);
        }

        [OperationContract]
        public void InActivateUser(Guid userId)
        {
            var user = _userService.GetUser(userId);
            _userService.InActivateUser(user);
            
        }

        [OperationContract]
        public string ChooseForum(string question, int forumUserID)
        {
            return AjaxRenderer.RenderUserControl(@"~\UserControls\ForumChoose.ascx", true,
                                                new Dictionary<string, object>
                                                    {{"Question", question}, {"ForumUserID", forumUserID}}, false);
        }

        [OperationContract]
        public string LoadControl(string controlName)
        {
            return LoadControlWithParams(controlName, new Dictionary<string, object>());
        }

        [OperationContract]
        public string LoadControlWithParams(string controlName, Dictionary<string, object> dictionary)
        {
            return AjaxRenderer.RenderUserControl(@"~\UserControls\" + controlName + ".ascx", true, dictionary, false);
        }

        [OperationContract]
        public void AddBookmark(Guid userID, Guid bookmarkUserID)
        {
            BookmarksService.CreateAndSaveBookmark(userID, bookmarkUserID);
        }

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json)]
        public void DeleteBookmark(Guid userID, Guid bookmarkUserID)
        {
            BookmarksService.DeleteBookmark(userID, bookmarkUserID);
        }

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json)]
        public void RemoveImageFromUser(Guid userID)
        {
            var user = _userService.GetUser(userID);
            _userService.RemoveImage(user);
        }

        [OperationContract]
        public void RemoveCvFromUser(Guid userID)
        {
            var user = _userService.GetUser(userID);
            _userService.RemoveCv(user);
        }

        [OperationContract]
        public void DeleteComment(int commentID)
        {
            _commentsService.DeleteComment(commentID);
        }

        [OperationContract]
        public string AdvancedSearch(string text, string sniHead, bool isEntrepreneur, bool isInnovator, bool isInvestor)
        {
            return AjaxRenderer.RenderUserControl(@"~\UserControls\SearchResult.ascx", true,
                                                new Dictionary<string, object>
                                                    {
                                                        {"Text", text},
                                                        {"SniHead", sniHead},
                                                        {"IsEntrepreneur", isEntrepreneur},
                                                        {"IsInnovator", isInnovator},
                                                        {"IsInvestor", isInvestor}
                                                    }, false);
        }

        [OperationContract]
        public void AddQuestion(string title, string text, int category)
        {
            var question = new Question
                               {
                                   Title = title,
                                   Category = _categoryFactory.CreateCategory(category, _qaService),
                                   Owner = _userService.GetUser(_currentUser.UserId),
                                   Text = text,
                                   Created = DateTime.Now
                               };

            _qaService.CreateQuestionInDb(question);
        }

        [OperationContract]
        public void AddAnswer(string text, int questionId)
        {
            var answer = new Answer
                             {Created = DateTime.Now, QuestionID = questionId, UserId = Current.UserID, Text = text};

            _qaService.CreateAnswerInDb(answer);
        }

        [OperationContract]
        public void DeleteQuestion(int questionId)
        {
            _qaService.DeleteQuestion(questionId);
        }

        [OperationContract]
        public void DeleteAnswer(int answerId)
        {
            _qaService.DeleteAnswer(answerId);
        }
    }
}