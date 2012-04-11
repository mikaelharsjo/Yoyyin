using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Domain.Extensions;

namespace Yoyyin.Domain.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _repository;

        public CommentsService(ICommentsRepository repository)
        {
            _repository = repository;
        }

        public void DeleteComment(int commentID)
        {
            var childComments = _repository
                .Find()
                .Where(comment => comment.CommentCommentID == commentID);
                
            foreach (Comment childComment in childComments)
            {
                RemoveSingleComment(childComment.CommentID);
            }

            RemoveSingleComment(commentID);
            _repository.Save();
        }

        private void RemoveSingleComment(int commentID)
        {
            _repository
                .Delete(_repository.Find().First(comment => comment.CommentID == commentID));
        }

        public IEnumerable<Comment> GetComments(Guid userID)
        {
            return _repository
                .Find()
                .Where(comment => comment.UserId == userID);
        }

        //public Comment CreateAndSaveComment(Guid fromUserId, Guid toUserId, string text, int commentID)
        //{
        //    var comment = _repository.Create();
        //    _repository.Add(comment);

        //    comment.Text = text.Truncate(1000);
        //    comment.CommentUserId = fromUserId;
        //    comment.UserId = toUserId;
        //    comment.TimeStamp = DateTime.Now;
        //    if (commentID > 0)
        //        comment.CommentCommentID = commentID;

        //    _repository.Save();

        //    return _mapper.MapComment(comment);
        //}
    }
}