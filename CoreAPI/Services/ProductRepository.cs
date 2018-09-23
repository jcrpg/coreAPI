using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPI.Data;
using CoreAPI.Models;

namespace CoreAPI.Services
{
    public class ProductRepository : IProduct
    {
        private ProductsDBContext productsDbContext;
        public ProductRepository(ProductsDBContext context)
        {
            productsDbContext = context;
        }

        public void AddProduct(Product product)
        {
            productsDbContext.Products.Add(product);
            productsDbContext.SaveChanges(true);
        }

        public void DeleteProduct(int id)
        {
            var product = productsDbContext.Products.Find(id);
            productsDbContext.Products.Remove(product);
            productsDbContext.SaveChanges(true);
        }

        public Product GetProduct(int id)
        {
            var product = productsDbContext.Products.SingleOrDefault(m => m.ProductId == id);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return productsDbContext.Products;
        }

        public void UpdateProduct(Product product)
        {
            productsDbContext.Products.Update(product);
            productsDbContext.SaveChanges(true);
        }
    }
}
