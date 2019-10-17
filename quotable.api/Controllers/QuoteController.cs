using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotable.core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace quotable.api.Controllers
{
    [Route("api/[controller]")]
    public class QuoteController : Controller
    {
        SimpleRandomQuoteProvider Provider = new SimpleRandomQuoteProvider();
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Provider.getQuotes(3);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            
            if (id == 1)
            {
                return "ID 1" + " The greatest glory in living lies not in never falling, but in rising every time we fall." + " by Ralth Waldo Emerson  ";
            }
            if (id == 2)
            {
                return "ID 2" + " The way to get started is to quit talking and begin doing." + " by Walt Disney ";
            }
            if (id == 3)
            {
                return "ID 3" +" If life were predictable it would cease to be life, and be without flavor. " + " by Eleanor Roosevelt";
            }

            return "non valid value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
