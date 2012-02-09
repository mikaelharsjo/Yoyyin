using System;
using System.Collections.Generic;

namespace Yoyyin.Domain.Services
{
    public interface IMessagesService
    {
        Message GetById(int userMessagesId);
        IEnumerable<Message> GetOutBoxMessages(Guid userID);
        IEnumerable<Message> GetInBoxMessages(Guid userId);
        void CreateAndSaveUserMessage(Guid fromUserId, Guid toUserId, string message);
    }
}