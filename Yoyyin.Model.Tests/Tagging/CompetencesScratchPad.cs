using System.Linq;
using System.Text;
using Kiwi.Prevalence;
using NUnit.Framework;
using Yoyyin.Model.Tagging;
using Yoyyin.Model.Users;

namespace Yoyyin.Model.Tests.Tagging
{
    [TestFixture]
    public class CompetencesScratchPad
    {
        [Test]
        public void Test()
        {
            var modelFactory = new ModelFactory<UserModel>(() => new UserModel()); // {OnRestore = model => model.Invalidate()};
            UserRepository userRepository = new UserRepository(new RepositoryConfiguration(), modelFactory) { Path = @"c:\temp\yoyyin\users" };

            var allCompetences = userRepository
                .Query(m => m.Users.Select(u => u.Ideas.First().SearchProfile.Competences));

            WeightedTags tags = new WeightedTags();
            tags.Add(allCompetences);

            tags.Print();
            
            Assert.That(allCompetences.Count(), Is.GreaterThanOrEqualTo(40));
        }
    }
}
