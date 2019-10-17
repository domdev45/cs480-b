using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    /// <summary>
    /// Implements the RandomQuoteProvider interface
    /// contains a constructor that takes in a IEnumerable<string> that contains a list of quotes
    /// </summary>
    public class DefaultRandomQuoteGenerator : RandomQuoteProvider
    {
        /// <summary>
        /// List of quotes
        /// </summary>
        IEnumerable<string> quoteList;

        /// <summary>
        /// Constructor that accepts a list of quotes and stores it in quoteList
        /// </summary>
        /// <param name="quoteList"></param>
        DefaultRandomQuoteGenerator(IEnumerable<string> quoteList)
        {
            this.quoteList = quoteList;
        }

        IEnumerable<string> RandomQuoteProvider.getQuotes(long numOfQuotes)
        {
            throw new NotImplementedException();
        }
    }
}
