using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;

namespace Yoyyin.PresentationModel
{
    public interface IAnswerPresenter
    {
        AnswerPresentation Presentate(Answer answer);
        IEnumerable<AnswerPresentation> Presentate(IEnumerable<Answer> shouldBeConverted);
    }

    public class AnswerPresenter : IAnswerPresenter
    {
        private ICurrentUser _currentUser;

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
                            DeleteAllowed = answer.DeleteAllowed(_currentUser.UserId)
                        };
        }

        public IEnumerable<AnswerPresentation> Presentate(IEnumerable<Answer> shouldBeConverted)
        {
            return shouldBeConverted.Select(Presentate);
        }
    }
}