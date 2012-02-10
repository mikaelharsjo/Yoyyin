using System.Collections.Generic;
using Yoyyin.Domain.SearchWords;

namespace Yoyyin.Tests
{
    public class FakeWordsProvider : IWordsProvider
    {
        public IEnumerable<string> Find()
        {
            throw new System.NotImplementedException();
        }
    }
}