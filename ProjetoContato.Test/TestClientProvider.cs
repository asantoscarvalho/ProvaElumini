using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using ProjetoContato.Api;

namespace ProjetoContato.Test
{
    public class TestClientProvider : IDisposable
    {
        private TestServer server { get; set; }
        public HttpClient Client { get; private set; }
        public TestClientProvider()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = server.CreateClient();
        }

        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
    }
}