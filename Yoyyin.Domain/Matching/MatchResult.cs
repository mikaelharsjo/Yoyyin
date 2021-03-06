namespace Yoyyin.Domain.Matching
{
    public class MatchResult
    {
        private bool _isMatch;
        private string _firstValue;
        private string _secondValue;
        private string _matchingValue;
        public MatchResult(bool isMatch, string firstValue, string secondValue, string matchingValue)
        {
            _isMatch = isMatch;
            _firstValue = firstValue;
            _secondValue = secondValue;
            _matchingValue = matchingValue;
        }

        public string SecondValue
        {
            get { return _secondValue; }
        }

        public string FirstValue
        {
            get { return _firstValue; }
        }

        public string MatchingValue
        {
            get { return _matchingValue; }
        }

        public bool IsMatch()
        {
            return _isMatch;
        }

        public MatchResult(bool isMatch)
        {
            _isMatch = isMatch;
            _firstValue = "";
            _secondValue = "";
            _matchingValue = "";
        }

        public new string ToString()
        {
            return (_isMatch + "," + _matchingValue).TrimEnd(new[] {','});
        }
    }
}