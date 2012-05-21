using System.Collections.Generic;

namespace Yoyyin.Data.Core.Entities
{
    public interface ISniItem
    {
        string Title { get; set; }
        string SniNo { get; set; }
        ICollection<User> User { get; set; }
    }
}