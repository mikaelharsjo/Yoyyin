using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Yoyyin.Data;
using Yoyyin.Domain.Matching;
using Yoyyin.Domain.Services;
using Yoyyin.Domain.Users;
using Yoyyin.Tests.Repositories;
using Yoyyin.Tests.Services;
using UserTypes = Yoyyin.Domain.Enumerations.UserTypes;

namespace Yoyyin.Tests
{
    [TestFixture]
    public class MultipleMatcherFixture
    {
        ////[MethodName_StateUnderTest_ExpectedBehavior]
        [Test]
        public void MatchAll_TwoUsers_ShouldMatchOnSni()
        {
            var multipleMatcher = new MultipleMatcher(new User {SniNo = "A"},
                                                      new List<User> {new User {SniNo = "A"}},
                                                      new UserService(new TestUserRepository(), new FakeCurrentUser()));
                                                                      

            var matchers = multipleMatcher.MatchAll();
            Assert.That(matchers.First().SniNoMatch.IsMatch(), Is.EqualTo(true));
        }

        [Test]
        public void MatchAll_4Users_3MatchOnSniHead()
        {
            var multipleMatcher = MultipleMatcherTestSetup();

            var matchers = multipleMatcher.MatchAll().ToList();
            Assert.That(matchers.ElementAt(0).SniNoMatch.IsMatch()); 
            Assert.That(matchers.ElementAt(3).SniNoMatch.IsMatch(), Is.EqualTo(false));
        }

        [Test]
        public void GetMatchingMembers_ReturnOnlyMatches_3UsersShouldBeReturned()
        {
            var multipleMatcher = MultipleMatcherTestSetup();
            var matches = multipleMatcher.GetSuccesFullMatches();
            Assert.That(matches.Count(), Is.EqualTo(3));
        }

        private static MultipleMatcher MultipleMatcherTestSetup()
        {
            var multipleMatcher =
                new MultipleMatcher((IUser) new User {SniNo = "A", UserTypesNeeded = UserTypes.Entrepreneur.ToString()},
                                    new List<IUser>
                                        {
                                            (IUser)
                                            new User
                                                {
                                                    Name = "MatchesSniNo",
                                                    SniNo = "A",
                                                    UserType = (int) UserTypes.Businessman
                                                },
                                            (IUser)
                                            new User
                                                {
                                                    Name = "MatchesSniNo",
                                                    SniNo = "A",
                                                    UserType = (int) UserTypes.Retiring
                                                },
                                            (IUser)
                                            new User
                                                {
                                                    Name = "MatchesSniNoAndUserType",
                                                    SniNo = "A",
                                                    UserType = (int) UserTypes.Entrepreneur
                                                },
                                            (IUser) new User {Name = "NoMatch", SniNo = "B"}
                                        },
                                    new UserService(new TestUserRepository(), new FakeCurrentUser()));
            return multipleMatcher;
        }

        [Test]
        public void GetMatchStats_HappyPath_3OutOf4ShouldMatch_()
        {
            var multipleMatcher = MultipleMatcherTestSetup();

            MultipleMatcherStats stats = multipleMatcher.GetStats();
            Assert.That(stats.Matched, Is.EqualTo(3));
            Assert.That(stats.Tried, Is.EqualTo(4));
        }

        [Test]
        public void GetMatchingMembers_SortByWeight_MatchesSniNoAndUserTypeShoulComeFirst()
        {
            var multipleMatcher = MultipleMatcherTestSetup();
            var matches = multipleMatcher.GetSuccesFullMatches();

            Assert.That(matches.ElementAt(0).GetMatchingUser().Name, Is.EqualTo("MatchesSniNoAndUserType"));
        }

        //[Test]
        //public void GetMatchingMembers_HowToDataBind_3ShouldMatch()
        //{
        //    var multipleMatcher = MultipleMatcherTestSetup();
        //    var matches = multipleMatcher.GetSuccesFullMatches();
           
        //}
    }
}
