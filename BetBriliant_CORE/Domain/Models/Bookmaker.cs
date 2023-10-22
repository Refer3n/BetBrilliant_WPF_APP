using System.Collections.Generic;

namespace BetBriliant_CORE.Domain.Models
{
    public class Bookmaker
    {
        public string Key { get; set; }

        public string? Title { get; set; }

        public List<Market>? Markets { get; set; }
    }
}
