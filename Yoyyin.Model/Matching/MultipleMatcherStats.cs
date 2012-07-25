using System;

namespace Yoyyin.Model.Matching
{
    public class MultipleMatcherStats
    {
        public int Matched { get; set; }
        public int Tried { get; set; }

        public MultipleMatcherStats(int matched, int tried)
        {
            Matched = matched;
            Tried = tried;
        }

        public override string ToString()
        {
            return string.Format("Du matchar {0} av totalt {1} medlemmar.", Matched, Tried);
        }

        public int GetStatsAsPercentage()
        {
            return Convert.ToInt32((float)Matched / (float)Tried * 100);
        }
    }
}