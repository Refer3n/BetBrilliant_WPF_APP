using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BetBriliant_DATA.API
{
    public class SportApiEngine : IApi
    {
        private static string _apiKey = "1cde9cd1b64cf1329a9e65a64993b848";
        private readonly string _hostName;

        public SportApiEngine(string hostName)
        {
            _hostName = hostName;
        }

        public async Task<string> GetLeaguesAsync()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", _apiKey);
                httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", _hostName);

                var response = await httpClient.GetAsync($"https://{_hostName}/leagues");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                else
                {
                    throw new Exception("Api connect failed!");
                }
            }
        }
    }
}

