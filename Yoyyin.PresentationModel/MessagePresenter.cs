using System.Collections.Generic;
using System.Linq;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;

namespace Yoyyin.PresentationModel
{
    public class MessagePresenter : IMessagePresenter
    {
        public MessagePresentation Presentate(Message message)
        {
            return new MessagePresentation
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

        public IEnumerable<MessagePresentation> Presentate(IEnumerable<Message> userMessages)
        {
            return userMessages.Select(Presentate);
        }
    }
}