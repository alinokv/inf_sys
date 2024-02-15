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
    /// Логика взаимодействия для RoleWindow.xaml
    /// </summary>
    public partial class RoleWindow : Window
    {
        RolesTableAdapter rolesTableAdapter = new RolesTableAdapter();
        public RoleWindow()
        {
            InitializeComponent();
            Grid.ItemsSource = rolesTableAdapter.GetData();
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            rolesTableAdapter.Insert_Role(NameTbx.Text);
            Grid.ItemsSource = rolesTableAdapter.GetData();
        }
        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            object id = (Grid.SelectedItem as DataRowView).Row[0];
            rolesTableAdapter.Delete_Role(Convert.ToInt32(id));
            Grid.ItemsSource = rolesTableAdapter.GetData();
        }
        private void Update_Button(object sender, RoutedEventArgs e)
        {
            object id = (Grid.SelectedItem as DataRowView).Row[0];
            rolesTableAdapter.Update_Role(NameTbx.Text, Convert.ToInt32(id));
            Grid.ItemsSource = rolesTableAdapter.GetData();
        }

    }
}
