using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Data.EntityFramework;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.Mappers;

namespace Yoyyin.Domain.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly IUserMessagesRepository _repository;
        private IMessageMapper _messageMapper;

        public MessagesService(IUserMessagesRepository repository, IMessageMapper messageMapper)
        {
            _repository = repository;
            _messageMapper = messageMapper;
        }

        public Message GetById(int userMessagesId)
        {
            return _repository
                        .Find()
                        .Where(x => x.UserMessagesID == userMessagesId)
                        .Select(_messageMapper.MapMessage)
                        .First();
        }

        public IEnumerable<Message> GetOutBoxMessages(Guid userID)
        {
            return _repository
                        .Find()
                        .Where(message => message.FromUserId == userID)
                        .Select(_messageMapper.MapMessage)
                        .OrderBy(message => message.Created);   //.Include("User") 
        }

        public IEnumerable<Message> GetInBoxMessages(Guid userId)
        {
            return _repository
                .Find()
                .Where(message => message.ToUserId == userId)
                .OrderByDescending(message => message.TimeStamp)
                .Select(_messageMapper.MapMessage);
        }

        public void CreateAndSaveUserMessage(Guid fromUserId, Guid toUserId, string message)
        {
            var userMessage = _repository.Create();

            _repository.Add(userMessage);

            userMessage.FromMessage = message.Truncate(400);
            userMessage.FromUserId = fromUserId;
            userMessage.ToUserId = toUserId;
            userMessage.TimeStamp = DateTime.Now;

            _repository.Save();
        }
    }
}
