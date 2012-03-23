using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Domain;

namespace Yoyyin.PresentationModel
{
    public interface IMessagePresenter
    {
        MessagePresentation Presentate(UserMessages message);
        IEnumerable<MessagePresentation> Presentate(IEnumerable<UserMessages> userMessages);
    }
}