using System;
using System.Collections.Generic;

namespace BetBriliant_DATA.API.Models
{
    public class Event
    {
        public string Id { get; set; }

        public string? SportKey { get; set; }

        public DateTime? CommenceTime { get; set; }

        public string? HomeTeam { get; set; }

        public string? AwayTeam { get; set; }

        public List<Bookmaker>? Bookmakers { get; set; }
    }
}
