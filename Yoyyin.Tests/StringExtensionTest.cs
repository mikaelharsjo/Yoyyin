using NUnit.Framework;
using Yoyyin.Domain.Extensions;

namespace Yoyyin.Tests
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [Test]
        public void TruncateWithDots()
        {
            string input = "En jättelång sträng";
            string actual = input.Truncate(12);

            Assert.That(actual, Is.EqualTo("En jättelång..."));
        }

        [Test]
        public void TruncateCompleteWord()
        {
            string input = "Sträng med flera ord";
            string actual = input.Truncate(8);

            Assert.That(actual, Is.EqualTo("Sträng..."));
        }

        [Test]
        public void DontTruncate()
        {
            Assert.That("apa".Truncate(1000), Is.EqualTo("apa"));
        }
    }
}
