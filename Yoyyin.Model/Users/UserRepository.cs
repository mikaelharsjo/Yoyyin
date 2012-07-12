using Kiwi.Prevalence;
using Yoyyin.Model.Importers;
using Yoyyin.Model.Users.Commands;

namespace Yoyyin.Model.Users
{
    public class UserRepository :  Repository<UserModel>, IUserRepository
    {
        public UserRepository(IRepositoryConfiguration configuration, IModelFactory<UserModel> modelFactory) : base(configuration, modelFactory)
        {
        }
    }

    public class DevelopmentUserRepository
    {
        private UserRepository _userRepository;
        private IUserImporter _userImporter;
        private ISniImporter _sniImporter;
        public DevelopmentUserRepository(IUserImporter userImporter, ISniImporter sniImporter, UserRepository userRepository)
        {
            _userImporter = userImporter;
            _sniImporter = sniImporter;
            _userRepository = userRepository;
            InitializeWithDataFromSql();
        }

        private void InitializeWithDataFromSql()
        {
            //Purge();
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
        }
    }
}
