using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotable.core;

namespace quotable.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        SimpleRandomQuoteProvider Provider = new SimpleRandomQuoteProvider();

       public ValuesController(SimpleRandomQuoteProvider provider)
		{
			Provider = provider;
		}

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Provider.getQuotes(3);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            List<string> myQuotes = new List<string>();
            if (id == 1)
            {
                return "The greatest glory in living lies not in never falling, but in rising every time we fall.";
            }
            if (id == 2)
            {
                return "The way to get started is to quit talking and begin doing.";
            }
            if (id == 3)
            {
                return "If life were predictable it would cease to be life, and be without flavor. ";
            }

            return "non valid value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
