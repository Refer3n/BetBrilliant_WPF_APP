using BetBriliant_DATA.API;
using BetBriliant_DATA.API.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBriliant_Domain.Providers.SportProviders
{
    public class BasketballSportProvider : ISportProvider
    {
        private readonly IApi sportApiEngine;

        public BasketballSportProvider()
        {
            sportApiEngine = new SportApiEngine("v1.basketball.api-sports.io");
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
                var result = new League
                {
                    Id = token.Value<int>("id"),
                    Name = token.Value<string>("name"),
                    LogoUrl = token.Value<string>("logo"),
                    CountryName = token["country"].Value<string>("name"),
                    CountryCode = token["country"].Value<string>("code"),
                    CountryFlagUrl = token["country"].Value<string>("flag")
                };

                return result;
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
                var end = season.Value<DateTime>("end");
                if (end >= DateTime.Now)
                    return true;
            }

            return false;
        }
    }
}
