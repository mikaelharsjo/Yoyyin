using System;
using System.Collections.Generic;
using System.Linq;

namespace Yoyyin.Model.Tagging
{
    public class WeightedTags
    {
        private Dictionary<string, int> _tags;

        public WeightedTags()
        {
            _tags = new Dictionary<string, int>();
        }

        public void Add(IEnumerable<IEnumerable<string>> words)
        {
            foreach (var array in words)
            {
                foreach (string word in array)
                {
                    if (_tags.ContainsKey(word))
                    {
                        _tags[word]++;
                    }
                    else
                    {
                        _tags.Add(word, 1);
                    }
                }
            }
        }

        public void Print()
        {
            foreach(var kvp in _tags)
            {
                Console.WriteLine(string.Format("{0} {1}", kvp.Key, kvp.Value));
            }
        }

        public IEnumerable<string> SortedStrings()
        {
            return _tags
                .OrderByDescending(t => t.Value)
                .Select(t => t.Key);
        }

        // returns markup sorted by weight
        public string ToMarkup()
        {
            const string format = "<div class='weightedTag'><a href='/User/ListByCompetence/{0}'><span class='label label-info'>{0}</span></a> x{1}</div>";
            return string.Join(" ", _tags
                                        .OrderByDescending(t => t.Value)
                                        .Select(t => string.Format(format, t.Key, t.Value)));
        }
    }
}