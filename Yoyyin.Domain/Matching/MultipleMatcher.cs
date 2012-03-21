using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Domain.Services;
using Yoyyin.Domain.Users;

namespace Yoyyin.Domain.Matching
{
    public class MultipleMatcher : IMultipleMatcher
    {
        //private readonly CachedItemProvider<IEnumerable<IUser>> _cachedUsersProvider;
        private readonly IUser _user;
        //private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        private readonly IEnumerable<IUser> _users;
        private IEnumerable<Matcher> _matchers;
        private IEnumerable<Matcher> _succesfullMatchers;

        private const string CacheKey = "AllUsersKey";

        public MultipleMatcher(IUser user, IUserRepository userRepository)
        {
            _user = user;
            _userRepository = userRepository;

            _users = _userRepository.FindAll();
        }

        public MultipleMatcher(IUser user, IEnumerable<IUser> users, IUserRepository userRepository)
        {
            _user = user;
            _users = users;
            _userRepository = userRepository;
        }

        public IEnumerable<Matcher> MatchAll()
        {
            _matchers = _users.Select(userToCompare => new Matcher(_user, userToCompare));
            return _matchers;
        }

        /// <summary>
        /// Returns matchers with at least one match, sorted by number of matches
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Matcher> GetSuccesFullMatches()
        {
            _matchers = _matchers ?? MatchAll();
            _succesfullMatchers = _matchers.Select(match => match)
                .OrderByDescending(match => match.GetMatchCount())
                .Where(match => match.HasMatch());
                    

            return _succesfullMatchers;
        }

        public MultipleMatcherStats GetStats()
        {
            _matchers = _matchers ?? MatchAll();
            _succesfullMatchers = _succesfullMatchers ?? GetSuccesFullMatches();
            return new MultipleMatcherStats(_succesfullMatchers.Count(), _matchers.Count());
        }
    }
}
