using System;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Domain.Services;

namespace Yoyyin.Web.UserControls
{
    public partial class MailPop : System.Web.UI.UserControl
    {
        private IMessagesService _messagesService;
        private IRepository<Message> _messageRepository;

        public MailPop(IRepository<Message> userRepository)
        {
            _messageRepository = userRepository;
        }

        public int UserMessagesID {get; set;}
        public Guid FromUserId { get; set; }
        public Guid ToUserId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserMessagesID > 0)
            {
                litMessage.Text = _messageRepository
                    .Find(m => m.MessageID == UserMessagesID)
                    .First().FromMessage;
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