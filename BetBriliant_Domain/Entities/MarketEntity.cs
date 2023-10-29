using System.Collections.Generic;

namespace BetBriliant_Domain.Entities
{
    public class MarketEntity
    {
        public string Key { get; set; }
        public List<OutcomeEntity> Outcomes { get; set; }
    }
}
