using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Model.Users.ValueObjects;

namespace Yoyyin.Importing
{
    [TestFixture]
    public class SniImporterFixture
    {
        [Test]
        public void Test()
        {
            SniImporter sniImporter = new SniImporter();
            var importedSnis = sniImporter.Import();
            Assert.That(importedSnis.Count(), Is.AtLeast(10));

            foreach(Sni sni in importedSnis)
            {
                Console.WriteLine(string.Format("SniNo: {0} SniTitel: {1} Snigrupp: {2} SniGruppId: {3}", sni.SniItem.SniNo, sni.SniItem.Title, sni.SniHead.Title, sni.SniHead.SniHeadId));
            }
        }
    }
}
