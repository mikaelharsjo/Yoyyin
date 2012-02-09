using System.Collections.Generic;

namespace Yoyyin.Domain.SearchWords
{
    public interface ISearchWordsProvider
    {   
        IList<string> GetWords();
    }
}