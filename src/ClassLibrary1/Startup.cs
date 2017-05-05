using System;
using Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Arbor.AspnetCore.Mvc.Formatting.HtmlForms.Tests.Integration
{
    public class Startup2
    {
        private readonly ILoggerFactory _loggerFactory;

        public Startup2(ILoggerFactory loggerFactory)
        {
            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            _loggerFactory = loggerFactory;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddMvc(
                options =>
                {
                    options.InputFormatters.Add(
                        new XWwwFormUrlEncodedFormatter(_loggerFactory.CreateLogger<XWwwFormUrlEncodedFormatter>()));
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (env == null)
            {
                throw new ArgumentNullException(nameof(env));
            }

            app.UseMvc();
        }
    }
}
