using NUnit.Framework;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.Matching;
using Yoyyin.Domain.Sni;
using Yoyyin.Domain.Users;
using UserTypes = Yoyyin.Domain.Enumerations.UserTypes;

namespace Yoyyin.Tests.Matching
{
    [TestFixture]
    public class MatcherFixture
    {
        [Test]
        public void SuccesFullMatchSniHeadTest()
        {
            var user = new User() {SniHeadID = "A", SniHead = new SniHead(){Title = "IT & Kommunikation"}};
            var user2 = new User() { SniHeadID = "A", SniHead = new SniHead(){Title = "IT & Kommunikation"}};
            
            var matcher = new Matcher(user as IUser, user2 as IUser);
            Assert.That(matcher.SniHeadMatch.IsMatch(), Is.EqualTo(true));
        }

        [Test]
        public void UnSuccesFullMatchSniHeadTest()
        {
            var user = new User() { SniHeadID = "A", SniHead = new SniHead() { Title = "IT & Kommunikation" } };
            var user2 = new User() { SniHeadID = "B", SniHead = new SniHead() { Title = "tes" } };

            var matchResult = new Matcher(user, user2);
            Assert.That(matchResult.SniHeadMatch.IsMatch(), Is.EqualTo(false));
        }

        [Test]
        public void SuccesFullMatchSniNo()
        {
            var user = new User() { SniNo = "1", SniItem = new SniItem() {Title= "test"} };
            var user2 = new User() { SniNo = "1", SniItem = new SniItem() { Title = "test" } };

            var matcher = new Matcher(user, user2);
            Assert.That(matcher.SniNoMatch.IsMatch(), Is.EqualTo(true));
        }

        [Test]
        public void UnSuccesFullMatchSniNo()
        {
            var user = new User() { SniNo = "1", SniItem = new SniItem() { Title = "test" } };
            var user2 = new User() { SniNo = "2", SniItem = new SniItem() { Title = "test2" } };

            var matchResult = new Matcher(user, user2);
            Assert.That(matchResult.SniNoMatch.IsMatch(), Is.EqualTo(false));
        }

        #region search words

        [Test]
        public void SuccesFullMatchSearchWords()
        {
            var user = new User() { SearchWords = "kossa,apa" };
            var user2 = new User() { SearchWords = "kossa" };

            var matchResult = new Matcher(user, user2);
            Assert.That(matchResult.SearchWordsMatchResult.IsMatch(), Is.EqualTo(true));
        }

        [Test]
        public void SuccesFullMatchWithValue()
        {
            const string actual = "investmentbolag, socialt ansvarstagande, samhällsutveckling, crowdsourcing";
            var user = new User() { SearchWords = "investmentbolag, socialt ansvarstagande, samhällsutveckling, crowdsourcing" };
            var user2 = new User() { SearchWords = "programmering, iphone" };

            var matchResult = new Matcher(user, user2);
            Assert.That(matchResult.SearchWordsMatchResult.IsMatch(), Is.EqualTo(false));
            Assert.That(matchResult.SearchWordsMatchResult.FirstValue, Is.EqualTo(actual));
        }

        [Test]
        public void SuccesFullMatchExactlyOneSearchWord()
        {
            var user = new User() { SearchWords = "investmentbolag" };
            var user2 = new User() { SearchWords = "investmentbolag" };

            var matchResult = new Matcher(user, user2);
            Assert.That(matchResult.SearchWordsMatchResult.IsMatch(), Is.EqualTo(true));
        }

        [Test]
        public void SuccesFullMatchSearchWords2()
        {
            var user = new User() { SearchWords = "kossa,apa,höna, penna,sak,dator" };
            var user2 = new User() { SearchWords = "mat,kossa" };

            var matchResult = new Matcher(user, user2);
            Assert.That(matchResult.SearchWordsMatchResult.IsMatch(), Is.EqualTo(true));
        }

        [Test]
        public void UnSuccesFullMatchSearchWords()
        {
            var user = new User() { SearchWords = "bajs,apa" };
            var user2 = new User() { SearchWords = "kossa" };

            var matchResult = new Matcher(user, user2);
            Assert.That(matchResult.SearchWordsMatchResult.IsMatch(), Is.EqualTo(false));
        }

