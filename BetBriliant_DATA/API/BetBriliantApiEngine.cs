using System.Net.Http;
using System.Threading.Tasks;

namespace BetBriliant_DATA.API
{
    public class BetBriliantApiEngine : IApi
    {
        private readonly string _baseUri = "https://api.the-odds-api.com/v4/sports/";
        private readonly string _apiKey = "da8cccb38cc3356e7cccea4fc30a1cc8";
        private readonly HttpClient _client;

        public BetBriliantApiEngine()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetOddsAsync(string sport, string markets = "h2h", string bookmakers = "fanduel,betmgm,williamhill,betvictor")
        {
            var requestUri = $"{sport}/odds/?apiKey={_apiKey}&markets={markets}&bookmakers={bookmakers}";
            var response = await _client.GetAsync(_baseUri + requestUri);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetSportsAsync()
        {
            var response = await _client.GetAsync(_baseUri + $"?apiKey={_apiKey}");
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
