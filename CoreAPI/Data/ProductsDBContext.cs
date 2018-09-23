using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPI.Models;

namespace CoreAPI.Data
{
    public class ProductsDBContext:DbContext
    {

        public ProductsDBContext(DbContextOptions<ProductsDBContext> options):base(options)
        {

        } 

        public DbSet<Product> Products { get; set; }
    }
}
