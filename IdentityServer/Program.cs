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
                .AddInMemoryClients(new List<Client>
                {
                    new Client
                    {
                        ClientId= "test",
                        ClientSecrets= new List<Secret>
                        {
                            new Secret("secret".Sha256())
                        },
                        AllowedGrantTypes=GrantTypes.ClientCredentials,
                        AllowedScopes=new List<string>
                        {
                            "api" 
                        }
                    }
                })
                .AddInMemoryApiScopes(new List<ApiScope> { new ApiScope(name:"api")});

            var app = builder.Build();

            app.UseIdentityServer();

            app.Run();
        }
    }
}