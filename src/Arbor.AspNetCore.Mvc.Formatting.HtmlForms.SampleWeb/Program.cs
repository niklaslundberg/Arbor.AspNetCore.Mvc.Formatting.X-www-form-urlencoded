namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.SampleWeb
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    using Serilog;

    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(
                    builder => { builder.UseStartup<Startup>()

                .UseSerilog(logger);
                    })

                .Build();

            host.Run();

            logger.Dispose();
        }
    }
}
