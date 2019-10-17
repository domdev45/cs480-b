using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    /// Interface that contains a method that will return a list of strings based on the number passed into the method
    public interface RandomQuoteProvider
    {
        IEnumerable<string> getQuotes(long numOfQuotes);
    }
}