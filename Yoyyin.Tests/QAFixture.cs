using System;
using NUnit.Framework;
using Yoyyin.Data;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.Mappers;
using Yoyyin.Domain.QA;
using Yoyyin.Domain.Services;
using Yoyyin.Tests.Repositories;
using Yoyyin.Tests.Services;
using Answer = Yoyyin.Domain.QA.Answer;
using Question = Yoyyin.Domain.QA.Question;
using User = Yoyyin.Domain.Users.User;

namespace Yoyyin.Tests
{
    [TestFixture]
    public class QAFixture
    {
        private Guid _ownerUserId;
        private Guid _answerOwnerUserId;
        private Question _question;
        private Answer _answer;
        private IQAService _qaService;

        [SetUp]
        public void Setup()
        {
            _ownerUserId = new Guid("68830D44-9172-476C-8F6B-78CDFB8D5C2D");
            _answerOwnerUserId = new Guid("31C0A56E-7A70-4265-AD7D-61A29A04A9D7");
            _qaService = new QAService(new EntityQARepository(new YoyyinEntities1()),
                                       new QAMapper(new UserMapper(new SniHeadMapper(), new SniItemMapper())));

            _question = new Question {Owner = new User {UserId = _ownerUserId}};
            _answer = new Answer {Question = _question, UserId = _answerOwnerUserId};
        }

        //[Test]
        //public void DeleteAllowed_NotLoggedIn_ShouldNotBeAbleToDelete()
        //{
        //    Guid notLoggedInUserId = Guid.Empty;
        //    bool deleteAllowed = _qaService.DeleteAllowed(_question);

        //    Assert.That(deleteAllowed, Is.EqualTo(false));
        //}

        //[Test]
        //public void DeleteAllowed_OwnsQuestion_ShoulBeAbleToDelete()
        //{
        //    bool deleteAllowed = _question.DeleteAllowed(_ownerUserId);

        //    Assert.That(deleteAllowed, Is.EqualTo(true));
        //}

        //[Test]
        //public void DeleteAllowed_LoggedInButNotOwner_ShoulNotBeAbleToDelete()
        //{
        //    Guid userId = new Guid("31C0A56E-7A70-4265-AD7D-61A29A04A9D7");
        //    bool deleteAllowed = _question.DeleteAllowed(userId);

        //    Assert.That(deleteAllowed, Is.EqualTo(false));
        //}

        //[Test]
        //public void DeleteAllowedAnswer_NotLoggedIn_NotAllowed()
        //{
        //    Guid notLoggedInUserId = Guid.Empty;
        //    bool deleteAllowed = _answer.DeleteAllowed(notLoggedInUserId);

        //    Assert.That(deleteAllowed, Is.EqualTo(false));
        //}

        //[Test]
        //public void DeleteAllowedAnswer_LoggedInButNotOwner_ShoulNotBeAbleToDelete()
        //{
        //    Guid userId = new Guid("32333333-7A70-4265-AD7D-61A29A04A9D7");
        //    bool deleteAllowed = _answer.DeleteAllowed(userId);

        //    Assert.That(deleteAllowed, Is.EqualTo(false));
        //}

        //[Test]
        //public void DeleteAllowedAnswer_OwnerOfQuestionButNotAnswer_Allowed()
        //{
        //    Assert.That(_answer.DeleteAllowed(_ownerUserId), Is.EqualTo(true));
        //}
    }
}

