using System.Linq;
using NUnit.Framework;

namespace Yoyyin.Model.Tests
{
    [TestFixture]
    public class ModelIndexes : SetupFixture
    {
        [SetUp]
        public new void Setup()
        {
            base.Setup();    
        }

        [Test]
        public void Test()
        {
            //Repo.Query()
            Assert.That(UserRepository.Model.QuestionsByUser[UserRepository.Query(m => m.Users.First()).UserId].Count(), Is.EqualTo(5));
        }

        [TearDown]
        public new void TearDown()
        {
            base.TearDown();
        }
    }
}
