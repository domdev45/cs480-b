using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotable.core;
using quotable.core.data;
using quote = quotable.api.models.quote;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace quotable.api.Controllers
{
    /// <summary>
	/// API controller for the '/documents' resource.
	/// </summary>
	[Route("api/[controller]")]
    [ApiController]
    public class DataQuoteController : ControllerBase
    {
        private readonly quoteableDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">The database context to data access.</param>
        public DataQuoteController(quoteableDbContext context)
        {
            _context = context;
        }

        // GET api/values
        /// <summary>
        /// Returns all the documents.
        /// </summary>
        /// <returns>All the documents.</returns>
        [HttpGet]
        public IEnumerable<quote> Get()
        {
            return from document in _context.Quotes
                   select new quote()
                   {
                       Quote = document.Quotes
                   };
        }

        // GET api/values/5
        /// <summary>
        /// Gets a specific document.
        /// </summary>
        /// <param name="id">The id of the document to get.</param>
        /// <returns>The document.</returns>
        [HttpGet("{id}")]
        public ActionResult<quote> Get(long id)
        {
            var document = _context.Quotes.SingleOrDefault(d => d.Id == id);

            if (document == null)
            {
                return NotFound();
            }

            return new quote()
            {
                Quote = document.Quotes
            };
        }
    }

}
