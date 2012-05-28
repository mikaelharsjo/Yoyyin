using System;
using Kiwi.Prevalence;
using Yoyyin.Model.Users.AggregateRoots;

namespace Yoyyin.Model.Users.Commands
{
    public class AddSniCommand : AbstractCommand<UserModel, bool>
    {
        public AddSniCommand()
        {
        }

        public Sni Sni { get; set; }

        public AddSniCommand(Sni sni)
        {
            Sni = sni;
        }

        public override Func<bool> Prepare(UserModel model)
        {
            model.Snis.Add(Sni);
            return () => true;
        }
    }
}