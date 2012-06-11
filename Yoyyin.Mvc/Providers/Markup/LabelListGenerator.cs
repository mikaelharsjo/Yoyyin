using System.Collections.Generic;
using System.Linq;

namespace Yoyyin.Mvc.Providers.Markup
{
    public class LabelListGenerator
    {
        public string GenerateMarkup(IEnumerable<string> strings, string formatString)
        {
            return string.Join(" ", strings.Select(s => string.Format(formatString, (object) s.ToString())).ToArray());            
        }
    }
}