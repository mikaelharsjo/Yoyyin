using System.Collections.Generic;
using System.Linq;
using Yoyyin.Model.Extensions;
using Yoyyin.Model.Users;
using Yoyyin.Mvc.Providers;

namespace Yoyyin.Mvc.ViewModels.Presenters
{
    public class CommentConverter
    {
        private readonly IUserRepository _repository;
        private ImageProvider _imageProvider;

        public CommentConverter(IUserRepository repository)
        {
            _repository = repository;            
        }

        public Comment Convert(Model.Users.Entities.Comment comment)
        {
            var commenter = _repository.Query(m => m.Users.FirstOrDefault(u => u.UserId == comment.UserId));
            _imageProvider = new ImageProvider(commenter);
            return new Comment
                       {
                           Text = comment.Text,
                           Created = comment.Created.ToFormattedString(),
                           Comments = comment.Comments != null ? comment.Comments.Select(Convert) : new List<Comment>(),
                           UserImageSrc = _imageProvider.GetProfileImageSrc(),
                           UserDisplayName = commenter != null ? commenter.DisplayName : string.Empty
                       };
        }
    }
}