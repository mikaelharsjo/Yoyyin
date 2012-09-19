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
            Tags = new Dictionary<string, int>();
        }

        public Dictionary<string, int> Tags
        {
            get { return _tags; }
            set { _tags = value; }
        }

        public void Add(IEnumerable<IEnumerable<string>> words)
        {
            foreach (var array in words)
            {
                foreach (string word in array)
                {
                    if (Tags.ContainsKey(word))
                    {
                        Tags[word]++;
                    }
                    else
                    {
                        Tags.Add(word, 1);
                    }
                }
            }
        }

        public void Print()
        {
            foreach(var kvp in Tags)
            {
                Console.WriteLine(string.Format("{0} {1}", kvp.Key, kvp.Value));
            }
        }

        public IEnumerable<string> SortedStrings()
        {
            return Tags
                .OrderByDescending(t => t.Value)
                .Select(t => t.Key);
        }
    }
}