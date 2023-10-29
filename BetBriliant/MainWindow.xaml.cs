using BetBriliant_CORE.Navigator;
using BetBriliant_CORE.Pages.HomeScreen;
using System.Windows;
using System.Windows.Controls;

namespace BetBriliant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigatorObject.NavigateRequested += NavigateRequestedHandler;
            NavigatorObject.Switch(new HomeScreen());
        }

        private void NavigateRequestedHandler(object sender, UserControl page)
        {
            this.Content = page;
        }

        //public void Navigate(UserControl page)
        //{
        //    this.Content = page;
        //}

        //public void Navigate(UserControl page, object state)
        //{
        //    this.Content = page;

        //    INavigator? s = page as INavigator;

        //    if (s != null)
        //        s.UtilizeState(state);
        //    else
        //        throw new ArgumentException("");

        //}
    }
}
