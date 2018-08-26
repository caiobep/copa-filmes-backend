using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.Controllers 
{
    [Route("/api/[controller]")]
    public class ValuesController : Controller 
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Value1", "Value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"value {id}";
        }

        [HttpPost]
        public void Post([FromBody]string value) 
        {
        }

    }
}
