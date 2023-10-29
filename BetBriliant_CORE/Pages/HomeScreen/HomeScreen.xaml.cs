using System.Windows.Controls;

namespace BetBriliant_CORE.Pages.HomeScreen
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : UserControl
    {
        public HomeScreen()
        {
            InitializeComponent();
            this.DataContext = new HomeScreenViewModel();
        }
    }
}
