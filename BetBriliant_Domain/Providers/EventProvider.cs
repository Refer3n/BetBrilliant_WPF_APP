namespace BetBriliant_Domain.Providers
{
    public class EventProvider
    {
        //private readonly IApi engine;
        //public EventProvider()
        //{
        //    engine = new BetBriliantApiEngine();
        //}

        //public async Task<List<Event>> GetEventsAsync(string sport)
        //{
        //    string json = await engine.GetOddsAsync(sport);
        //    JArray tokens = JArray.Parse(json);

        //    if (tokens == null)
        //        return null;

        //    List<Event> result = tokens.Select(GetEventFromJson).ToList();

        //    return result;
        //}

        //private Event GetEventFromJson(JToken token)
        //{
        //    return new Event
        //    {
        //        Id = token.Value<string>("id"),
        //        SportKey = token.Value<string>("sport_key"),
        //        CommenceTime = token.Value<DateTime>("commence_time"),
        //        HomeTeam = token.Value<string>("home_team"),
        //        AwayTeam = token.Value<string>("away_team"),
        //        Bookmakers = GetBookmakersFromJson(token["bookmakers"] as JArray)
        //    };
        //}

        //private List<Bookmaker> GetBookmakersFromJson(JArray tokens)
        //{
        //    return tokens.Select(GetBookmakerFromJson).ToList();
        //}

        //private Bookmaker GetBookmakerFromJson(JToken token)
        //{
        //    return new Bookmaker
        //    {
        //        Key = token.Value<string>("key"),
        //        Title = token.Value<string>("title"),
        //        Markets = GetMarketsFromJson(token["markets"] as JArray)
        //    };
        //}

        //private List<Market> GetMarketsFromJson(JArray tokens)
        //{
        //    return tokens.Select(GetMarketFromJson).ToList();
        //}

        //private Market GetMarketFromJson(JToken token)
        //{
        //    return new Market
        //    {
        //        Key = token.Value<string>("key"),
        //        Outcomes = GetOutcomesFromJson(token["outcomes"] as JArray)
        //    };
        //}

        //private List<Outcome> GetOutcomesFromJson(JArray tokens)
        //{
        //    return tokens.Select(GetOutcomeFromJson).ToList();
        //}

        //private Outcome GetOutcomeFromJson(JToken token)
        //{
        //    return new Outcome
        //    {
        //        Name = token.Value<string>("name"),
        //        Price = token.Value<decimal>("price")
        //    };
        //}

    }
}
