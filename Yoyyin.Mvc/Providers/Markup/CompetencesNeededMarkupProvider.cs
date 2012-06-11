using System.Collections.Generic;
using System.Linq;

namespace Yoyyin.Mvc.Providers.Markup
{
    public class CompetencesNeededMarkupProvider
    {
        private readonly LabelListGenerator _labelListGenerator;

        public CompetencesNeededMarkupProvider()
        {
            _labelListGenerator = new LabelListGenerator();
        }

        public string ToList(IEnumerable<string> strings)
        {
            return string.Format("<ul>{0}</ul>", string.Join("", strings.Select(s => string.Format("<li>{0}</li>", (object) s.ToString())).ToArray()));
        }

        public string ToLabelList(IEnumerable<string> strings)
        {
            return _labelListGenerator.GenerateMarkup(strings,
                                                      "<span class='label label-info'><a href='/User/ListByCompetence/{0}'>{0}</a></span>");
        }
    }
}