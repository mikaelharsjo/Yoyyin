using System;
using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using Kiwi.Prevalence;
using NUnit.Framework;
using Yoyyin.Importing;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Model.Users.Commands;
using Yoyyin.Model.Users.Commands.Questions;
using Yoyyin.Model.Users.Entities;

namespace Yoyyin.Model.Tests
{
    [TestFixture]
    public class SetupFixture
    {
        public Repository<UserModel> Repo;
        private User _firstUser;

        [SetUp]
        public void Setup()
        {
            var modelFactory = new ModelFactory<UserModel>(() => new UserModel()); // {OnRestore = model => model.Invalidate()};
            Repo =
                new DevelopmentUserRepository(new RepositoryConfiguration(), modelFactory, new UserImporter());
                    //{Path = @"c:\Temp\yoyyin"};

            //Repo.InitializeWithDataFromSql();
            

            //Add5QuestionsAndAnswersPerUser(users);

            Console.Out.WriteLine("Revision is now {0}", Repo.Revision);
            //Console.Out.WriteLine("Model size is {0}", _repo.Query(m => m.Users.Count));
        }

        private void Add5QuestionsAndAnswersPerUser(IEnumerable<User> users)
        {
            // let each user ask 5 questions, and answer it 5 times
            Queue<Question> questions = new Queue<Question>();
            Builder<Question>
                .CreateListOfSize(5000)
                .All()
                .Build()
                .ToList()
                .ForEach(questions.Enqueue);

            Queue<Answer> answers = new Queue<Answer>();
            Builder<Answer>
                .CreateListOfSize(25000)
                .All()
                .Build()
                .ToList()
                .ForEach(answers.Enqueue);

            foreach (User user in users)
            {
                for (int i = 0; i < 5; i++)
                {
                    Question question = questions.Dequeue();

                    for (int j = 0; j < 5; j++)
                    {
                        Answer answer = answers.Dequeue();
                        answer.UserId = user.UserId;
                        question.Answers.Add(answer);
                    }

                    question.UserId = user.UserId;
                    Repo.Execute(new AddQuestionCommand(question));
                }
            }
        }

        private IList<User> AddAThousandUsers()
        {
            var users = Builder<User>
                .CreateListOfSize(1000)
                .Build();

            foreach (var user in users)
            {
                Repo.Execute(new AddUserCommand(user));
            }
            return users;
        }

        [Test]
        public void TestQuery()
        {
                
        //    Console.Out.WriteLine("Revision is now {0}", Repo.Revision);
        //    //Assert.That(_repo.Query(m => m.Questions).Count(), Is.EqualTo(5000));
        //    //Assert.That(_repo.Query(m => m.Users).Count(), Is.EqualTo(1000));

        //    // first users question count
        //    Assert.That(Repo.Query(m => m.Questions.Where(q => q.UserId == (Repo.Query(x => x.Users.First()).UserId))).Count(), Is.EqualTo(5));
        }

        //[Test]
        //public void FirstUserHaveAsked10Questions()
        //{
        //    _firstUser = _repo.Query(u => u.Users.First());
        //    var questionCount = _repo.Query(q => q.Questions.Where(question => question.UserId == _firstUser.UserId)).Count();

        //    Assert.That(questionCount, Is.EqualTo(10));
        //}

        //[Test]
        //public void FirstQuestionIsAnswered5Times()
        //{
        //    Assert.That(_repo.Query(q => q.Questions.First().Answers.Count()), Is.EqualTo(5));
        //}

        [TearDown]
        public void TearDown()
        {
            foreach (User user in Repo.Query(model => model.Users))
            {
                foreach(var propInfo in user.GetType().GetProperties())
                {
                    Console.Out.WriteLine(string.Format("{0}: {1}", propInfo.Name, propInfo.GetValue(user, null) ) );
                }
                //Console.Out.WriteLine("User.Name: {0}", user.Name);
                //Console.Out.WriteLine("IdeaCount: {0}", user.Ideas != null ? user.Ideas.Count() : 0);
                //Console.Out.WriteLine("BookmarkCount: {0}", user.Bookmarks != null ? user.Bookmarks.Count() : 0);
                //Console.Out.WriteLine("VisitCount: {0}", user.Visits.Count());
            }

           Repo.Dispose();
        }
    }
}
