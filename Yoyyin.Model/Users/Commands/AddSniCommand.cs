using System;
using Kiwi.Prevalence;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Model.Users.ValueObjects;

namespace Yoyyin.Model.Users.Commands
{
    public class AddSniHeadCommand : AbstractCommand<UserModel, bool>
    {
        public AddSniHeadCommand()
        {
        }

        public SniHead SniHead { get; set; }

        public AddSniHeadCommand(SniHead sni)
        {
            SniHead = sni;
        }

        public override Func<bool> Prepare(UserModel model)
        {
            model.SniHeads.Add(SniHead);
            return () => true;
        }
    }
}