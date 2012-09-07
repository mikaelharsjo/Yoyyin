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

            AddUserTypes();

            AddAvatars();

            //Console.Out.WriteLine("UserTypes count :{0}", Us);
        }

        private void AddAvatars()
        {
            AddAvatar(new Guid("bb887d91-c8ec-4434-9f6f-11309741ee82"), "glyphicons_034_old_man.png");
            //bb887d91-c8ec-4434-9f6f-11309741ee82 old_man
            //fb7ff02f-0962-42dc-800b-f00624f47d63 old man

            //f7370b2e-ef22-4d86-b4b8-521b66edee2a girl

            //36c1a00d-dd85-4121-9aac-17a891d25086 woman
            //b17a04dd-2a8c-472f-86da-638701547027 woman
            //59e6a416-a0a5-47f3-bafb-ae80e1559528 woman
            //61eae6b0-6c78-4b19-b8d9-f63db120c398 woman
        }

        private void AddAvatar(Guid userId, string avatar)
        {
            var user = _userRepository.Query(m => m.Users.First(u => u.UserId == userId));
            user.Image.Avatar = avatar;
            _userRepository.Execute(new UpdateUserCommand
                                        {
                                            User = user
                                        });
        }

        private void AddUserTypes()
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
