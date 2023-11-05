using BetBriliant_DATA.API;
using BetBriliant_DATA.API.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBriliant_Domain.Providers.SportProviders
{
    public class RugbySportProvider : ISportProvider
    {
        private readonly IApi sportApiEngine;

        public RugbySportProvider()
        {
            sportApiEngine = new SportApiEngine("v1.rugby.api-sports.io");
        }

        public async Task<List<League>> GetSportLeaguesAsync()
        {
            var response = await sportApiEngine.GetLeaguesAsync();
            JObject json = JObject.Parse(response);
            JToken responseToken = json["response"];

            if (responseToken is JArray leagueTokens)
            {
                var result = leagueTokens
                            .Select(GetLeagueFromJson)
                            .Where(league => league != null).ToList();
                return result;
            }

            return new List<League>();
        }

        public League GetLeagueFromJson(JToken token)
        {
            if (IsLeagueActive(token))
            {
                return new League
                {
                    Id = token.Value<int>("id"),
                    Name = token.Value<string>("name"),
                    LogoUrl = token.Value<string>("logo"),
                    CountryName = token["country"].Value<string>("name"),
                    CountryCode = token["country"].Value<string>("code"),
                    CountryFlagUrl = token["country"].Value<string>("flag")
                };
            }

            return null;
        }

        public bool IsLeagueActive(JToken leagueToken)
        {
            JArray seasonTokens = JArray.Parse(leagueToken["seasons"].ToString());

            if (seasonTokens.Count < 1)
                return false;

            foreach (var season in seasonTokens)
            {
                var endDate = season.Value<DateTime>("end");
                if (endDate >= DateTime.Now)
                    return true;
            }

            return false;
        }
    }
}
