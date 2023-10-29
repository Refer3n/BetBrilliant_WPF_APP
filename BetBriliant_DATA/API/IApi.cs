using System.Threading.Tasks;

namespace BetBriliant_DATA.API
{
    public interface IApi
    {
        Task<string> GetOddsAsync(string sport, string markets = "h2h", string bookmakers = "fanduel,betmgm,williamhill,betvictor");
        Task<string> GetSportsAsync();
    }
}
