using System.Collections.Generic;

namespace Yoyyin.Data.Core.Entities
{
    public interface ISniHead
    {
        string Title { get; set; }
        ICollection<SniItem> SniItem { get; set; }
        string SniHeadID { get; set; }
        ICollection<User> User { get; set; }
    }
}