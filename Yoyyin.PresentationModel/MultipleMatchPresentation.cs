using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.Matching;

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

    public class MultipleMatchPresenter : IPresenter<Matcher>
    {
        public IPresentation Presentate(Matcher matcher)
        {
            return new MultipleMatchPresentation()
                       {
                           User = matcher.GetMatchingUser(),
                           Percentage = matcher.GetMatchCountAsPercentage().ToString() + "%"
                       };
        }

        public IEnumerable<IPresentation> Presentate(IEnumerable<Matcher> shouldBeConverted)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPresentation> Convert(IEnumerable<Matcher> shouldBeConverted, Guid currentUserId)
        {
            // don´t return yourself
            return shouldBeConverted
                .Where(x => x.GetMatchingUser().UserId != currentUserId) 
                .Select(Presentate);
        }
    }
}