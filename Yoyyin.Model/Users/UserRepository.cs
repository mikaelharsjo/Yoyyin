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

    public class DevelopmentUserRepository : UserRepository
    {
        private IUserImporter _userImporter;
        public DevelopmentUserRepository(IRepositoryConfiguration configuration, IModelFactory<UserModel> modelFactory, IUserImporter userImporter) : base(configuration, modelFactory)
        {
            _userImporter = userImporter;
            InitializeWithDataFromSql();
        }

        private void InitializeWithDataFromSql()
        {
            Purge();
            var users = _userImporter.Import();
            foreach (var user in users)
            {
                Execute(new AddUserCommand(user));
            }
        }
    }
}
