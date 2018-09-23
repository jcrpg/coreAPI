using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Services;

namespace CoreAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private ProductsDBContext _productsDbContext;
        private IProduct productRepository;


        public ProductsController(IProduct product)
        {
            productRepository = product;
        }

        // GET: api/Products
        //[HttpGet]
        //public IEnumerable<Product> Get(string sortPrice)
        //{
        //    IQueryable<Product> products;
        //    switch (sortPrice)
        //    {
        //        case "desc":
        //            products = _productsDbContext.Products.OrderByDescending(p => p.ProductPrice);
        //            break;
        //        case "asc":
        //            products = _productsDbContext.Products.OrderBy(p => p.ProductPrice);
        //            break;
        //        default:
        //            products = _productsDbContext.Products;
        //            break;
        //    }

        //    return products;
        //}

        [HttpGet]
        public IEnumerable<Product> Get(string searchProduct)
        {
            var prod = _productsDbContext.Products.Where(p => p.ProductName.StartsWith(searchProduct));
            return prod;
        }
        [HttpGet]
        public IEnumerable<Product> Get(int pageNumber, int pageSize)
        {
            var products = from p in _productsDbContext.Products.OrderBy(a => a.ProductId) select p;
            var items = products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return items;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public IActionResult  Get(int id)
        {
            var product = productRepository.GetProduct(id);
            if (product == null)
            {
                return NotFound("No Record Found...");
            }
            return Ok(product);

        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            productRepository.AddProduct(product);
            return StatusCode(StatusCodes.Status201Created);

        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productRepository.GetProducts();
        }
        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != product.ProductId)
            {
                return BadRequest();
            }
            try
            {
                productRepository.UpdateProduct(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound("No Record Found against this Id...");
            }
            return Ok("Product Updated...");

        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productsDbContext.Products.SingleOrDefault(m => m.ProductId == id);

            if (product is null)
                return NotFound("No record found");
            try
            {
                _productsDbContext.Products.Remove(product);
                _productsDbContext.SaveChanges(true);

                return Ok("Product deleted....");
            }
            catch (Exception ex)
            {
                return NotFound("no record found");
            }
        }
    }
}
