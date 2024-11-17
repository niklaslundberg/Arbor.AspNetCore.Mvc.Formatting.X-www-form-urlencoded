using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.SampleWeb
{
    using Serilog;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

            var webApplicationBuilder = WebApplication.CreateBuilder(args);

            webApplicationBuilder
                .Services.AddSerilog().AddMvc(
                options => options.InputFormatters.Add(new XWwwFormUrlEncodedFormatter()));
            webApplicationBuilder.Services.AddControllersWithViews();

            var app = webApplicationBuilder.Build();

            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(builder => builder.MapControllers());

            app.Run();

            logger.Dispose();
        }
    }
}
