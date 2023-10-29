using BetBriliant_DATA.API;
using BetBriliant_DATA.API.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBriliant_Domain.Providers
{
    public class SportProvider
    {
        private readonly IApi engine;
        public SportProvider()
        {
            engine = new BetBriliantApiEngine();
        }

        public async Task<List<Sport>> GetSportsAsync()
        {
            string json = await engine.GetSportsAsync();
            JArray jTokens = JArray.Parse(json);

            if (jTokens == null)
                return null;

            List<Sport> result = jTokens.Select(GetSportFromJson).ToList();

            return result;
        }

        private Sport GetSportFromJson(JToken token)
        {
            return new Sport
            {
                Key = token.Value<string>("key"),
                Group = token.Value<string>("group"),
                Title = token.Value<string>("title")
            };
        }
    }
}
