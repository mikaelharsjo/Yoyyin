using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Domain.Matching;

namespace Yoyyin.PresentationModel
{
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