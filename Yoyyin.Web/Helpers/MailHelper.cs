using System;
using System.Net.Mail;
using System.Web.Security;
using Yoyyin.Data;
using Yoyyin.Data.UnitOfWork;
using Yoyyin.Domain;
using Yoyyin.Domain.Services;


namespace Yoyyin.Web.Helpers
{
    public class MailHelper
    {
        private IUnitOfWork _unitOfWork;
        private IUserRepository _userRepository;
        private EFRepository<UserMessages> _messagesRepository;
        //private IMessagesService _messagesService;
        const string MailSubject = "Meddelande via Yoyyin från {0}";
        private const string MailStyles = "<style type='text/css'>body {font-family: Trebuchet, Calibri, Arial, Sans-Serif; font-size: 20px; line-height: 25px; color: #444444;}</style>";
        public const string MailFooter = "<br/>För att läsa/svara på detta gå in på <a href='http://yoyyin.com{0}' target='_blank'>yoyyin.com</a><br/><br/>Hälsningar Yoyyin";

        public void SendYoyyinMail(Guid fromUserId, Guid toUserId, string message)
        {
            var userMessage = new UserMessages
                                       {FromUserId = fromUserId, ToUserId = toUserId, FromMessage = message};
            
            _messagesRepository.Add(userMessage);
            _unitOfWork.Commit();

            var userFrom = _userRepository.GetUser(fromUserId);
            var userTo = _userRepository.GetUser(toUserId);

            string footer = String.Format(MailFooter, "/Home.aspx");
            SendMail(message, String.Format(MailSubject, userFrom.Name), Membership.GetUser(userFrom.UserId).Email, Membership.GetUser(userTo.UserId).Email, footer);
        }

        public void SendErrorMail(string message)
        {
            SendMail(message, "Fel på Yoyyin", "", "mikael@zitac.se", String.Empty);
        }

        public void SendMail(string body, string subject, string replyTo, string to, string footer)
        {
            var mail = new MailMessage {From = new MailAddress("noreply@zitac.se")};
            if (replyTo.Length > 0)
                mail.ReplyToList.Add(new MailAddress(replyTo));

            mail.To.Add(string.IsNullOrEmpty(to) ? new MailAddress("mikael@zitac.se") : new MailAddress(to));

            mail.IsBodyHtml = true;
            mail.Subject = subject;

            mail.Body = MailStyles + "<body>" + body + "<br/>" + footer + "</body>";

            var server = new SmtpClient();
            server.Send(mail);
        }
    }
}