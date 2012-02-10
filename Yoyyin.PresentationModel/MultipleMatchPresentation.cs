using System;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;

namespace Yoyyin.PresentationModel
{
    public class MultipleMatchPresentation : IPresentation
    {
        public IUser User { get; set; }
        public string Percentage { get; set; }
        public Guid UserId
        {
            get { return User.UserId; }
        }
        public string Name
        {
            get { return User.GetDisplayName(); }
        }
        public string City
        {
            get { return User.City; }
        }
    }
}