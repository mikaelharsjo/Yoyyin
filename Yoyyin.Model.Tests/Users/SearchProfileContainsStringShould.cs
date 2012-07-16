using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Yoyyin.Model.Users.Entities;

namespace Yoyyin.Model.Tests.Users
{
    [TestFixture]
    public class SearchProfileContainsStringShould
    {
        [Test]
        public void MatchExactStrings()
        {
            SearchProfile searchProfile = new SearchProfile
                                              {
                                                  CompetencesNeeded = new string[] {"springa", "gå", "krypa"},
                                                  SearchWords = new string[] {"apa"}
                                              };
            Assert.That(searchProfile.ContainsString("krypa"), Is.EqualTo(true));
        }

        [Test]
        public void MatchPartialStrings()
        {
            SearchProfile searchProfile = new SearchProfile
            {
                CompetencesNeeded = new string[] { "springa", "gå", "krypa" },
                SearchWords = new string[] { "apa" }
            };
            Assert.That(searchProfile.ContainsString("k"), Is.EqualTo(true));
        }
    }
}
