using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceAnalyser
{
    public interface IWordFrequency
    {
        string Word { get; }
        int Frequency { get; }
    }
}
