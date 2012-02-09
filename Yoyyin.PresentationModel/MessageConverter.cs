using System.Collections.Generic;
using System.Linq;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;

namespace Yoyyin.PresentationModel
{
    public class MessageConverter
    {
        public MessageView Convert(Message message)
        {
            return new MessageView()
                       {
                           Date = message.Created.ToFormattedString(),
                           Message = message.FromMessage,
                           DisplayName = message.FromUser.GetDisplayName(),
                           ToDisplayName = message.ToUser.GetDisplayName(),
                           MessageShort = message.FromMessage.Truncate(100),
                           UserMessagesID = message.UserMessagesID,
                           FromUserId = message.FromUser.UserId
                       };
        }

        public IEnumerable<MessageView> Convert(IEnumerable<Message> userMessages)
        {
            return userMessages.Select(Convert);
        }
    }
}