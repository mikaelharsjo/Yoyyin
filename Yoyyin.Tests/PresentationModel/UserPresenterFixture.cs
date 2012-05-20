using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;
using Yoyyin.Domain.Services;
using Yoyyin.PresentationModel;
using Yoyyin.Tests.Fakes.Repositories;
using Yoyyin.Tests.Repositories;
using Yoyyin.Tests.Services;

namespace Yoyyin.Tests.PresentationModel
{
    [TestFixture]
    public class UserPresenterFixture
    {
        private UserPresenter _userPresenter;

        [SetUp]
        public void Setup()
        {
            _userPresenter =
                new UserPresenter(new OnlineImageProvider(), new FakeUserRepository());
        }

        [Test]
        public void Convert_UserWithImage_ShouldStillHaveUserForPerformanceReasons()
        {
            var bf = new BinaryFormatter();
            var ms = new MemoryStream();

            const string original = "喂 Hello 谢谢 Thank You";
            bf.Serialize(ms, original);
            ms.Seek(0, 0);
            byte[] bytes = ms.ToArray();
            
            var userToConvert = new User {Name = "Kalle", Image = bytes };

            Assert.That(userToConvert.Image, !Is.Null);
            
            var actualUserView = _userPresenter.Presentate(userToConvert);
            Assert.That(actualUserView.User.Image, Is.EqualTo(userToConvert.Image));
        }

        [Test]
        public void Presentate_UserGuids()
        {
            var userGuids = new List<Guid> { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("22222222-2222-2222-2222-222222222222") };
            var users = _userPresenter.Presentate(userGuids);
            Assert.That(users.ElementAt(0).DisplayName, Is.EqualTo("Kalle Anka"));
        }
    }
}
