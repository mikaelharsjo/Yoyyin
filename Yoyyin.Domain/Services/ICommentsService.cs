using System;
using System.Collections.Generic;
using Yoyyin.Data;

namespace Yoyyin.Domain.Services
{
    public interface ICommentsService
    {
        void DeleteComment(int commentID);
        IEnumerable<UserComments> GetComments(Guid userID);
        //Comment CreateAndSaveComment(Guid fromUserId, Guid toUserId, string text, int commentID);
    }
}