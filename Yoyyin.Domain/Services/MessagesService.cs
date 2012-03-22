using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Data.EntityFramework;
using Yoyyin.Domain.Extensions;


namespace Yoyyin.Domain.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly IUserMessagesRepository _repository;

        public MessagesService(IUserMessagesRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UserMessages> GetOutBoxMessages(Guid userID)
        {
            return _repository
                        .Find()
                        .Where(message => message.FromUserId == userID)
                        .OrderBy(message => message.TimeStamp);   //.Include("User") 
        }

        public IEnumerable<UserMessages> GetInBoxMessages(Guid userId)
        {
            return _repository
                .Find()
                .Where(message => message.ToUserId == userId)
                .OrderByDescending(message => message.TimeStamp);
        }
    }
}
