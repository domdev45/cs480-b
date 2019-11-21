using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using quotable.core;
using quotable.core.data;

namespace quotable.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddDbContext<quoteableDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<quoteableDbContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                PopulateDatabase(context);
            }
        }

        private static void PopulateDatabase(quoteableDbContext context)
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

            context.SaveChanges();
        }
    }

}

