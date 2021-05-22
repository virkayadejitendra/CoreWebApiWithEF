using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreWebApiWithEF.Models;

namespace CoreWebApiWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private BloggingContext _dbContext;
        public ValuesController(BloggingContext context)
        {
            _dbContext= context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
                
                var blogs = _dbContext.Blogs
                    .OrderBy(b => b.BlogId)
                    ;
        List<string> allUrls=new List<string>();
        foreach(var item in blogs)
        {
            allUrls.Add(item.Url);
        }

            return allUrls.ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _dbContext.Add(new Blog { Url = "http://blogs.msdn.com/adonet " + value +" on "+DateTime.Now.ToLongTimeString() });
                _dbContext.SaveChanges();
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
