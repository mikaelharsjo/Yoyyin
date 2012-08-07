using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Yoyyin.Model.Matching;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Model.Users.Entities;
using Yoyyin.Model.Users.Enumerations;
using Yoyyin.Model.Users.ValueObjects;

namespace Yoyyin.Model.Tests.Matching
{
    [TestFixture]
    public class MatcherMatchShould
    {
        private Matcher _matcher;

        [Test]
        public void CheckLookingFor()
        {
            var userLookingForPartnerToMyIdea = new User {LookingFor = new LookingFor {PartnerToMyIdea = true}};
            var userLookingForIdeasToJoin = new User {LookingFor = new LookingFor {IdeasToJoin = true}};
            var userJoinOrBeJoined = new User {LookingFor = new LookingFor {JoinOrBeJoined = true}};
            var userLookingForInvestements = new User {LookingFor = new LookingFor {Investements = true}};

            _matcher = new Matcher(userLookingForPartnerToMyIdea, userLookingForPartnerToMyIdea);
            Assert.That(_matcher.MatchLookingFor().IsMatch, Is.EqualTo(new DoesNotMatch().IsMatch));

            Assert.That(userLookingForIdeasToJoin.LookingFor.MatchWith(userLookingForPartnerToMyIdea.LookingFor), Is.EqualTo(true));
        }

        [Test]
        public void CheckUserType()
        {
            var userDeveloper = new User {UserType = 1};
            var userLookingForDeveloper = new User
                                              {
                                                  Ideas = new List<Idea>
                                                          {
                                                              new Idea
                                                                  {
                                                                      SearchProfile = new SearchProfile
                                                                              {
                                                                                  UserTypesNeeded = new UserTypesNeeded
                                                                                          {
                                                                                              UserTypeIds = new[] {1, 2, 3}
                                                                                          }
                                                                              }
                                                                  }
                                                          }
                                              };

            _matcher = new Matcher(userDeveloper, userLookingForDeveloper);
            Assert.That(_matcher.MatchUserType().IsMatch, Is.EqualTo(true));

            _matcher = new Matcher(new User(), userLookingForDeveloper);
            Assert.That(_matcher.MatchUserType().IsMatch, Is.EqualTo(false));
            
        }
    }
}
