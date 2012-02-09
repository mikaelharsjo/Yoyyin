using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Yoyyin.Domain.Services;

namespace Yoyyin.Tests.Services
{
    [TestFixture]
    public class UserServiceFixture
    {
        private IUserService _userService;

        [SetUp]
        public void SetUp()
        {
            _userService = new UserService(new TestUserRepository(), new FakeCurrentUser());
        }

        [Test]
        public void Test()
        {
            Assert.That(_userService.GetUsersWithSniHeadOf("A").Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetUser()
        {
            Assert.That(_userService.GetUser(new Guid("11111111-1111-1111-1111-111111111111")).Name, Is.EqualTo("Kalle Anka"));
        }
    }
}
