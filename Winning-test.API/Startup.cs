using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winning_test.DAL.Databases.WinningDb;
using Winning_test.Repository.Implementation;
using Winning_test.Repository.Interface;
using Winning_test.Services.Implementation;
using Winning_test.Services.Interface;

namespace Winning_test
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();

            services.Configure<WinningDbSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("WinningDbSettings:ConnectionString").Value;
                options.DatabaseName = Configuration.GetSection("WinningDbSettings:DatabaseName").Value;
            });

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<IWinningDbContext, WinningDbContext>();
            services.AddScoped<IWinningProductsRepository, WinningProductsRepository>();
            services.AddScoped<IWinningProductsService, WinningProductsService>();

            services.AddMemoryCache();

            ConfigureSwagger(services);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("../swagger/v1/swagger.json", "WINNING-TEST API");
            });
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.RelativePath}");
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Winning-test API",
                    Description = "Winning-test API"
                });
                var app = PlatformServices.Default.Application;
                var swaggerFile = System.IO.Path.Combine(app.ApplicationBasePath, @"Winning-test.API.xml");
                options.IncludeXmlComments(swaggerFile);
            });
        }
    }
}
