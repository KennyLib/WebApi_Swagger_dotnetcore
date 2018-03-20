using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/test")]

    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        [ApiExplorerSettings(GroupName = "v1")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ApiExplorerSettings(GroupName = "v1")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [ApiExplorerSettings(GroupName = "v1")]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ApiExplorerSettings(GroupName = "v1")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ApiExplorerSettings(GroupName = "v1")]
        public void Delete(int id)
        {
        }
    }
}
