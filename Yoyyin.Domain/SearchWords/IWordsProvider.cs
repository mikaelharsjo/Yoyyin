using System.Collections.Generic;

namespace Yoyyin.Domain.SearchWords
{
    public interface IWordsProvider
    {
        IEnumerable<string> Find();
    }
}