        [Test]
        public void UnSuccesFullMatchSearchWordsCompetenceSameCompetence()
        {
            var user = new User() { SearchWordsCompetence = "köra truck,mata djur", SearchWordsCompetenceNeeded = "laga mat"};
            var user2 = new User() { SearchWordsCompetenceNeeded = "äta barn", SearchWordsCompetence = "mata djur" };

            var matchResult = new Matcher(user, user2);
            Assert.That(matchResult.SearchWordsCompetenceMatch.ToString(), Is.EqualTo("False"));
        }

        [Test]
        public void SuccesFullMatchSearchWordsCompetence()
        {
            var user = new User() { SearchWordsCompetence = "köra truck,mata djur", SearchWordsCompetenceNeeded = "laga mat" };
            var user2 = new User() { SearchWordsCompetenceNeeded = "äta barn", SearchWordsCompetence = "laga mat" };

            var matchResult = new Matcher(user, user2);
            Assert.That(matchResult.SearchWordsCompetenceMatch.ToString(), Is.EqualTo("True,laga mat"));
        }

        [Test]
        public void EmptyStringSearchWordsCompetenceShouldNotMatch()
        {
            var user = new User() { SearchWordsCompetence = "köra truck,mata djur" };
            var user2 = new User() { SearchWordsCompetenceNeeded = "" };

            var matchResult = new Matcher(user, user2);
            Assert.That(matchResult.SearchWordsCompetenceMatch.IsMatch(), Is.EqualTo(false));
        }

        [Test]
        public void EmptyStringSearchWordsShouldNotMatch()
        {
            var user = new User() { SearchWords = "köra truck,mata djur" };
            var user2 = new User() { SearchWords = "" };

            var matchResult = new Matcher(user, user2);
            Assert.That(matchResult.SearchWordsMatchResult.IsMatch(), Is.EqualTo(false));
        }

        #endregion

        #region User types

        [Test]
        public void SuccesFullMatchUserTypes()
        {
            var user = new User { UserType = (int)UserTypes.Businessman, UserTypesNeeded = "1,4" };
            var user2 = new User {UserType = (int)UserTypes.Retiring};

            var matchResult = new Matcher(user, user2);

            Assert.That(matchResult.UserTypeMatch.IsMatch(), Is.EqualTo(true));
        }

        [Test]
        public void Match_UserTypes_ShouldFail()
        {
            var user = new User() { UserType = 0, UserTypesNeeded = "1,5" };
            var user2 = new User() { UserType = 0 };

            var matcher = new Matcher(user, user2);

            Assert.That(matcher.UserTypeMatch.IsMatch(), Is.EqualTo(false));
        }

        [Test]
        public void MatchUserTypesWithOutput()
        {
            var user = new User() { UserTypesNeeded = UserTypes.Innovator.ToString() };
            var user2 = new User() { UserType = (int)UserTypes.Innovator };

            var matcher = new Matcher(user, user2);

            string actualFirstValue = matcher.UserTypeMatch.FirstValue;
            string expectedFirstValue = UserTypes.Innovator.GetTitle();
            Assert.That(actualFirstValue, Is.EqualTo(expectedFirstValue));

            string actualSecondValue = matcher.UserTypeMatch.SecondValue;
            string expectedSecondValue = UserTypes.Innovator.GetTitle();
            Assert.That(actualSecondValue, Is.EqualTo(expectedSecondValue));

            Assert.That(matcher.UserTypeMatch.IsMatch(), Is.EqualTo(true) );
        }

        #endregion

        [Test]
        public void GetMatchCount_CountReturned_ShouldBe2()
        {
            var user = new User() { UserType = 0, UserTypesNeeded = "1,5", SniNo="A"};
            var user2 = new User() { UserType = 5, SniNo = "A" };

            var matchResult = new Matcher(user, user2);

            Assert.That(matchResult.GetMatchCount(), Is.EqualTo(2));
        }

        //[Test]
        //public void GetResultsAsHtmlTable()
        //{
        //    InitializeUsers();

        //    var matcher = new Matcher(_anders, _peter);
        //    var actual = matcher.GetResultsAsHtmlTable();

        //    Assert.That(actual != null);
        //}
    }
}
