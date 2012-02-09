using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Domain.Extensions;

namespace Yoyyin.Domain.Services
{
    public class CommentsService : ICommentsService
    {
        private IRepository<Data.UserComments> _repository;

        public CommentsService(IRepository<Data.UserComments> repository)
        {
            _repository = repository;
        }

        public void DeleteComment(int commentID)
        {
            var childComments = _repository
                .Find()
                .Where(comment => comment.CommentCommentID == commentID);   //from x in _entities.UserComments where x.CommentCommentID == commentID select x;
                
            foreach (UserComments childComment in childComments)
            {
                RemoveSingleComment(childComment.CommentID);
            }

            RemoveSingleComment(commentID);
            _repository.Save();
        }

        private void RemoveSingleComment(int commentID)
        {
            _repository.Delete(_repository.Find().First(comment => comment.CommentID == commentID));
        }

        public IEnumerable<Comment> GetComments(Guid userID)
        {
            return _repository.Find().Where(comment => comment.UserId == userID).Select(CreateComment);
        }

        private Comment CreateComment(Data.UserComments userComment)
        {
            return new Comment {Text = userComment.Text, Created = userComment.TimeStamp};
        }

        public Comment CreateAndSaveComment(Guid fromUserId, Guid toUserId, string text, int commentID)
        {
            var comment = _repository.Create(); // _entities.CreateObject<UserComments>();
            _repository.Add(comment); //_entities.UserComments.AddObject(comment));

            comment.Text = text.Truncate(1000);
            comment.CommentUserId = fromUserId;
            comment.UserId = toUserId;
            comment.TimeStamp = DateTime.Now;
            if (commentID > 0)
                comment.CommentCommentID = commentID;

            _repository.Save();
            return CreateComment(comment);
        }
    }
}