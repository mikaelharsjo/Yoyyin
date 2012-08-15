using System.Linq;
using Yoyyin.Model.Matching.MatchResults;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.AggregateRoots;

namespace Yoyyin.Model.Matching
{
    public class Matcher
    {
        private IUser _firstUser;
        private IUser _secondUser;
        private IUserRepository _repository;

        public Matcher(IUser firstUser, IUser secondUser)
        {
            _firstUser = firstUser;
            _secondUser = secondUser;
        }

        public Matcher(IUser firstUser, IUser secondUser, IUserRepository repository)
        {
            _firstUser = firstUser;
            _secondUser = secondUser;
            _repository = repository;
        }

        public IMatchResult MatchLookingFor()
        {
            return _firstUser.LookingFor.MatchWith(_secondUser.LookingFor) ? new LookingForMatch() : new DoesNotMatch() as IMatchResult;
        }

        public UserTypeMatch MatchUserType()
        {
            var secondUserTypesFlattened = _secondUser
                .Ideas
                .SelectMany(idea => idea.SearchProfile.UserTypesNeeded.UserTypeIds);
                       
            return secondUserTypesFlattened.Any(secondUserType => secondUserType == _firstUser.UserType)
                       ? new UserTypeMatch(true, _firstUser.UserType, secondUserTypesFlattened, _repository)
                       : new UserTypeMatch(false, _firstUser.UserType, secondUserTypesFlattened, _repository);
        }

        public IMatchResult MatchUserTypesNeeded()
        {
            var userTypesFlattened = _firstUser
                .Ideas
                .SelectMany(idea => idea.SearchProfile.UserTypesNeeded.UserTypeIds);

            return userTypesFlattened.Any(neededUserType => _secondUser.UserType == neededUserType)
                       ? new UserTypeNeededMatch(userTypesFlattened, _secondUser.UserType)
                       : new DoesNotMatch() as IMatchResult;
        }

        public IMatchResult MatchCompetencesNeeded()
        {
            var neededCompetencesFlattened = _firstUser
                                                .Ideas
                                                .SelectMany(idea => idea.SearchProfile.CompetencesNeeded);

            return neededCompetencesFlattened.Any(competence => _secondUser.Competences.Contains(competence))
                       ? new CompetencesMatch(true, neededCompetencesFlattened, _secondUser.Competences)
                       : new DoesNotMatch() as IMatchResult;
        }

        public CompetencesMatch MatchCompetences()
        {
            var neededCompetencesFlattened = _secondUser
                                                .Ideas
                                                .SelectMany(idea => idea.SearchProfile.CompetencesNeeded);

            return neededCompetencesFlattened.Any(competence => _firstUser.Competences.Contains(competence))
                       ? new CompetencesMatch(true, neededCompetencesFlattened, _firstUser.Competences)
                       : new CompetencesMatch(false, neededCompetencesFlattened, _firstUser.Competences);
        }

        public MatchResult Match()
        {
            return new MatchResult {CompetencesResult = MatchCompetences(), UserTypeMatch = MatchUserType()};
        }
    }
}