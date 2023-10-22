using System.Collections.Generic;

namespace BetBriliant_CORE.Domain.Models
{
    public class Market
    {
        public string Key { get; set; }
        public List<Outcome>? Outcomes { get; set; }
    }
}
