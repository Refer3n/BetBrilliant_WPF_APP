using AutoMapper;
using BetBriliant_DATA.API.Models;
using BetBriliant_Domain.Entities;
using BetBriliant_Domain.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBriliant_Domain.Services
{
    public class SportService
    {
        private readonly SportProvider _provider;
        private IMapper _mapper;

        private static List<SportEntity> sports = new List<SportEntity>();

        public SportService()
        {
            _provider = new SportProvider();
            CreateMapper();
        }

        public async Task<List<SportEntity>> GetSportIconsAsync()
        {
            if (sports.Count == 0)
            {
                await GetAllSportsAsync();
            }

            var uniqueSports = sports
                .GroupBy(sport => sport.Group)
                .Select(group => group.First())
                .ToList();

            return uniqueSports;
        }

        private async Task GetAllSportsAsync()
        {
            var newSports = await _provider.GetSportsAsync();

            var updatedSports = newSports
                .Select(sport =>
                {
                    var sportDto = _mapper.Map<SportEntity>(sport);
                    sportDto.Image = ImageProvider.GetImageByGroup(sport.Group);
                    return sportDto;
                })
                .Where(sport => sport.Image != null)
                .ToList();

            sports = updatedSports;
        }

        private void CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Sport, SportEntity>();
                cfg.CreateMap<SportEntity, Sport>();
            });

            _mapper = config.CreateMapper();
        }
    }
}
