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
    /// Логика взаимодействия для ChangePriceWindow.xaml
    /// </summary>
    public partial class ChangePriceWindow : Window
    {
        Security_deltaTableAdapter tableAdapter = new Security_deltaTableAdapter();
        SecuritysTableAdapter tableAdapter2 = new SecuritysTableAdapter();
        public ChangePriceWindow()
        {
            InitializeComponent();
            Grid.ItemsSource = tableAdapter.GetData();
            SecCbx.ItemsSource = tableAdapter2.GetData();
            SecCbx.DisplayMemberPath = "id_security";
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            tableAdapter.Insert_SecurityDelta( int.Parse(SecCbx.Text), float.Parse(DeltaTbx.Text), DateTime.Parse(DateTbx.Text));
            Grid.ItemsSource = tableAdapter.GetData();
        }
        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            object id = (Grid.SelectedItem as DataRowView).Row[0];
            tableAdapter.Delete_SecurityDelta(Convert.ToInt32(id));
            Grid.ItemsSource = tableAdapter.GetData();
        }
        private void Update_Button(object sender, RoutedEventArgs e)
        {
            object id = (Grid.SelectedItem as DataRowView).Row[0];
            tableAdapter.Update_SecurityDelta(int.Parse(SecCbx.Text), float.Parse(DeltaTbx.Text), DateTime.Parse(DateTbx.Text), Convert.ToInt32(id));
            Grid.ItemsSource = tableAdapter.GetData();
        }
    }
}
