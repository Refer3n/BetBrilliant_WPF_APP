using System.Collections.Generic;

namespace BetBriliant_Domain.Entities
{
    public class BookmakerEntity
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public List<MarketEntity> Markets { get; set; }
    }
}
