using Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Arbor.AspNetCore.Formatting.Tests.Integration
{
    public class Startup
    {
        private readonly ILoggerFactory _loggerFactory;

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            ILogger<XWwwFormUrlEncodedFormatter> logger = _loggerFactory.CreateLogger<XWwwFormUrlEncodedFormatter>();
            var xWwwFormUrlEncodedFormatter = new XWwwFormUrlEncodedFormatter(logger);


            services.AddMvc(options => { options.InputFormatters.Insert(0, xWwwFormUrlEncodedFormatter); });

            services.AddControllersWithViews();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(builder => builder.MapControllers());
        }
    }
}
