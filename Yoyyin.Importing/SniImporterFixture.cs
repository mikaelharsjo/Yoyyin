using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Yoyyin.Importing
{
    [TestFixture]
    public class SniImporterFixture
    {
        [Test]
        public void Test()
        {
            SniImporter sniImporter = new SniImporter();
            Assert.That(sniImporter.Import().Count(), Is.AtLeast(10));

        }
    }
}
