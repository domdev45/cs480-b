using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using quotable.core;
using quotable.core.data;

namespace quotable.console
{
    class Program
    {
        
		// [miko]
		// entering the world of async
		// see the stackoverflow entry below if your visual studio 
		// is complaining about not finding a main method.
		// https://stackoverflow.com/a/44254451/167160
		static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // [miko]
            // even in a plain console application, we can use the dependency injection functionality
            // provided by microsoft...it is not limited to only aspnet.core applications.
            var container = new ServiceCollection();

            // setup to use a sqlite database
            container.AddDbContext<quoteableDbContext>(options => options.UseSqlite("Data Source=quote.db"), ServiceLifetime.Transient);
            // [miko]
            // getting a context that has already been disposed.
            // yup.
            // AddDbContext is implicitly scoped.
            // explicitly set the service lifetime
            // https://github.com/aspnet/EntityFrameworkCore/issues/4988

            var provider = container.BuildServiceProvider();

            using (var context = provider.GetService<quoteableDbContext>())
            {
                // [miko]
                // good for testing
                // bad for production...
                await context.Database.EnsureDeletedAsync();

                // [miko]
                // if the database doesn't exist it will be created
                // this should ideally only be run once in an application lifetime
                // this only ensure existence, this does not perform migrations.
                var dbDidntExist = await context.Database.EnsureCreatedAsync();

                if (dbDidntExist)
                {
                    await PopulateDatabase(context);
                }
            }

            using (var context = provider.GetService<quoteableDbContext>())
            {
                var documents = context.Quotes
                                        .Include(d => d.quoteAuthor)
                                        .ThenInclude(x => x.Author);

                foreach (var document in documents)
                {
                    Console.WriteLine($"document.id = {document.Id}");
                    Console.WriteLine($"document.title = {document.Quotes}");

                    foreach (var author in document.Authors)
                    {
                        Console.WriteLine($"document.author.id = {author.Id}");
                        Console.WriteLine($"document.author.firstname = {author.FirstName}");
                        Console.WriteLine($"document.author.firstname = {author.LastName}");
                    }

                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }

        private static async Task PopulateDatabase(quoteableDbContext context)
        {
            var author1 = new Author()
            {
                FirstName = "Dr",
                LastName = "Seuss"
            };
            var author2 = new Author()
            {
                FirstName = "Mr",
                LastName = "Spock"
            };
            var author3 = new Author()
            {
                FirstName = "Mr",
                LastName = "Tuvok"
            };

            var document1 = new quote();
            document1.Quotes = "Green Eggs and Ham";

            var document2 = new quote();
            document2.Quotes = "Vulcan, A Primer";

            var document3 = new quote();
            document3.Quotes = "Green Eggs and Vulcans";

            var da1 = new quoteAuthor() { Quote = document1, Author = author1 };
            var da2 = new quoteAuthor() { Quote = document2, Author = author2 };
            var da3 = new quoteAuthor() { Quote = document3, Author = author1 };
            var da4 = new quoteAuthor() { Quote = document3, Author = author2 };
            var da5 = new quoteAuthor() { Quote = document3, Author = author3 };

            context.AddRange(da1, da2, da3, da4, da5);

            await context.SaveChangesAsync();
        }
    }


    /*
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
    }*/
}
