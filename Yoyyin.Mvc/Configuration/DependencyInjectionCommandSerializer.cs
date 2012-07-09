using Autofac;
using Autofac.Integration.Mvc;
using Kiwi.Prevalence;

namespace Yoyyin.Mvc.Configuration
{
    /// <summary>
    /// Use if you need to inject dependencies into the commands
    /// </summary>
    public class DependecyInjectingCommandSerializer : ICommandSerializer
    {
        private readonly ICommandSerializer _inner;

        public DependecyInjectingCommandSerializer(ICommandSerializer inner)
        {
            _inner = inner;
        }

        #region ICommandSerializer Members

        public JournalCommand Serialize(ICommand command)
        {
            return _inner.Serialize(command);
        }

        public ICommand Deserialize(JournalCommand command1)
        {
            var command = _inner.Deserialize(command1);

            AutofacDependencyResolver.Current.RequestLifetimeScope.InjectProperties(command);
            return command;
        }

        #endregion
    }
}