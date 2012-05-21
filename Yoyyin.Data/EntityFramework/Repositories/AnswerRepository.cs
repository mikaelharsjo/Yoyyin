using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Yoyyin.Data.EntityFramework
{
    public interface IAnswerRepository : IRepository<Answer>
    {
    }

    class AnswerRepository : EFRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(ObjectContext context) : base(context)
        {
        }
    }
}
