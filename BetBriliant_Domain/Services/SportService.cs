using AutoMapper;
using BetBriliant_DATA.API.Models;
using BetBriliant_Domain.Entities;
using BetBriliant_Domain.Factories;
using BetBriliant_Domain.Providers;
using BetBriliant_Enum;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBriliant_Domain.Services
{
    public class SportService
    {
        private readonly SportProviderFactory _providerFactory;
        private IMapper _mapper;

        public SportService()
        {
            _providerFactory = new SportProviderFactory();
            CreateMapper();
        }

        public async Task<List<League>> GetLeaguesAsync(SportType sportType)
        {
            var provider = _providerFactory.CreateSportProvider(sportType);

            var leagues = await provider.GetSportLeaguesAsync();

            var imageLoadingTasks = leagues.Select(league => LoadImagesAsync(league));

            await Task.WhenAll(imageLoadingTasks);

            var result = _mapper.Map<List<LeagueEntity>>(leagues);

            return leagues.Take(10).ToList();
        }

        private async Task LoadImagesAsync(League league)
        {
            if (!string.IsNullOrEmpty(league.LogoUrl))
            {
                league.Logo = await ImageProvider.GetImageByUrlAsync(league.LogoUrl);
            }

            if (!string.IsNullOrEmpty(league.CountryCode))
            {
                league.CountryFlag = await ImageProvider.GetFlagByCodeAsync(league.CountryCode);
            }
        }

        private void CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<League, LeagueEntity>();
            });

            _mapper = config.CreateMapper();
        }
    }
}
