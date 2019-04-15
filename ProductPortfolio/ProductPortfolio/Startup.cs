using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductPortfolio.Configuration;
using ProductPortfolio.Interfaces;
using ProductPortfolio.Middleware;
using ProductPortfolio.Service;

namespace ProductPortfolio
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

            services.AddScoped<IProducts, ProductsService>();

            // Allow only Https connections globally
            services.Configure<MvcOptions>(options =>
                                           {
                                               options.Filters.Add(new RequireHttpsAttribute());
                                           });

            services.Configure<AuthenticationSettings>(Configuration.GetSection("Authentication"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<AuthenticationMiddleware>();
            app.UseMvc();
        }
    }
}
