using System.Linq;
using Yoyyin.Model.Extensions;
using Yoyyin.Model.Users;
using Yoyyin.Mvc.Providers;

namespace Yoyyin.Mvc.ViewModels.Presenters
{
    public class MessageConverter
    {
        private ImageProvider _imageProvider;
        private readonly IUserRepository _repository;

        public MessageConverter(IUserRepository repository)
        {            
            _repository = repository;
        }

        public Message Convert(Model.Users.AggregateRoots.Message message)
        {            
            var from = _repository.Query(m => m.Users.FirstOrDefault(u => u.UserId == message.UserId));
            _imageProvider = new ImageProvider(from);
            return new Message
                       {
                           Subject = message.Subject, 
                           Text = message.Text, 
                           Created = message.Created.ToFormattedString(),
                           ImageSrc = _imageProvider.GetProfileImageSrc(),
                           UserId = message.UserId,
                           DisplayName = from.DisplayName
                       };
        }
    }
}