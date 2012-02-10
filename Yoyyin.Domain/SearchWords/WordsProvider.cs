using System.Collections.Generic;
using Yoyyin.Data;

namespace Yoyyin.Domain.SearchWords
{
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