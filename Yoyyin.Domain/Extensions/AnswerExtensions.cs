using System;
using Yoyyin.Data;
using Yoyyin.Services;

namespace Yoyyin.Domain.Extensions
{
    public static class AnswerExtensions
    {
        public static bool DeleteAllowed(this Answer answer, Guid userId)
        {
            var questionsHelper = new QAService(new EntityQARepository(new YoyyinEntities1()));
            return questionsHelper.DeleteAllowed(answer, userId);
        }
    }
}
