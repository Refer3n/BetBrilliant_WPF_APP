using BetBriliant_Domain.Providers.SportProviders;
using BetBriliant_Enum;
using System;


namespace BetBriliant_Domain.Factories
{
    public class SportProviderFactory
    {
        public ISportProvider CreateSportProvider(SportType sportType)
        {
            switch (sportType)
            {
                case SportType.Football:
                    return new FootballSportProvider();
                case SportType.Basketball:
                    return new BasketballSportProvider();
                case SportType.Hockey:
                    return new HockeySportProvider();
                case SportType.Baseball:
                    return new BaseballSportProvider();
                case SportType.Rugby:
                    return new RugbySportProvider();
                default:
                    throw new NotSupportedException("Unsupported sport type");
            }
        }
    }
}
