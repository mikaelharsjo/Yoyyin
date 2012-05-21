using System.Collections.Generic;
using Yoyyin.Domain.SearchWords;

namespace Yoyyin.Tests.Fakes
{
    public class FakeWordsProvider : IWordsProvider
    {
        public IEnumerable<string> Find()
        {
            throw new System.NotImplementedException();
        }
    }
}