using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;

            Console.WriteLine("Please ENTER Input Text");
            Console.WriteLine();
            text = Console.ReadLine();

            Compute textProcessor = new Compute();
            // Test 1 -- This method essentially should satisfy the Requested piece of work!!
            //           that of Printing each word and occurances 
            IList<IWordFrequency> MostFrequentWordsList
                = textProcessor.CalculateMostFrequentNWords(text);
            // Can be run with a depth parameter that will take Num of highest frequencies, 3 in the case below:
            // = textProcessor.CalculateMostFrequentNWords(text, 3);

            if (MostFrequentWordsList.Count > 0)
            {
                Console.WriteLine("\nTest 1 -- \nOutput:");
                foreach (var element in MostFrequentWordsList)
                    Console.WriteLine("{0} - {1}",
                                      element.Word,
                                      element.Frequency);
            }
            else
            {
                Console.WriteLine("Test 1 -- No Words Entered! Please INPUT Text");
            }

            // Test 2 -- Additional functionality (not called for!)
            Console.WriteLine("\n\nTest 2 -- Highest Frequency for usique Word(s) is:\t\t\t {0}",
                              textProcessor.CalculateHighestFrequency(text));        

            // Test 3 -- Additional functionality (not called for!)
            //           Assuming we want to find ocurance of "statement"....
            Console.WriteLine("\nTest 3 -- Frequency for statement Occurs:\t\t\t\t {0}",
                              textProcessor.CalculateFrequencyForWord(text, "statement"));

            Console.WriteLine();

            Console.Write("Please PRESS any Key to Continue!");
            Console.ReadLine();
        }
    }
}
