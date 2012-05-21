using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;
using Yoyyin.Domain.Matching;
using Yoyyin.Domain.Sni;
using Yoyyin.Domain.Users;

namespace Yoyyin.Tests.Matching
{
    [TestFixture]
    public class Matcher_GetResultsAsHtmlTableShould
    {
        [Test]
        public void Test()
        {
            Matcher matcher = new Matcher(new User { SniHeadID = "1", SniHead = new SniHead {Title = "Test"}} as IUser, // macth is done on SniHeadID
                                          new User {SniHeadID = "1", SniHead = new SniHead {Title = "Test"}} as IUser);

            Assert.That(matcher.GetResultsAsHtmlTable(),  Is.StringStarting("<table><tr><td class='matchTableFirstCell'><td class='matchTableContentCell'>Test</td>"));
        }
    }
}
