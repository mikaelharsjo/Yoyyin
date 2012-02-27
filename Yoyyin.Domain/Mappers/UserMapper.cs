using System.Linq;
using Yoyyin.Domain.Enumerations;
using Yoyyin.Domain.Sni;
using Yoyyin.Domain.Users;

namespace Yoyyin.Domain.Mappers
{
    public class UserMapper : IUserMapper
    {
        private readonly ISniHeadMapper _sniHeadMapper;
        private readonly ISniItemMapper _sniItemMapper;

        public UserMapper(ISniHeadMapper sniHeadMapper, ISniItemMapper sniItemMapper)
        {
            _sniHeadMapper = sniHeadMapper;
            _sniItemMapper = sniItemMapper;
        }

        public IUser MapUser(Data.User user)
        {
            if (user == null) return new NullUser();

            return new User
                       {
                           BusinessDescription = user.BusinessDescription,
                           UserName = user.aspnet_Users.UserName,
                           Latitude = user.Latitude,
                           Longitude = user.Longitude,
                           BusinessTitle = user.BusinessTitle,
                           City = user.City,
                           Street = user.Street,
                           SniNo = user.SniNo,
                           Alias = user.Alias,
                           Active = user.Active != null && (bool) user.Active,
                           Name = user.Name,
                           CVFileName = user.CVFileName,
                           Image = user.Image,
                           UserId = user.UserId,
                           SniHead =
                               user.SniHead != null ? _sniHeadMapper.MapSniHead(user.SniHead) : new NoSniHeadSelected(),
                           SniItem =
                               user.SniItem != null ? _sniItemMapper.MapSniItem(user.SniItem) : new NoSniItemSelected(),
                           Url = user.Url,
                           //used in matching
                           SniHeadID = user.SniHeadID,
                           SearchWords = user.SearchWords,
                           SearchWordsCompetence = user.SearchWordsCompetence,
                           SearchWordsCompetenceNeeded = user.SearchWordsCompetenceNeeded,
                           UserType = user.UserType == null ? (int)UserTypes.Entrepreneur : (int) user.UserType,
                           UserTypeDescription = user.UserTypeDescription,
                           UserTypesNeeded = user.UserTypesNeeded
                       };
        }

        public SniHeadWithUser MapSniHeadWithUser(Data.SniHead sniHeadData)
        {
            return new SniHeadWithUser { SniHead = _sniHeadMapper.MapSniHead(sniHeadData), User = MapUser(sniHeadData.User.First()) };
        }
    }
}