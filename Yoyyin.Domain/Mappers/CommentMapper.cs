using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yoyyin.Domain.Mappers
{
    public interface ICommentMapper
    {
        Comment MapComment(Data.UserComments userComment);
    }

    public class CommentMapper : ICommentMapper
    {
        private IUserMapper _userMapper;

        public CommentMapper(IUserMapper userMapper)
        {
            _userMapper = userMapper;
        }

        public Comment MapComment(Data.UserComments userComment)
        {
            return new Comment
                       {
                           Text = userComment.Text,
                           Created = userComment.TimeStamp,
                           User = _userMapper.MapUser(userComment.User),
                           Commentator = _userMapper.MapUser(userComment.User1)
                       };
        }
    }
}
