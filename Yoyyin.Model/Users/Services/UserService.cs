using System;
using System.Collections.Generic;
using Kiwi.Prevalence;
using Yoyyin.Model.Users.AggregateRoots;

namespace Yoyyin.Model.Users.Services
{
    public class UserService : IUserService
    {
        private readonly Repository<UserModel> _repository;

        public UserService(Repository<UserModel> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Question> GetQuestions(Guid userId)
        {
            return _repository.Model.QuestionsByUser[userId];
        }
    }
}
