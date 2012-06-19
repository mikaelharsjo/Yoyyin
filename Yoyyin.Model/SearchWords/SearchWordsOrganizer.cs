using System.Collections.Generic;
using System.Linq;

namespace Yoyyin.Model.SearchWords
{
    public class SearchWordsOrganizer
    {
        //private readonly ISearchWordsProvider _searchWordsProvider;
        private readonly Dictionary<string, int> _searchWordsWithCount;
        
        //public SearchWordsOrganizer(ISearchWordsProvider searchWordsProvider)
        //{
        //    _searchWordsProvider = searchWordsProvider;
        //    _searchWordsWithCount = new Dictionary<string, int>();

        //    OrganizeSearchWords();
        //}

        private void OrganizeSearchWords()
        {
            //foreach(string input in _searchWordsProvider.GetWords())
            //{
            //    foreach(string item in input.Split(','))
            //    {
            //        string trimmed = item.Trim().ToLower();
            //        if (_searchWordsWithCount.ContainsKey(trimmed))
            //            _searchWordsWithCount[trimmed]++;
            //        else
            //            _searchWordsWithCount.Add(trimmed, 1);
            //    }
            //}
        }

        /// <summary>
        /// Should return searchwords without duplicates, sorted by weight. Used by auto complete for competences
        /// </summary>
        public IEnumerable<string> GetAllSearchWords()
        {
            var myList = new List<KeyValuePair<string, int>>(_searchWordsWithCount);
            
            // sort by key=weight, descending
            myList.Sort((firstPair, nextPair) => firstPair.Value.CompareTo(nextPair.Value));
            
            return myList.Select(x => x.Key)
                .Reverse();
        }
    }
}
