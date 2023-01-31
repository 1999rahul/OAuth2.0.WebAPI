using Duende.IdentityServer.Models;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services=builder.Services;

            services.AddIdentityServer()
                .AddInMemoryClients(new List<Client>())
                .AddInMemoryApiScopes(new List<ApiScope>());

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}