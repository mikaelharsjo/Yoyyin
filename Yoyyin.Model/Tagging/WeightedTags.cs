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

        //public IDictionary<string, int> Tags;
        public string ToMarkup()
        {
            return string.Join(" ", _tags.Select(t => string.Format("<div class='weightedTag'><span class='label label-info'>{0}</span> x{1}</div>", t.Key, t.Value)));
        }
    }
}