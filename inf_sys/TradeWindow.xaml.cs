using System;
using System.Collections.Generic;
using System.Data;
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
using inf_sys.inf_sysDataSetTableAdapters;

namespace inf_sys
{
    /// <summary>
    /// Логика взаимодействия для TradeWindow.xaml
    /// </summary>
    public partial class TradeWindow : Window
    {
        SecuritysTableAdapter securitysTableAdapter = new SecuritysTableAdapter();

        public TradeWindow()
        {
            InitializeComponent();
            Grid.ItemsSource = securitysTableAdapter.GetData();
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            securitysTableAdapter.Insert_Securitys(NameTbx.Text, int.Parse(PriceTbx.Text));
            Grid.ItemsSource = securitysTableAdapter.GetData();
        }
        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            object id = (Grid.SelectedItem as DataRowView).Row[0];
            securitysTableAdapter.DeleteQuery(Convert.ToInt32(id));
            Grid.ItemsSource = securitysTableAdapter.GetData();
        }
        private void Update_Button(object sender, RoutedEventArgs e)
        {
            object id = (Grid.SelectedItem as DataRowView).Row[0];
            securitysTableAdapter.Update_Securitys(NameTbx.Text, int.Parse(PriceTbx.Text), Convert.ToInt32(id));
            Grid.ItemsSource = securitysTableAdapter.GetData();
        }

    }
}
