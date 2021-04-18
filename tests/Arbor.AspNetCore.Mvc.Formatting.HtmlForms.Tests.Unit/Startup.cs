using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core.Tests.Unit
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddControllers();

            services.AddMvc(
                options =>
                {
                    options.InputFormatters.Add(
                        new XWwwFormUrlEncodedFormatter());
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (env == null)
            {
                throw new ArgumentNullException(nameof(env));
            }

            app.UseRouting();

            app.UseEndpoints(options => options.MapControllers());
        }
    }
}
