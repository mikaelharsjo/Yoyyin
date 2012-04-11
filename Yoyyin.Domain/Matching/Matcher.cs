using System;
using System.Collections.Generic;
using System.Text;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.Users;
using MatchType = Yoyyin.Domain.Enumerations.MatchType;
using UserTypes = Yoyyin.Domain.Enumerations.UserTypes;

namespace Yoyyin.Domain.Matching
{
    public class Matcher
    {
        private IUser _firstUser;
        private IUser _secondUser;

        public IUser GetMatchingUser()
        {
            return _secondUser;
        }

        public MatchResult SniHeadMatch 
        { 
            get { return _matchResults[MatchType.SniHead]; }
        }
        public MatchResult SniNoMatch
        {
            get { return _matchResults[MatchType.SniItem]; }
        }
        public MatchResult SearchWordsMatchResult
        {
            get { return _matchResults[MatchType.SearchWords]; }
        }
        public MatchResult SearchWordsCompetenceMatch
        {
            get { return _matchResults[MatchType.SearchWordsCompetence]; }
        }
        public MatchResult UserTypeMatch
        {
            get { return _matchResults[MatchType.UserType]; }
        }
        
        private Dictionary<MatchType, MatchResult> _matchResults;
        private const int NumberOfMatchTypes = 5;

        public Matcher(User firstUser, User secondUser)
        {
            _secondUser = secondUser as IUser;
            _firstUser = firstUser as IUser;

            PeformMatch();
        }

        public Matcher(IUser firstUser, IUser secondUser)
        {
            _secondUser = secondUser;
            _firstUser = firstUser;

            PeformMatch();
        }

        private void PeformMatch()
        {
            _matchResults = new Dictionary<MatchType, MatchResult>
                                {
                                    {MatchType.SniHead, CheckSniHead()},
                                    {MatchType.SniItem, CheckSniNo()},
                                    {
                                        MatchType.SearchWords,
                                        CheckSearchWords(_firstUser.SearchWords, _secondUser.SearchWords)
                                        },
                                    {
                                        MatchType.SearchWordsCompetence,
                                        CheckSearchWords(_firstUser.SearchWordsCompetenceNeeded,
                                                         _secondUser.SearchWordsCompetence)
                                        },
                                    {
                                        MatchType.UserType,
                                        CheckUserType(_firstUser.UserTypesNeeded, _secondUser.UserType.ToString())
                                        }
                                };
        }

        private MatchResult CheckSniHead()
        {
            if (string.IsNullOrEmpty(_firstUser.SniHeadID) || string.IsNullOrEmpty(_secondUser.SniHeadID))
                return new MatchResult(false);

            bool isMatch = _firstUser.SniHeadID == _secondUser.SniHeadID;
            return new MatchResult(isMatch, _firstUser.SniHead != null ? _firstUser.SniHead.Title : string.Empty,
                                   _secondUser.SniHead != null ? _secondUser.SniHead.Title : string.Empty, 
                                   string.Empty);
        }

        private MatchResult CheckSniNo()
        {
            if (string.IsNullOrEmpty(_firstUser.SniNo) || string.IsNullOrEmpty(_secondUser.SniNo))
                return new MatchResult(false);

            bool isMatch = _firstUser.SniNo == _secondUser.SniNo;
            return new MatchResult(isMatch, 
                                    _firstUser.SniItem != null ? _firstUser.SniItem.Title : _firstUser.SniNo,
                                   _secondUser.SniItem != null ? _secondUser.SniItem.Title : _secondUser.SniNo,
                                   string.Empty);
        }

        private MatchResult CheckUserType(string userTypesNeeded, string secondUserType)
        {
            if (string.IsNullOrEmpty(userTypesNeeded) || string.IsNullOrEmpty(secondUserType))
                return new MatchResult(false);

            string allNeededUserTypesTitles = "";
            var compareWithUserType = (UserTypes)Enum.Parse(typeof(UserTypes), secondUserType);
            foreach (string userType in userTypesNeeded.Split(','))
            {
                var firstType = (UserTypes) Enum.Parse(typeof (UserTypes), userType);
                allNeededUserTypesTitles += firstType.GetTitle() + ", ";
                if (firstType == compareWithUserType)
                    return new MatchResult(true, firstType.GetTitle(), compareWithUserType.GetTitle(),
                                           string.Empty);
            }
             
            return new MatchResult(false, allNeededUserTypesTitles, compareWithUserType.GetTitle(), string.Empty);
        }

