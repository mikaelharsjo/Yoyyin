using System.Collections.Generic;

namespace Yoyyin.Mvc.Models
{
    public class User
    {
        public string DisplayName { get; set; }
        public string SmallProfileImageSrc { get; set; }
        public string City { get; set; }
        public string UserType { get; set; }
        public IEnumerable<string> Competences { get; set; }
    }
}