using System.Linq;
using NUnit.Framework;
using Yoyyin.Model.Users;

namespace Yoyyin.Model.Tests.Commands
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
            var firstUser = Repo.Query(m => m.Users.First());
            Assert.That(firstUser.Name, Is.Not.EqualTo(NameOfDonaldDuck));

            firstUser.Name = NameOfDonaldDuck;
            Repo.Execute(new UpdateUserCommand(firstUser));

            // get user again, no cheating
            firstUser = Repo.Query(m => m.Users.First(u => u.UserId == firstUser.UserId));
            Assert.That(firstUser.Name, Is.EqualTo(NameOfDonaldDuck));
        }

        [TearDown]
        public new void TearDown()
        {
            base.TearDown();
        }
    }
}
