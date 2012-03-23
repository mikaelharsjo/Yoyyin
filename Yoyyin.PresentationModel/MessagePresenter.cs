using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;

namespace Yoyyin.PresentationModel
{
    public class MessagePresenter : IMessagePresenter
    {
        public MessagePresentation Presentate(UserMessages message)
        {
            return new MessagePresentation
                       {
                           Date = message.TimeStamp.ToFormattedString(),
                           Message = message.FromMessage,
                           DisplayName = message.User.GetDisplayName(),
                           ToDisplayName = message.User1.GetDisplayName(),
                           MessageShort = message.FromMessage.Truncate(100),
                           UserMessagesID = message.UserMessagesID,
                           FromUserId = message.User1.UserId
                       };
        }

        public IEnumerable<MessagePresentation> Presentate(IEnumerable<UserMessages> userMessages)
        {
            return userMessages.Select(Presentate);
        }
    }
}