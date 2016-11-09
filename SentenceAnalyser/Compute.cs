using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace SentenceAnalyser
{
    public class Compute : IWordFrequencyAnalyzer
    {
        const int MaxFrequenciesToTake = 100;
        public IList<IWordFrequency> CalculateMostFrequentNWords(string text, int numWordFreqToTake = 0)
        {
            numWordFreqToTake = (numWordFreqToTake == 0) ? MaxFrequenciesToTake : numWordFreqToTake;
            return (from wf in ParseText(text)
                    orderby wf.Frequency descending
                    select wf).Take(numWordFreqToTake).ToList();
        }

        public int CalculateHighestFrequency(string text)
        {
            return (text.Length > 0) ? ParseText(text).Max(x => x.Frequency) : 0;
        }

        public int CalculateFrequencyForWord(string text, string word)
        {
            var r = ParseText(text).Where(x => x.Word == word).SingleOrDefault();
            return r == null ? 0 : r.Frequency;
        }
        enum Case { CaseSensitive = 0, CaseInSensitive };

        private static IEnumerable<IWordFrequency> ParseText(string text, Case caseType = Case.CaseInSensitive)
        {
            var counts = new Dictionary<string, int>();

            foreach (Match match in _wordMatcher.Matches(text))
            {
                int count;
                counts.TryGetValue(match.Value, out count);
                counts[(caseType == Case.CaseInSensitive)?match.Value.ToLower():match.Value] = ++count;
            }

            return counts.Select(x => new WordFrequency { Word = x.Key, Frequency = x.Value });
        }

        [ThreadStatic]
        private static Regex _wordMatcher = new Regex(@"\b[a-zA-Z]+\b");
    }
}

