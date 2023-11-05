using BetBriliant_DATA.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BetBriliant_Domain.Providers.SportProviders
{
    public interface ISportProvider
    {
        Task<List<League>> GetSportLeaguesAsync();
    }
}
