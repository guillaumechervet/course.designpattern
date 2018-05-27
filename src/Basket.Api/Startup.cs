using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basket.OrientedObject.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ILogger = Microsoft.Extensions.Logging.ILogger;

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

            services.AddScoped<Basket.IDateTime, Basket.SystemDateTime>();
            services.AddSingleton<IArticleDatabase, ArticleDatabaseJson>();
            services.AddSingleton<ArticleFactory, ArticleFactory>();
            services.AddSingleton<ILogger, LoggerExternal>();
            services.AddSingleton<BasketService, BasketService>();

            //IArticleDatabase articleDatabase, ArticleFactory articleFactory, ILogger logger

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
