using System;
using Kiwi.Prevalence;
using Yoyyin.Model.Users.AggregateRoots;

namespace Yoyyin.Model.Users.Commands.Questions
{
    public class AddQuestionCommand : AbstractCommand<QandAModel, bool>
    {
        public AddQuestionCommand() { }

        public AddQuestionCommand(Question question)
        {
            Question = question;
        }

        public Question Question { get; set; }

        public override Func<bool> Prepare(QandAModel model)
        {
            //userModel.Questions.Add(Question);
            // ask joakim why TResult is mandatory
            return () => true;
        }
    }
}
