using System.Windows.Media;

namespace BetBriliant_DATA.API.Models
{
    public class League
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LogoUrl { get; set; }
        public string? CountryName { get; set; }
        public string? CountryCode { get; set; }
        public string? CountryFlagUrl { get; set; }
        public ImageSource Logo { get; set; }
        public ImageSource CountryFlag { get; set; }

    }
}
