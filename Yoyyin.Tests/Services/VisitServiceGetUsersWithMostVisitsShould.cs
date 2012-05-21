using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Yoyyin.Data;
using Yoyyin.Data.EntityFramework.Repositories;
using Yoyyin.Domain.Services;
using Yoyyin.Tests.Fakes.Repositories;
using Yoyyin.Tests.Repositories;

namespace Yoyyin.Tests.Services
{
    [TestFixture]
    public class VisitServiceGetUsersWithMostVisitsShould
    {
        private VisitsService _visitsService;

        [SetUp]
        public void Setup()
        {
            _visitsService = new VisitsService(new FakeVisitRepository(), new FakeUserRepository());
        }

        // should
        [Test]
        public void ShouldSortAsKalleLassePelle()
        {
            var users = _visitsService.GetUsersWithMostVisits();
            var expected = new[]
                         {
                             new User {Name = "Kalle"},
                             new User {Name = "Pelle"},
                             new User {Name = "Lasse"}

                         };

            //Assert.That(users, Is.EqualTo(expected));

            //Assert.That(users.ElementAt(0).Name, Is.EqualTo("Kalle"));
            //Assert.That(users.ElementAt(1).Name, Is.EqualTo("Lasse"));
            Assert.That(users.ElementAt(2).Name, Is.EqualTo("Pelle"));
        }
    }
}
