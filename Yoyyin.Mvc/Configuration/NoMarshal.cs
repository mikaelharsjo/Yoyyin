using Kiwi.Prevalence.Marshalling;

namespace Yoyyin.Mvc.Configuration
{
    /* No marshalling, faster queries for the brave */
    public class NoMarshal : IMarshal
    {
        public T MarshalQueryResult<T>(T result)
        {
            return result;
        }

        public T MarshalCommandResult<T>(T result)
        {
            return result;
        }
    }
}