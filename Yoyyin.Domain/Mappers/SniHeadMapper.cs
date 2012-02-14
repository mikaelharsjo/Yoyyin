using Yoyyin.Domain.Sni;

namespace Yoyyin.Domain.Mappers
{
    public class SniHeadMapper : ISniHeadMapper
    {
        public ISniHead MapSniHead(Data.SniHead sniHeadData)
        {
            return new SniHead { Title = sniHeadData.Title };
        }
    }
}