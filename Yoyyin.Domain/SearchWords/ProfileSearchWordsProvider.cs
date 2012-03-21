using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using Yoyyin.Data;

namespace Yoyyin.Domain.SearchWords
{
    /// <summary>
    /// Provides search words from the database
    /// </summary>
    public class ProfileSearchWordsProvider : ISearchWordsProvider
    {
        private readonly CachedItemProvider<IList<string>> _cachedItemProvider;
        private const string CacheKey = "ProfileSearchWordsProviderCacheKey";
        private readonly IWordsRepository _repository;

        public ProfileSearchWordsProvider(CachedItemProvider<IList<string>> cachedWords)
        {
            _cachedItemProvider = cachedWords;
        }

        public ProfileSearchWordsProvider(CachedItemProvider<IList<string>> cachedWords, IWordsRepository repository)
        {
            _cachedItemProvider = cachedWords;
            _repository = repository;
        }

        public IList<string> GetWordsFromDb()
        {
            return (IList<string>) _repository.Find();
        }

        public IList<string> GetWords()
        {
            return _cachedItemProvider.GetItem(CacheKey, new Func<IList<string>>(GetWordsFromDb));
        }
    }
}
