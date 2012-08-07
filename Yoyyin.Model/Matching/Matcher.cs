using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Model.Users.Entities;
using Yoyyin.Model.Users.Enumerations;
using Yoyyin.Model.Users.ValueObjects;

namespace Yoyyin.Model.Matching
{
    public class Matcher
    {
        private IUser _firstUser;
        private IUser _secondUser;

        public Matcher(User firstUser, User secondUser)
        {
            _firstUser = firstUser;
            _secondUser = secondUser;
        }

        public IMatchResult MatchLookingFor()
        {
            return _firstUser.LookingFor.MatchWith(_secondUser.LookingFor) ? new LookingForMatch() : new DoesNotMatch() as IMatchResult;
        }

        public IMatchResult MatchUserType()
        {
            return _secondUser
                       .Ideas
                       .ToList()
                       .Select(idea => idea.SearchProfile.UserTypesNeeded.UserTypeIds.Contains(_firstUser.UserType))
                       .Contains(true)
                       ? new UserTypeMatch()
                       : new DoesNotMatch() as IMatchResult;
        }
    }

    public class UserTypeMatch : IMatchResult
    {
        public bool IsMatch
        {
            get { return true; }
            set { ; }
        }
    }

    public class LookingForMatch : IMatchResult
    {
        public bool IsMatch
        {
            get { return true; }
            set { ; }
        }
    }
}