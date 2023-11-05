using BetBriliant_CORE.Pages.HomeScreen.SportImage;
using BetBriliant_Domain.Providers;
using BetBriliant_Domain.Services;
using BetBriliant_Enum;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BetBriliant_CORE.Pages.HomeScreen
{
    public partial class HomeScreen : UserControl
    {
        private readonly SportService _sportService;
        private SportType _currentSport;

        public HomeScreen(SportService sportService)
        {
            InitializeComponent();
            _sportService = sportService;
            _currentSport = SportType.Rugby;
        }

        private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            FillSportListBox();
            await UpdateLeaguesAsync(_currentSport);
        }

        private async void sportListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sportListView.SelectedItem is SportImageObject selectedSport)
            {
                var selectedSportType = selectedSport.SportType;
                _currentSport = selectedSportType;
                await UpdateLeaguesAsync(_currentSport);
            }
        }

        private async Task UpdateLeaguesAsync(SportType sportType)
        {
            try
            {
                var leagues = await _sportService.GetLeaguesAsync(sportType);
                leagueListView.ItemsSource = leagues;
                test.ItemsSource = leagues;
            }
            catch (Exception ex)
            {

            }
        }

        private void FillSportListBox()
        {
            var sportTypes = new List<SportType>
            {
                SportType.Football, SportType.Basketball, SportType.Baseball, SportType.Hockey, SportType.Rugby
            };

            foreach (SportType sportType in sportTypes)
            {
                Image image = ImageProvider.GetImageBySportType(sportType);

                if (image != null)
                {
                    sportListView.Items.Add(new SportImageObject { Image = image.Source, SportType = sportType });
                }
            }
        }
    }
}
