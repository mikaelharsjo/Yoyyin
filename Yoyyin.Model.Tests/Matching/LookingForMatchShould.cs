using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Yoyyin.Model.Users.ValueObjects;

namespace Yoyyin.Model.Tests.Matching
{
    [TestFixture]
    public class LookingForMatchShouldBe
    {
        [Test]
        public void TrueIfBothAreOpenToJoinOrBeJoined()
        {
            LookingFor joinOrBeJoined = new LookingFor {JoinOrBeJoined = true};

            Assert.That(joinOrBeJoined.MatchWith(joinOrBeJoined), Is.EqualTo(true));
        }

        [Test]
        public void TrueIfInvesterAndFinancer()
        {
            LookingFor investor = new LookingFor {Investements = true};
            LookingFor financing = new LookingFor {Financing = true};

            Assert.That(investor.MatchWith(financing), Is.EqualTo(true));
        }

        [Test]
        public void FalseIfBothHaveIdeas()
        {
            LookingFor partnerToMyIdea = new LookingFor {PartnerToMyIdea = true};

            Assert.That(partnerToMyIdea.MatchWith(partnerToMyIdea), Is.EqualTo(false));
        }
    }
}
