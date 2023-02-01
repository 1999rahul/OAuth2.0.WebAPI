using IdentityModel.Client;

namespace ClientConsoleApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                var doc = await client.GetDiscoveryDocumentAsync(address: "https://localhost:7139");
                Console.WriteLine("getting token endpoints");
                Console.WriteLine(doc.TokenEndpoint);


                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address=doc.TokenEndpoint,
                    ClientId="test",
                    ClientSecret="secret",
                    Scope="api"
                });
                var token = tokenResponse.AccessToken;
                using (var client2 = new HttpClient())
                {
                    client2.SetBearerToken(token);
                    var response=await client2.GetStringAsync("https://localhost:7280/WeatherForecast");
                    Console.WriteLine(response);
                }
                Console.ReadKey();  
            }
        }
    }
}