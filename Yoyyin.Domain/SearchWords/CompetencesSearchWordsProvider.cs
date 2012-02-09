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
        private readonly IEntityWordsRepository _repository;
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

    public interface IWordsProvider
    {
        IEnumerable<string> Find();
    }

    public class WordsProvider : IWordsProvider
    {
        private readonly IEntityWordsRepository _repository;

        // do not use, inject repository instead
        public WordsProvider()
        {
            _repository = new EntitySearchWordsRepository(new YoyyinEntities1());
        }

        public WordsProvider(IEntityWordsRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<string> Find()
        {
            return (IEnumerable<string>)_repository.Find();
        }
    }
}