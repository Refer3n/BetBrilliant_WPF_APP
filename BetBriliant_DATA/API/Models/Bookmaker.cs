using System.Collections.Generic;

namespace BetBriliant_DATA.API.Models
{
    public class Bookmaker
    {
        public string Key { get; set; }

        public string? Title { get; set; }

        public List<Market>? Markets { get; set; }
    }
}
