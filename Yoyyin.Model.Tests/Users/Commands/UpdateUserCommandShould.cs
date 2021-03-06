﻿using System.Linq;
using NUnit.Framework;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.Commands;

namespace Yoyyin.Model.Tests.Users.Commands
{
    [TestFixture]
    public class UpdateUserCommandShould : SetupFixture
    {
        private const string NameOfDonaldDuck = "Kalle Anka";
        [SetUp]
        public new void Setup()
        {
            base.Setup();
        }

        [Test]
        public void ChangeName()
        {
            var firstUser = UserRepository.Query(m => m.Users.First());
            Assert.That(firstUser.Name, Is.Not.EqualTo(NameOfDonaldDuck));

            firstUser.Name = NameOfDonaldDuck;
            UserRepository.Execute(new UpdateUserCommand(firstUser));

            // get user again, no cheating
            firstUser = UserRepository.Query(m => m.Users.First(u => u.UserId == firstUser.UserId));
            Assert.That(firstUser.Name, Is.EqualTo(NameOfDonaldDuck));
        }

        [TearDown]
        public new void TearDown()
        {
            base.TearDown();
        }
    }
}
