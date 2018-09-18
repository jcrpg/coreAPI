using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsBUController : Controller
    {
        static List<Product> _products = new List<Product>()
        {
            new Product(){ProductId= 0,ProductName="Laptop", ProductPrice="200"},
            new Product(){ProductId= 1,ProductName="SmartPhone", ProductPrice="200"}
        };

        //public IEnumerable<Product> Get() {
        //    return _products;
        //}
        [HttpGet]
        public IActionResult GetProduct()
        {
            //return StatusCode(StatusCodes.Status100Continue);
            return Ok(_products);
            //return BadRequest();
            //return NotFound();
        }

        [HttpGet("LoadWelcomeMessage")]
        public IActionResult GetWelcomeMessage()
        {
            return Ok("Welcome to my site");
        }



        //[HttpPost]
        //public void Post([FromBody]Product product)
        //{
        //    _products.Add(product);
        //}
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            _products.Add(product);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            _products[id] = product;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _products.RemoveAt(id);
        }

    }
}