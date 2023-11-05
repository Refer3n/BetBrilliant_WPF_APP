using System.Windows.Media;

namespace BetBriliant_Domain.Entities
{
    public class LeagueEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ImageSource Logo { get; set; }
        public string CountryName { get; set; }
        public ImageSource CountryFlag { get; set; }
    }
}
