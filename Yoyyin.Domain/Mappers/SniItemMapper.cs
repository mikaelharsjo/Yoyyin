using Yoyyin.Domain.Sni;

namespace Yoyyin.Domain.Mappers
{
    public class SniItemMapper : ISniItemMapper
    {
        public ISniItem MapSniItem(Data.SniItem sniItem)
        {
            return new SniItem { Title = sniItem.Title };
        }
    }
}