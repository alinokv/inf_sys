using inf_sys.inf_sysDataSetTableAdapters;
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


namespace inf_sys
{
    /// <summary>
    /// Логика взаимодействия для OpirationWindow.xaml
    /// </summary>
    public partial class OpirationWindow : Window
    {
        operationsTableAdapter tableAdapter =   new operationsTableAdapter();
        SecuritysTableAdapter tableAdapter2 = new SecuritysTableAdapter();
        public OpirationWindow()
        {
            InitializeComponent();
            Grid.ItemsSource = tableAdapter.GetData();
            SecCbx.ItemsSource = tableAdapter2.GetData();
            SecCbx.DisplayMemberPath = "id_security";
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            tableAdapter.InsertOperation(bool.Parse(StatusTbx.Text), DateTime.Parse(DateTbx.Text),int.Parse(SecCbx.Text));
            Grid.ItemsSource = tableAdapter.GetData();
        }
        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            object id = (Grid.SelectedItem as DataRowView).Row[0];
            tableAdapter.Delete_Operation(Convert.ToInt32(id));
            Grid.ItemsSource = tableAdapter.GetData();
        }
        private void Update_Button(object sender, RoutedEventArgs e)
        {
            object id = (Grid.SelectedItem as DataRowView).Row[0];
            tableAdapter.Update_Operations(bool.Parse(StatusTbx.Text), DateTime.Parse(DateTbx.Text),int.Parse(SecCbx.Text), Convert.ToInt32(id));
            Grid.ItemsSource = tableAdapter.GetData();
        }
    }
}
