using BetBriliant_Domain.Entities;
using BetBriliant_Domain.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BetBriliant_CORE.Pages.HomeScreen
{
    public class HomeScreenViewModel : INotifyPropertyChanged
    {
        private SportService _sportService;

        public ObservableCollection<SportEntity> _sports;
        public ObservableCollection<SportEntity> Sports
        {
            get { return _sports; }
            set
            {
                _sports = value;
                OnPropertyChanged(nameof(Sports));
            }
        }

        public HomeScreenViewModel()
        {
            _sportService = new SportService();
            InitializeSports();
        }

        private async void InitializeSports()
        {
            var sports = await _sportService.GetSportIconsAsync();
            Sports = new ObservableCollection<SportEntity>(sports);
            OnPropertyChanged(nameof(Sports));
        }


        private ObservableCollection<EventEntity> _events;
        public ObservableCollection<EventEntity> Events
        {
            get { return _events; }
            set
            {
                _events = value;
                OnPropertyChanged(nameof(Events));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
