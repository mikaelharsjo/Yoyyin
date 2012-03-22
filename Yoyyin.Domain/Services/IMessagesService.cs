using System;
using System.Collections.Generic;
using Yoyyin.Data;

namespace Yoyyin.Domain.Services
{
    public interface IMessagesService
    {
        //UserMessages GetById(int userMessagesId);
        IEnumerable<UserMessages> GetOutBoxMessages(Guid userID);
        IEnumerable<UserMessages> GetInBoxMessages(Guid userId);
        //void CreateAndSaveUserMessage(Guid fromUserId, Guid toUserId, string message);
    }
}