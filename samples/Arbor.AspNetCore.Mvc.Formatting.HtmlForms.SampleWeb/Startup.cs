using Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.SampleWeb
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(builder => builder.MapControllers());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(
                options =>
                {
                    options.InputFormatters.Add(new XWwwFormUrlEncodedFormatter());
                });

            services.AddControllersWithViews();
        }
    }
}