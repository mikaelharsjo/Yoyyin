using System.Collections.Generic;

namespace Yoyyin.Model.Users.ValueObjects
{
    public class SniHead
    {
        public string SniHeadId { get; set; }
        public string Title { get; set; }

        public IEnumerable<SniItem> Items { get; set; }
    }
}