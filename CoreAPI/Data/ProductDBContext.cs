using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPI.Models;

namespace CoreAPI.Data
{
    public class ProductDBContext:DbContext
    {

        public ProductDBContext(DbContextOptions<ProductDBContext> options):base(options)
        {

        } 

        public DbSet<Product> Products { get; set; }
    }
}
