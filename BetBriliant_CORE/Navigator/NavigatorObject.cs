using System.Windows.Controls;

namespace BetBriliant_CORE.Navigator
{
    public class NavigatorObject
    {
        public delegate void NavigateHandler(object sender, UserControl page);
        public static event NavigateHandler NavigateRequested;

        public static void Switch(UserControl page)
        {
            NavigateRequested?.Invoke(null, page);
        }

        public static void Switch(UserControl page, object state)
        {
            NavigateRequested?.Invoke(null, page);
        }
    }

}
