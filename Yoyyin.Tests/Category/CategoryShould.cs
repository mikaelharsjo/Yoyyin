using System.Linq;
using System.Text;
using NUnit.Framework;
using Yoyyin.Domain.QA;
using Yoyyin.Domain.Services;

namespace Yoyyin.Tests.Category
{
    [TestFixture]
    public class CategoryShould
    {
        private ICategory _category;
        private IQAService _qaService;

        [SetUp]
        public void Setup()
        {
            _qaService = new TestQAService();
        }

        [Test]
        public void HaveTitleAccordingToType()
        {
             _category = new BusinessIdeasCategory(_qaService);
            Assert.That(_category.Title, Is.EqualTo("Affärsidéer"));
        }

        [Test]
        public void HaveDescriptionAccordintToType()
        {
            _category = new FriendlyCategory(_qaService);
            Assert.That(_category.Description, Is.EqualTo("Här behöver inte affärsidéen vara hundra genomtänkt. Feedbacken ska vara positiv. Försök gärna förbättra affärsidéerna men säg inte att dom är dåliga."));
        }

        [Test]
        public void HaveIdAccordingToType()
        {
            _category = new MiscCategory(_qaService);
            Assert.That(_category.CategoryId, Is.EqualTo(2));
        }

        [Test]
        public void HaveAQuestionInCategoryBusinessIdeas()
        {
            _category = new BusinessIdeasCategory(_qaService);
            Assert.That(_category.GetLatestQuestion().Title, Is.EqualTo("senaste frågan"));
        }

        [Test]
        public void Have2QuestionsInBusinessIdeas()
        {
            _category = new BusinessIdeasCategory(_qaService);
            Assert.That(_category.GetQuestions().Count(), Is.EqualTo(2));
        }
    }
}
