using DeveloperPortal.Domain.Interfaces;
using Microsoft.Extensions.Configuration;


namespace DeveloperPortal.Application.Services
{
    public class AngelenoAuthenticationService:IAngelenoAuthentication
    {
        private readonly IConfiguration _configuration;

        public AngelenoAuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateSessionID()
        {
            // string key = _configuration["Appsettings:AngelenoLogin"].ToString();
            string NewGuid = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration["Angeleno:BaseUrl"] + "/Home/GetSessionId");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36");

                var result = client.GetAsync("").Result;

                if (result.IsSuccessStatusCode)
                {
                    NewGuid = result.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    string loginGuid = Guid.NewGuid().ToString();
                }
            }

            return NewGuid;

        }

        public async Task<string> ValidateCredientials(string tokenId)
        {
            string validateUrl = _configuration["Angeleno:BaseUrl"]
                               + _configuration["Angeleno:ValidateCredUrl"]
                               + tokenId;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(validateUrl);
                if (!response.IsSuccessStatusCode) {
                    Console.WriteLine($"Angeleno validation failed: {response.StatusCode}");
                    return string.Empty;
                }
            
                // Read the body once
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Raw Angeleno validation response: '{body}'");
            
                return body;
            }
        }

    }
}
