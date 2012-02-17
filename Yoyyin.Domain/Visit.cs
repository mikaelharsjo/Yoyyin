using System;
using Yoyyin.Domain.Users;

namespace Yoyyin.Domain
{
    public class Visit
    {
        public IUser VisitingUser { get; set; }
        public DateTime VisitDate { get; set; }
    }
}