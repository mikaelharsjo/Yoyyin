using System;
using System.Collections.Generic;
using System.Data.Objects;
using Yoyyin.Data;

namespace Yoyyin.Domain.SearchWords
{
    public class CompetencesSearchWordsProvider : ISearchWordsProvider
    {
        private readonly CachedItemProvider<IList<string>> _cachedItemProvider;
        private const string CacheKey = "CompetencesSearchWordsProviderCacheKey";
        private readonly IWordsRepository _repository;
        private readonly IWordsProvider _wordsProvider;

        public CompetencesSearchWordsProvider(CachedItemProvider<IList<string>> cachedWords, IWordsProvider wordsProvider)
        {
            _cachedItemProvider = cachedWords;
            _wordsProvider = wordsProvider;
        }

        public IList<string> GetWords()
        {
            return _cachedItemProvider.GetItem(CacheKey, new Func<IEnumerable<string>>(GetWordsFromDb));
        }

        private IEnumerable<string> GetWordsFromDb()
        {
            return _wordsProvider.Find();
        }
    }
}