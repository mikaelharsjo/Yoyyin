using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yoyyin.Model.Extensions;
using Yoyyin.Model.Users;

namespace Yoyyin.Mvc.Models.Converters
{
    public class MessageConverter
    {
        //private IUserRepository _repository;

        //public MessageConverter(IUserRepository repository)
        //{
        //    _repository = repository;
        //}

        public Message Convert(Model.Users.AggregateRoots.Message message)
        {
            return new Message
                       {
                           Subject = message.Subject, 
                           Text = message.Text, 
                           Created = message.Created.ToFormattedString(),
                           ImageSrc = string.Format("/Content/Upload/Images/{0}.jpg?width=50&height=50", message.UserId),
                           UserId = message.UserId
                       };
        }
    }
}