        private MatchResult CheckSearchWords(string firstWords, string secondWords)
        {
            if (string.IsNullOrEmpty(firstWords) || string.IsNullOrEmpty(secondWords))
                return new MatchResult(false);

            var secondWordsArray = secondWords.Split(',');

            foreach (var searchWord in firstWords.Split(','))
            {
                foreach (var searchWord2 in secondWordsArray)
                {
                    if (searchWord.ToLower().Contains(searchWord2.ToLower()))
                        return new MatchResult(true, firstWords.Replace(",", ", "), secondWords.Replace(",", ", "), searchWord);
                    if (searchWord2.ToLower().Contains(searchWord.ToLower()))
                        return new MatchResult(true, firstWords.Replace(",", ", "), secondWords.Replace(",", ", "), searchWord);
                }
            }

            return new MatchResult(false, firstWords, secondWords, string.Empty);
        }

        public string GetResultsAsHtmlTable()
        {
            const string htmlStart = "<table>";            
            const string htmlEnd = "</table>";
            var stringBuilder = new StringBuilder();            

            stringBuilder.Append(htmlStart);

            foreach (int value in Enum.GetValues(typeof(MatchType)))
            {
                var matchType = (MatchType)value;
                stringBuilder.Append(GetResultAsTableRow(_matchResults[matchType], matchType));
            }

            //foreach (MatchType matchType in MatchType)
            //for (int i = 0; i < _matchResults.Count; i++)
              
            //stringBuilder.Append(GetResultAsTableRow(_matchResults.Values[i], MatchType.SniItem));            
                //foreach (var matchResult in _matchResults.Values)            
                //stringBuilder.Append(GetResultAsTableRow(matchResult, MatchType.SniItem));            

            stringBuilder.Append(htmlEnd);

            return stringBuilder.ToString();            
        }

        private static string GetResultAsTableRow(MatchResult matchResult, MatchType matchType)
        {
            const string htmlRow = "<tr><td class='matchTableFirstCell'>{3}<td class='matchTableContentCell'>{0}</td><td class='matchTableIconCell'><img src='Styles/Images/{1}.png' /></td><td class='matchTableContentCell'>{2}</td></tr>";

            string returnValue = string.Format(htmlRow, HighlightMatchingWord(matchResult, matchResult.FirstValue), matchResult.IsMatch(), HighlightMatchingWord(matchResult, matchResult.SecondValue), matchType.GetTitle());

            return returnValue;
        }

        private static string HighlightMatchingWord(MatchResult matchResult, string input) 
        {
            if (matchResult.MatchingValue == string.Empty) // don't highlight
                return input;
            return input.Replace(matchResult.MatchingValue, "<strong>" + matchResult.MatchingValue + "</strong>");
        }

        public bool HasMatch()
        {
            return SniHeadMatch.IsMatch() || SniNoMatch.IsMatch() || SearchWordsCompetenceMatch.IsMatch() || SearchWordsMatchResult.IsMatch() || UserTypeMatch.IsMatch();
        }

        public int GetMatchCount()
        {
            int count = SniHeadMatch.IsMatch() ? 1 : 0;
            count += SniNoMatch.IsMatch() ? 1 : 0;
            count += SearchWordsCompetenceMatch.IsMatch() ? 1 : 0;
            count += SearchWordsMatchResult.IsMatch() ? 1 : 0;
            count += UserTypeMatch.IsMatch() ? 1 : 0;

            return count;
        }

        public int GetMatchCountAsPercentage()
        {
            return Convert.ToInt32((float)GetMatchCount() / (float)NumberOfMatchTypes * 100);
        }
    }
}