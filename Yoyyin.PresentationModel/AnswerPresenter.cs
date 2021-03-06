using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.QA;
using Yoyyin.Domain.Users;

namespace Yoyyin.PresentationModel
{
    public class AnswerPresenter : IAnswerPresenter
    {
        private readonly ICurrentUser _currentUser;

        public AnswerPresenter(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        public AnswerPresentation Presentate(Answer answer)
        {
            return new AnswerPresentation
                        {
                            DisplayName = answer.User.GetDisplayName(),
                            Text = answer.Text,
                            UserId = answer.UserId,
                            Date = answer.Created.ToFormattedString(),
                            AnswerId = answer.AnswerID,
                            //DeleteAllowed = answer.DeleteAllowed(_currentUser.UserId)
                        };
        }

        public IEnumerable<AnswerPresentation> Presentate(IEnumerable<Answer> shouldBeConverted)
        {
            return shouldBeConverted.Select(Presentate);
        }
    }
}