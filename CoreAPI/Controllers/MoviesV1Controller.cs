using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/Movies")]
    public class MoviesV1Controller : Controller
    {

        static List<MoviesV1> movies = new List<MoviesV1>()
        {
            new MoviesV1(){Id = 0, MovieName="Missino Impossible"},
            new MoviesV1(){Id=1,MovieName="JumanJi"}


        };
        // GET: api/MoviesV1
        [HttpGet]
        public IEnumerable<MoviesV1> Get()
        {
            return movies;
        }

        // GET: api/MoviesV1/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/MoviesV1
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/MoviesV1/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
