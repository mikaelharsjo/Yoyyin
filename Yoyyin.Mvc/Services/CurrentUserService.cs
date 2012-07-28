using System.Linq;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.AggregateRoots;

namespace Yoyyin.Mvc.Services
{
    public class CurrentUserService
    {
        private IUserRepository _repository;

        public CurrentUserService(IUserRepository repository)
        {
            _repository = repository;
        }

        // TODO: look up by username, ie email
        public IUser Get()
        {
            //System.Web.HttpContext.Current.User.Identity.IsAuthenticated
            return _repository.Query(m => m.Users.First()); // u => u.Email == ))
        }
    }
}
