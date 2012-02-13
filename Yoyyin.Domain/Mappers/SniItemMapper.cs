namespace Yoyyin.Domain.Mappers
{
    public class SniItemMapper : ISniItemMapper
    {
        public SniItem MapSniItem(Data.SniItem sniItem)
        {
            return new SniItem { Title = sniItem.Title };
        }
    }
}