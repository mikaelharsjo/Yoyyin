using System.Linq;
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
                           Latitude = user.Latitude,
                           Longitude = user.Longitude,
                           BusinessTitle = user.BusinessTitle,
                           City = user.City,
                           Street = user.Street,
                           SniNo = user.SniNo,
                           Alias = user.Alias,
                           Active = user.Active != null && (bool)user.Active,
                           Name = user.Name,
                           CVFileName = user.CVFileName,
                           Image = user.Image,
                           UserId = user.UserId,
                           SniHead = _sniHeadMapper.MapSniHead(user.SniHead),
                           SniItem = _sniItemMapper.MapSniItem(user.SniItem)

                       }; // not done
        }

        public SniHeadWithUser MapSniHeadWithUser(Data.SniHead sniHeadData)
        {
            return new SniHeadWithUser { SniHead = _sniHeadMapper.MapSniHead(sniHeadData), User = MapUser(sniHeadData.User.First()) };
        }
    }
}