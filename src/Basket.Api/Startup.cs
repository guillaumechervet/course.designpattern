using System;
using Basket.OrientedObject;
using Basket.OrientedObject.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Basket.Api
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My Basket", Version = "v1" });
                c.IncludeXmlComments(
                    $@"{AppDomain.CurrentDomain.BaseDirectory}\Basket.Api.xml");
            });

            services.AddScoped<Basket.IDateTime, Basket.SystemDateTime>();
            services.AddScoped<IArticleDatabase, ArticleDatabaseJson>();
            services.AddScoped<ArticleFactory, ArticleFactory>();
            services.AddScoped<ILogger, LoggerExternal>();
            services.AddScoped<BasketService, BasketService>();
            services.AddScoped<BasketOperation, BasketOperation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Basket"); });
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
