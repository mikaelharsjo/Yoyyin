using Yoyyin.Data;

namespace Yoyyin.Domain.Mappers
{
    public interface IMessageMapper
    {
        Message MapMessage(UserMessages messageData);
    }
}