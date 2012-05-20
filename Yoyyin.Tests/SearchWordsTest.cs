using System.Collections.Generic;
using NUnit.Framework;
using Yoyyin.Data;
using Yoyyin.Domain;
using Yoyyin.Domain.SearchWords;
using Yoyyin.Tests.Fakes;

namespace Yoyyin.Tests
{
    [TestFixture]
    class SearchWordsTest
    {
        //[Test]
        //public void SearchWordsShouldSplitOnComma()
        //{
        //    var searchWordsHandler = new SearchWordsHandler(new List<string>() { "apa, kossa, kamel"});
        //    var actual = searchWordsHandler.GetAllSearchWords(); 
        //    var expected = new List<string>() {"apa", "kamel", "kossa"};

        //    Assert.That(actual.ToList(), Is.EqualTo(expected));
            
        //}

        //[Test]
        //public void SearchWordsShouldSplitOnCommaWithWhiteSpaces()
        //{
        //    var searchWordsHandler = new SearchWordsHandler(new List<string>() { "apa,kossa, kamel" });
        //    var actual = searchWordsHandler.GetAllSearchWords();
        //    var expected = new List<string>() { "apa", "kamel", "kossa" };

        //    Assert.That(actual.ToList(), Is.EqualTo(expected));
        //}

        //[Test]
        //public void MultipleSearchWordsShouldSplitOnComma()
        //{
        //    var searchWordsHandler = new SearchWordsHandler(new List<string>() { "apa, kossa, kamel", "dinosaurie" });
        //    var actual = searchWordsHandler.GetAllSearchWords();
        //    var expected = new List<string>() { "apa", "dinosaurie", "kamel", "kossa" };
        //    Assert.That(actual, Is.EqualTo(expected));
        //}

        //[Test]
        //public void SearchWordsShouldRemoveDuplicates()
        //{
        //    var searchWordsHandler = new SearchWordsHandler(new List<string>() { "apa, kossa, apa", "dinosaurie" });
        //    var actual = searchWordsHandler.GetAllSearchWords();
        //    var expected = new List<string>() { "apa", "dinosaurie", "kossa" };
        //    Assert.That(actual, Is.EqualTo(expected)); 
        //}

        //[Test]
        //public void SearchWordsSortedByWeight()
        //{
        //    var searchWordsHandler = new SearchWordsHandler(new List<string>() { "zebra", "apa, kossa, apa", "dinosaurie", "apa, kossa, apa", "kamel" });
        //    var actual = searchWordsHandler.GetAllSearchWords();
        //    var expected = new List<string>() {"apa", "kossa", "zebra", "dinosaurie", "kamel"};

        //    Assert.That(actual.ToList(), Is.EqualTo(expected));
        //}

        [Test]
        public void CometencesSearchWordsProvider_InputWithDuplicates_DuplicatesRemoveInOutput()
        {
            var competencesSearchWordsProvider =
                new CompetencesSearchWordsProvider(new CachedItemProvider<IList<string>>(), new FakeWordsProvider());
            var searchWords = competencesSearchWordsProvider.GetWords();
            var expected = new List<string>() {"apa"};

            Assert.That(searchWords, Is.EqualTo(expected));
            
        }
    }
}
