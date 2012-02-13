using Yoyyin.Domain.Users;

namespace Yoyyin.Domain.Mappers
{
    public interface IUserMapper
    {
        IUser MapUser(Data.User user);
        SniHeadWithUser MapSniHeadWithUser(Data.SniHead sniHeadData);
    }
}