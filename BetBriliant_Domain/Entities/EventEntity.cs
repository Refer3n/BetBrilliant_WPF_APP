using System;
using System.Collections.Generic;

namespace BetBriliant_Domain.Entities
{
    public class EventEntity
    {
        public string Id { get; set; }
        public string SportKey { get; set; }
        public DateTime CommenceTime { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public List<BookmakerEntity> Bookmakers { get; set; }
    }
}
