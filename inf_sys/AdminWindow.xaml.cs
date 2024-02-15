using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace inf_sys
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Open_Role_Window(object sender, RoutedEventArgs e)
        {
            RoleWindow roleWindow = new RoleWindow();
            roleWindow.Show();
        }

        private void Open_Operation_Window(object sender, RoutedEventArgs e)
        {
            OpirationWindow opirationWindow = new OpirationWindow();
            opirationWindow.Show();
        }

        private void Open_Users_Window(object sender, RoutedEventArgs e)
        {
            User userWindow = new User();
            userWindow.Show();
        }

        private void Open_ChangePrice_Window(object sender, RoutedEventArgs e)
        {
            ChangePriceWindow changePriceWindow = new ChangePriceWindow();
            changePriceWindow.Show();
        }

        private void Open_TradeSec_Window(object sender, RoutedEventArgs e)
        {
            TradeWindow tradeWindow = new TradeWindow();
            tradeWindow.Show();
        }
        private void Open_Market_Window(object sender, RoutedEventArgs e)
        {
            MarketWindow marketWindow = new MarketWindow();
            marketWindow.Show();
        }


        private void Open_PaperUser_Window(object sender, RoutedEventArgs e)
        {

            PaperUser paperUser = new PaperUser();
            paperUser.Show();


        }


    }
}
