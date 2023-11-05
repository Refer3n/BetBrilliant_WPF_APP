using System.Threading.Tasks;

namespace BetBriliant_DATA.API
{
    public interface IApi
    {
        Task<string> GetLeaguesAsync();
    }
}
