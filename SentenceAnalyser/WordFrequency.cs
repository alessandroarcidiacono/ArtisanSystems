using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceAnalyser
{
    class WordFrequency : IWordFrequency
    {
        public string Word { get; internal set; }
        public int Frequency { get; internal set; }
    }
}
