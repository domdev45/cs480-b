using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    /// Implements the RandomQuoteProveider interface
    /// contains a method that returns a list of quotes based on the number of quotes that are requested
    public class SimpleRandomQuoteProvider : RandomQuoteProvider
    {
        /// This method accepts a long that represents the number of quotes the user wants
        /// It will return quotes
        public IEnumerable<string> getQuotes(long numOfQuotes)
        {
            List<string> myQuotes = new List<string>();

            switch (numOfQuotes)
            {
                case 1:
                    myQuotes.Add("The greatest glory in living lies not in never falling, but in rising every time we fall.");
                    break;
                case 2:
                    myQuotes.Add("The way to get started is to quit talking and begin doing.");
                    myQuotes.Add("Your time is limited, so don't waste it living someone else's life.");
                    break;
                case 3:
                    myQuotes.Add("If life were predictable it would cease to be life, and be without flavor.");
                    myQuotes.Add("f you look at what you have in life, you'll always have more. If you look at what you don't have in life, you'll never have enough.");
                    myQuotes.Add("If you set your goals ridiculously high and it's a failure, you will fail above everyone else's success.");
                    break;
                default:
                    myQuotes.Add("   ");
                    break;
            }
            
            return myQuotes;

            throw new NotImplementedException();
        }

       public IEnumerable<string> GetRandomQuote()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 4);
            List<string> myQuotes = new List<string>();
            if (num == 1)
            {
                 myQuotes.Add("ID 1" + " The greatest glory in living lies not in never falling, but in rising every time we fall." + " by Ralth Waldo Emerson  ");
            }
            if (num == 2)
            {
                myQuotes.Add("ID 2" + " The way to get started is to quit talking and begin doing." + " by Walt Disney ");
            }
            if (num == 3)
            {
                myQuotes.Add("ID 3" + " If life were predictable it would cease to be life, and be without flavor. " + " by Eleanor Roosevelt");
            }
            

            return myQuotes;
        }
    }
}
