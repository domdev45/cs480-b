using System;
using System.Collections.Generic;
using quotable.core;

namespace quotable.console
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleRandomQuoteProvider sr = new SimpleRandomQuoteProvider();
            long numOfQuotes = long.Parse(Console.ReadLine());
            IEnumerable<string> quotes = sr.getQuotes(numOfQuotes);

            foreach (string q in quotes)
            {
                Console.WriteLine(q);
            }
        }
    }
}
