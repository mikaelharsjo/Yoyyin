using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Data.EntityFramework;

namespace Yoyyin.Domain.SearchWords
{
    public class WordsProvider : IWordsProvider
    {
        private readonly IWordsRepository _repository;

        public WordsProvider(IWordsRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<string> Find()
        {
            return (IEnumerable<string>)_repository.Find();
        }
    }
}