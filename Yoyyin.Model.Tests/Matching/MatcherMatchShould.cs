using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Yoyyin.Model.Matching;
using Yoyyin.Model.Matching.MatchResult;
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
            var user1= new User {UserType = 1};
            var userLookingFor1 = new User
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

            _matcher = new Matcher(user1, userLookingFor1);
            var matchResult = _matcher.MatchUserType();
            Assert.That(matchResult.IsMatch, Is.EqualTo(true));
            var userTypeMatch = matchResult as UserTypeMatch;
            Assert.That(userTypeMatch.UserType, Is.EqualTo(1));
            Assert.That(userTypeMatch.SecondUserTypes.Count(), Is.EqualTo(3));

            _matcher = new Matcher(new User(), userLookingFor1);
            Assert.That(_matcher.MatchUserType().IsMatch, Is.EqualTo(false));
        }

        [Test]
        public void CheckUserTypesNeeded()
        {
            var user1 = new User { UserType = 1 };
            var userLookingFor1 = new User
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

            _matcher = new Matcher(userLookingFor1, user1);
            var matchResult = _matcher.MatchUserTypesNeeded();
            Assert.That(matchResult.IsMatch, Is.EqualTo(true));
        }

        [Test]
        public void CheckCompetencesNeeded()
        {
            var userSeeksDesign = new User
            {
                Ideas = new[]
                                                  {
                                                      new Idea
                                                          {
                                                              SearchProfile = new SearchProfile {CompetencesNeeded = new[] {"design"}}
                                                          }
                                                  }
            };
            var designer = new User {Competences = new[] {"design"}};


            _matcher = new Matcher(userSeeksDesign, designer);
            Assert.That(_matcher.MatchCompetencesNeeded().IsMatch, Is.EqualTo(true));
            
        }
    }
}
