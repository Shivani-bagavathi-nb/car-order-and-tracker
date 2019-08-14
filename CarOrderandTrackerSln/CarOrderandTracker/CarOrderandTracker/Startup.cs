using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CarOrder.Aggregate.Model.Models;
using static CarOrder.Aggregate.Model.Models.Order;
using CarOrder.Aggregate.Model.Context;
using OrderContext = CarOrder.Aggregate.Model.Context.OrderContext;
using UserContext = CarOrder.Aggregate.Model.Context.UserContext;
//using OrderContext = CarOrder.Aggregate.Model.Context.OrderContext;
//using static CarOrder.Aggregate.Model.Models.User;

namespace CarOrder.Aggregate
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connection = @"Server=(localdb)\mssqllocaldb;Database=CarOrder.Aggregate.Model;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<OrderContext>
                (options => options.UseSqlServer(connection, b => b.MigrationsAssembly("CarOrder.Aggregate")));
            services.AddDbContext<UserContext>
               (options => options.UseSqlServer(connection, b => b.MigrationsAssembly("CarOrder.Aggregate")));
            // BloggingContext requires

            // UseSqlServer requires
            // using Microsoft.EntityFrameworkCore;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
