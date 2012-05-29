using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Yoyyin.Prevalence.AggregateRoots;
using Yoyyin.Prevalence.Services;

namespace Yoyyin.Prevalence.Tests
{
    [TestFixture]
    public class UserServiceGetQuestionsShould : SetupFixture
    {
        private User _firstUser;
        private IUserService _userService;

        [SetUp]
        public new void Setup()
        {
            base.Setup();
            _userService = new UserService(Repo);
            _firstUser = Repo.Query(m => m.Users.First());
        }

        [Test]
        public void Return5()
        {
            Assert.That(_userService.GetQuestions(_firstUser.UserId).Count(), Is.EqualTo(5));
        }

        //[Test]
        //public void Have5Answers()
        //{
        //    var questions = Repo.Query(m => m.Questions.Where(q => q.Answers.Any(a => a.UserId == _firstUser.UserId)));
        //    Assert.That(questions.Count(), Is.EqualTo(5));
        //}

        [TearDown]
        public new void TearDown()
        {
            base.TearDown();
        }
    }
}
