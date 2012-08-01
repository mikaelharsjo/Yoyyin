using System.Collections.Generic;
using System.Linq;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.Entities;

namespace Yoyyin.Mvc.Services
{
    public class UserTypeService
    {
        private readonly IUserRepository _userRepository;

        public UserTypeService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<string> GetUserTypesAsStrings(UserTypesNeeded userTypesNeeded)
        {
            return
                _userRepository.Query(
                    m =>
                    m.UserTypes.Where(
                        ut => userTypesNeeded.UserTypeIds.Contains(ut.UserTypeId)))
                    .Select(ut => ut.Title);
        }
    }
}