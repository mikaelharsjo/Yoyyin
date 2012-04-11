using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Domain.Extensions;


namespace Yoyyin.Domain.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly IMessageRepository _repository;

        public MessagesService(IMessageRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Message> GetOutBoxMessages(Guid userID)
        {
            return _repository
                        .Find()
                        .Where(message => message.FromUserId == userID)
                        .OrderBy(message => message.Created);   //.Include("User") 
        }

        public IEnumerable<Message> GetInBoxMessages(Guid userId)
        {
            return _repository
                .Find()
                .Where(message => message.ToUserId == userId)
                .OrderByDescending(message => message.Created);
        }
    }
}
