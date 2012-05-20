using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Yoyyin.Data;
using Yoyyin.Domain;
using Yoyyin.PresentationModel;
using Yoyyin.Tests.Fakes;
using Yoyyin.Tests.Services;

namespace Yoyyin.Tests
{
    [TestFixture]
    public class ViewDomainTest
    {
        private AnswerPresenter _answerConverter;

        [SetUp]
        public void Setup()
        {
            _answerConverter = new AnswerPresenter(new FakeCurrentUser());
        }

        [Test]
        public void ConvertAnswersToView()
        {
            var answers = new List<Answer>
                              {
                                  {
                                      new Answer
                                          {
                                              Text = "apa",
                                              Created = new DateTime(2010, 12, 31),
                                              User = new User() {Alias = "Hemliga Arne"}
                                          }
                                      },
                                  {
                                      new Answer
                                          {
                                              Text = "kossa",
                                              Created = new DateTime(1999, 01, 01),
                                              User = new User() {Alias = "Hemliga Sune"}
                                          }
                                      }
                              };
            var questionAnswers = _answerConverter.Presentate(answers);
            Assert.That(questionAnswers.Count(), Is.EqualTo(answers.Count));
            
        }

        [Test]
        public void ConvertCommentToViewHeading()
        {
            var commentConverter = new CommentPresenter(new FakeCurrentUser());
            var comment = new Comment
                              {
                                           Created = new DateTime(2011, 5, 8, 21, 40, 0),
                                           User = new User { Name = "Peter Hansson" }
                                       };
            var convertedComment = commentConverter.Presentate(comment);
            Assert.That(convertedComment.Heading, Is.EqualTo("Peter Hansson söndag 08 maj 2011 21:40"));
        }

        [Test]
        public void ConvertMessageToView()
        {
            var message = new Message
                              {
                                  User = new User() {Name = "Kalle"},
                                  FromMessage = "Hej på dig",
                                  Created = new DateTime(2000, 11, 11, 16, 40, 0)
                              };
            var messageConverter = new MessagePresenter();
            MessagePresentation messagePresentation = messageConverter.Presentate(message);
            Assert.That(messagePresentation.Date, Is.EqualTo("lördag 11 november 2000 16:40"));
            Assert.That(messagePresentation.Message, Is.EqualTo("Hej på dig"));
            Assert.That(messagePresentation.DisplayName, Is.EqualTo("Kalle"));
        }
    }

}
