namespace Yoyyin.Domain.Mappers
{
    public class SniHeadMapper : ISniHeadMapper
    {
        public SniHead MapSniHead(Data.SniHead sniHeadData)
        {
            return new SniHead { Title = sniHeadData.Title };
        }
    }
}