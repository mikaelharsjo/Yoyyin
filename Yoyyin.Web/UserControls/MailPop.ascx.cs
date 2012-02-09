using System;
using Yoyyin.Domain.Services;

namespace Yoyyin.Web.UserControls
{
    public partial class MailPop : System.Web.UI.UserControl
    {
        private IMessagesService _messagesService;

        public int UserMessagesID {get; set;}
        public Guid FromUserId { get; set; }
        public Guid ToUserId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserMessagesID > 0)
            {
                litMessage.Text = _messagesService.GetById(UserMessagesID).FromMessage;
            }
            else
            {
                tr2.Visible = false;
                tr1.Visible = false;
                tr3.Visible = false;
                litAnswer.Text = "Skriv ditt meddelande";
                litHeader.Text = "Nytt meddelande";
            }
            hiddenToUserId.Value = ToUserId.ToString();
            hiddenFromUserId.Value = FromUserId.ToString();
            userImage.UserID = ToUserId;
        }
    }
}