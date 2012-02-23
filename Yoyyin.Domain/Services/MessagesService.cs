using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
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

        public Message GetById(int userMessagesId)
        {
            var messageData = _repository
                                .Find()
                                .First(x => x.UserMessagesID == userMessagesId);

            return CreateMessage(messageData);
        }

        private static Message CreateMessage(UserMessages messageData)
        {
            return new Message {Text = messageData.FromMessage, Created = (DateTime)messageData.TimeStamp, FromMessage = messageData.FromMessage };
        }

        public IEnumerable<Message> GetOutBoxMessages(Guid userID)
        {
            return _repository
                        .Find()
                        .Where(message => message.FromUserId == userID)
                        .Select(CreateMessage)
                        .OrderBy(message => message.Created);   //.Include("User") 
        }

        public IEnumerable<Message> GetInBoxMessages(Guid userId)
        {
            return _repository
                .Find()
                .Where(message => message.ToUserId == userId)
                .OrderByDescending(message => message.TimeStamp)
                .Select(CreateMessage);
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
