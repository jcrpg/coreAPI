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
    public class ProductsController : Controller
    {
       static List<Product> _products = new List<Product>()
        {
            new Product(){ProductId= 0,ProductName="Laptop", ProductPrice="200"},
            new Product(){ProductId= 1,ProductName="SmartPhone", ProductPrice="200"}
        };

        public IEnumerable<Product> Get() {
            return _products;
        }

            public void Post(Product product)
        {
            _products.Add(product);
        }
    }
}