using System;
using Yoyyin.Data;

namespace Yoyyin.Domain.Mappers
{
    public class MessageMapper : IMessageMapper
    {
        private readonly IUserMapper _userMapper;

        public MessageMapper(IUserMapper userMapper)
        {
            _userMapper = userMapper;
        }

        public Message MapMessage(UserMessages messageData)
        {
            return new Message
                       {
                           Text = messageData.FromMessage,
                           Created = (DateTime) messageData.TimeStamp,
                           FromMessage = messageData.FromMessage,
                           FromUser = _userMapper.MapUser(messageData.User),
                           ToUser = _userMapper.MapUser(messageData.User1)
                       };
        }
    }
}