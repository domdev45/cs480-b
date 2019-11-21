using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core.data
{
    public class quoteableDbContext : DbContext
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public quoteableDbContext(DbContextOptions options) : base(options)
        {

        }
        /// <summary>
		/// Used to access documents in the database.
		/// </summary>
		public DbSet<quote> Quotes { get; set; }

        /// <summary>
        /// Used to access authors in the database.
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<quoteAuthor>().HasKey(x => new { x.QuoteId, x.AuthorId });
        }
    }
}
