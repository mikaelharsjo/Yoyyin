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
using Yoyyin.Model.Users.Enumerations;

namespace Yoyyin.Model.Tests
{
    [TestFixture]
    public class SetupFixture
    {
        public UserRepository UserRepository;
        public Repository<QandAModel> QandARepository;
        public DevelopmentUserRepository DevelopmentUserRepository;
        private User _firstUser;

        [SetUp]
        public void Setup()
        {
            var modelFactory = new ModelFactory<UserModel>(() => new UserModel()); // {OnRestore = model => model.Invalidate()};
            var qandAFactory = new ModelFactory<QandAModel>(() => new QandAModel());
            UserRepository = new UserRepository(new RepositoryConfiguration(), modelFactory) 
                                {Path = @"c:\temp\yoyyin\users"};
            
            UserRepository.Purge();
            
            DevelopmentUserRepository = new DevelopmentUserRepository(new UserImporter(), new SniImporter(), UserRepository);
                     
            QandARepository = new Repository<QandAModel>(new RepositoryConfiguration(), qandAFactory)
                                  {Path = @"c:\Temp\yoyyin\Q&A"};
            //UserRepository.SaveSnapshot();
                    

            //UserRepository.InitializeWithDataFromSql();
            

            //Add5QuestionsAndAnswersPerUser(users);

            Console.Out.WriteLine("Revision is now {0}", UserRepository.Revision);
            //Console.Out.WriteLine("Model size is {0}", _repo.Query(m => m.Users.Count));
        }

        [Test]
        public void CreatePatch()
        {

            UserRepository.Execute(
                new AddUserTypeCommand(new UserType
                                           {
                                               UserTypeId = 0,
                                               Title = "Företagare/Entreprenör",
                                               Description = "Personer som kan starta upp och driva företag."
                                           }));
            UserRepository.Execute(
                new AddUserTypeCommand(new UserType
                                           {
                                               UserTypeId = 1,
                                               Title = "Innovatör/Uppfinnare",
                                               Description = "Personer med idéer som de vill förverkliga."
                                           }));
            UserRepository.Execute(
                new AddUserTypeCommand(new UserType
                                           {
                                               UserTypeId = 2,
                                               Title = "Finansiär",
                                               Description = "Spännande idéer och företag att investera i."
                                           }));
            UserRepository.Execute(
                new AddUserTypeCommand(new UserType
                                           {
                                               UserTypeId = 3,
                                               Title = "Finansiär/Drake/Ängel",
                                               Description =
                                                   "Personer med kunskap och kapital att investera i min idé eller företag."
                                           }));
            UserRepository.Execute(
                new AddUserTypeCommand(new UserType
                                           {
                                               UserTypeId = 4,
                                               Title = "Företagere/Pensionär",
                                               Description =
                                                   "Personer med kunskap och kapital att investera i min idé eller företag."
                                           }));
            UserRepository.Execute(
                new AddUserTypeCommand(new UserType
                                           {
                                               UserTypeId = 5,
                                               Title = "Innovatör/Uppfinnare",
                                               Description = "Kompetenser och delägare till min verksamhet."
                                           }));
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
                    QandARepository.Execute(new AddQuestionCommand(question));
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
                UserRepository.Execute(new AddUserCommand(user));
            }
            return users;
        }

        [TearDown]
        public void TearDown()
        {
            foreach (User user in UserRepository.Query(model => model.Users))
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

           UserRepository.Dispose();
        }
    }
}
