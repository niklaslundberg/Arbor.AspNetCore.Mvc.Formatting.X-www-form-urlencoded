using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Xunit;

namespace Arbor.AspNetCore.Formatting.Tests.Integration
{
    public class WhenPostingComplexRootObjectWithValidProperties
    {
        private static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        [Fact]
        public async Task ThenItShouldBindValuesToObjectAndReturnObjectAsJson()
        {
            using (IWebHost buildWebHost = BuildWebHost(Array.Empty<string>()))
            {
                await buildWebHost.StartAsync();

                using (var client = new HttpClient())
                {
                    IEnumerable<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("RootTitle", "Abc"),
                        new KeyValuePair<string, string>("rootOtherProperty", "42")
                    };
                    HttpContent content = new FormUrlEncodedContent(pairs);
                    HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:5000", content);

                    Assert.Equal(HttpStatusCode.OK, httpResponseMessage.StatusCode);
                    string json = await httpResponseMessage.Content.ReadAsStringAsync();

                    var complexRootObject = JsonConvert.DeserializeObject<ComplexRootObject>(json);

                    Assert.Equal("Abc", complexRootObject.RootTitle);
                    Assert.Equal(42, complexRootObject.RootOtherProperty);
                }

                await buildWebHost.StopAsync();
            }
        }
    }
}
