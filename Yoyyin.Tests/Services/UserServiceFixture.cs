using System;
using NUnit.Framework;
using Yoyyin.Domain.Services;
using Yoyyin.Tests.Fakes;
using Yoyyin.Tests.Fakes.Repositories;
using Yoyyin.Tests.Repositories;

namespace Yoyyin.Tests.Services
{
    [TestFixture]
    public class UserServiceFixture
    {
        private IUserService _userService;

        [SetUp]
        public void SetUp()
        {
            _userService = new UserService(new FakeUserRepository(), new FakeCurrentUser());
        }

        [Test]
        public void Test()
        {
            //Assert.That(_userService.GetUsersWithSniHeadOf("A").Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetUser()
        {
            //Assert.That(_userService.GetUser(new Guid("11111111-1111-1111-1111-111111111111")).Name, Is.EqualTo("Kalle Anka"));
        }
    }
}
