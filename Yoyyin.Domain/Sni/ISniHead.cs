namespace Yoyyin.Domain.Sni
{
    public interface ISniHead
    {
        string Title { get; set; }
        SniItem SniItem { get; set; }
        int SniHeadID { get; set; }
        object User { get; set; }
    }
}