using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    public class quoteAuthor
    {
        /// <summary>
		/// The ID of the document related to the author.
		/// </summary>
		public long QuoteId { get; set; }
        /// <summary>
        /// The document related to the author.
        /// </summary>
        public quote Quote { get; set; }

        /// <summary>
        /// The ID of the author related to the document.
        /// </summary>
        public long AuthorId { get; set; }
        /// <summary>
        /// The author related to the document.
        /// </summary>
        public Author Author { get; set; }

    }
}
