using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

using System.Net;
using System.Runtime.Serialization;


namespace quotable.core
{
    public class quote
    {
        /// <summary>
        /// The unique identifier for the document.
        /// </summary>

        public long Id { get; set; }

        /// <summary>
        /// The title of the document.
        /// </summary>
        public string Quotes { get; set; }

        /// <summary>
        /// The collection of authors of the document
        /// </summary>
        [NotMapped]
        public IEnumerable<Author> Authors => from x in quoteAuthor select x.Author;

        /// <summary>
        /// The relation of document to author
        /// </summary>
        public ICollection<quoteAuthor> quoteAuthor { get; set; } = new List<quoteAuthor>();
    }
}
