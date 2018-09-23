using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CoreAPI.Data;
using Microsoft.EntityFrameworkCore;
using CoreAPI.Services;
using Swashbuckle.AspNetCore.Swagger;
namespace CoreAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddApiVersioning();
            //services.AddMvc().AddXmlSerializerFormatters(); //return XML
            services.AddDbContext<ProductsDBContext>(option => option.UseSqlServer(@"Data Source=JCLP\SQLEXPRESS;Initial Catalog=CoreAPI;Integrated Security=true;"));
            services.AddScoped<IProduct, ProductRepository>();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info() { Title = "Product", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ProductsDBContext productDBContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API for Prouct"));

            app.UseMvc();
            productDBContext.Database.EnsureCreated();

        }
    }
}
