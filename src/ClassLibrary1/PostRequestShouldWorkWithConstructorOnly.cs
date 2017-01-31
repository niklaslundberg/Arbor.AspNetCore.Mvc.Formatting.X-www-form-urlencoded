using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace Arbor.AspNetCore.Formatting.HtmlForms.Tests.Integration
{
    public class PostRequestShouldWorkWithConstructorOnly : IDisposable
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public PostRequestShouldWorkWithConstructorOnly()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnHelloWorld()
        {
            var response = await _client.PostAsync("/", new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("a", "hello"),
                new KeyValuePair<string, string>("b", "4"),
            }));

            Assert.Equal(200, (int) response.StatusCode);
        }

        public void Dispose()
        {
            _server?.Dispose();
        }
    }
}
