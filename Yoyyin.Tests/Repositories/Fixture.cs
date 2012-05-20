using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Yoyyin.Data;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Tests.Fakes.Repositories;

namespace Yoyyin.Tests.Repositories
{
    [TestFixture]
    public class Fixture
    {
        private IUserRepository _testUserRepository;
        
        [SetUp]
        public void Setup()
        {
            _testUserRepository = new FakeUserRepository();    
        }

        [Test]
        public void GetUsersBySniHead_HappyPath()
        {
            //Assert.That(_testUserRepository.Find(() => ()).ElementAt(0).Name, Is.EqualTo("Kalle Anka"));
        }

        [Test]
        public void TEST()
        {
            //Assert.That(_testUserRepository.Find().First(user => user.UserId == new Guid("11111111-1111-1111-1111-111111111111")).Name, Is.EqualTo("Kalle Anka"));
        }
    }
}
