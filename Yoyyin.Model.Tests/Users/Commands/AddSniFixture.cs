using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Model.Users.Commands;
using Yoyyin.Model.Users.ValueObjects;

namespace Yoyyin.Model.Tests.Users.Commands
{
    [TestFixture]
    public class AddSniFixture : SetupFixture
    {
        [SetUp]
        public void Setup()
        {
            base.Setup();
        }

        [Test]
        public void Add()
        {
            Assert.That(UserRepository.Query(model => model.SniHeads).Count(), Is.EqualTo(0));

            UserRepository.Execute(
                new AddSniHeadCommand(new SniHead
                                          {
                                              SniHeadId = "1",
                                              Title = "Ett",
                                              Items = new[] {new SniItem {SniNo = "A", Title = "Title"}}
                                          }));

            Assert.That(UserRepository.Query(model => model.SniHeads).Count(), Is.EqualTo(1));
        }


    }
}
