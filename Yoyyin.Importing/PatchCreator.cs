using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kiwi.Prevalence;
using NUnit.Framework;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Model.Users.Commands;

namespace Yoyyin.Importing
{

    [TestFixture]
    public class PatchCreatorFixture
    {
        private UserRepository _userRepository;
        private UserImporter _userImporter;
        private SniImporter _sniImporter;
        //public DevelopmentUserRepository DevelopmentUserRepository;

        [SetUp]
        public void Setup()
        {
            var modelFactory = new ModelFactory<UserModel>(() => new UserModel()); // {OnRestore = model => model.Invalidate()};
            _userRepository = new UserRepository(new RepositoryConfiguration(), modelFactory) { Path = @"c:\temp\yoyyin\users" };
            _userRepository.Purge();

            _userImporter = new UserImporter();
            _sniImporter = new SniImporter();
            //DevelopmentUserRepository = new DevelopmentUserRepository(new UserImporter(), new SniImporter(), UserRepository);
            //QandARepository = new Repository<QandAModel>(new RepositoryConfiguration(), qandAFactory) { Path = @"c:\Temp\yoyyin\Q&A" };

            Console.Out.WriteLine("Revision is now {0}", _userRepository.Revision);
        }

        [Test]
        public void CreatePatch()
        {
            var users = _userImporter.Import();
            foreach (var user in users)
            {
                _userRepository.Execute(new AddUserCommand(user));
            }

            var sniHeads = _sniImporter.Import();
            foreach (var sniHead in sniHeads)
            {
                _userRepository.Execute(new AddSniHeadCommand(sniHead));
            }

            AddInitialUserTypes();

            //Console.Out.WriteLine("UserTypes count :{0}", Us);
        }

        private void AddInitialUserTypes()
        {
            _userRepository.Execute(
                new AddUserTypeCommand(new UserType
                                           {
                                               UserTypeId = 0,
                                               Title = "Entreprenör",
                                               Description = "Affärsutvecklare, person som kan starta upp och driva företag."
                                           }));
            _userRepository.Execute(
                new AddUserTypeCommand(new UserType
                                           {
                                               UserTypeId = 1,
                                               Title = "Uppfinnare",
                                               Description = "Innovatör, person med idéer."
                                           }));
            _userRepository.Execute(
                new AddUserTypeCommand(new UserType
                                           {
                                               UserTypeId = 2,
                                               Title = "Finansiär",
                                               Description = "Söker idéer och företag att investera i."
                                           }));
            _userRepository.Execute(
                new AddUserTypeCommand(new UserType
                                           {
                                               UserTypeId = 3,
                                               Title = "Utvecklare",
                                               //Title = "Finansiär/Drake/Ängel",
                                               Description = "Person som kan utveckla mjukvara."
                                           }));
            _userRepository.Execute(
                new AddUserTypeCommand(new UserType
                                           {
                                               UserTypeId = 4,
                                               Title = "Snart pensionär",
                                               Description =
                                                   "Person som vill avveckla/sälja sitt företag."
                                           }));
            _userRepository.Execute(
                new AddUserTypeCommand(new UserType
                                           {
                                               UserTypeId = 5,
                                               Title = "Marknadsförare",
                                               Description =
                                                   "Person som kan sälja/marknadsföra."
                                           }));
        }
    }
}
