using BetBriliant_DATA.API;
using BetBriliant_DATA.API.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBriliant_Domain.Providers.SportProviders
{
    public class HockeySportProvider : ISportProvider
    {
        private readonly IApi sportApiEngine;

        public HockeySportProvider()
        {
            sportApiEngine = new SportApiEngine("v1.hockey.api-sports.io");
        }

        public async Task<List<League>> GetSportLeaguesAsync()
        {
            var response = await sportApiEngine.GetLeaguesAsync();
            JObject json = JObject.Parse(response);

            return json["response"]
                .OfType<JObject>()
                .Select(ParseLeagueFromJson)
                .Where(league => league != null)
                .ToList();
        }

        private League ParseLeagueFromJson(JObject leagueJson)
        {
            if (IsLeagueActive(leagueJson))
            {
                return new League
                {
                    Id = leagueJson.Value<int>("id"),
                    Name = leagueJson.Value<string>("name"),
                    LogoUrl = leagueJson.Value<string>("logo"),
                    CountryName = leagueJson["country"].Value<string>("name"),
                    CountryCode = leagueJson["country"].Value<string>("code"),
                    CountryFlagUrl = leagueJson["country"].Value<string>("flag")
                };
            }

            return null;
        }

        private bool IsLeagueActive(JObject leagueJson)
        {
            JArray seasonTokens = JArray.Parse(leagueJson["seasons"].ToString());

            if (seasonTokens.Count < 1)
                return false;

            return seasonTokens.Any(season => season.Value<DateTime>("end") >= DateTime.Now);
        }
    }
}
