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
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
        
        UsersTableAdapter usersTableAdapter = new UsersTableAdapter();
        RolesTableAdapter rolesTableAdapter = new RolesTableAdapter();

        public User()
        {
            InitializeComponent();
            UserDgr.ItemsSource = usersTableAdapter.GetData();
            RoleCbx.ItemsSource = rolesTableAdapter.GetData();
            RoleCbx.DisplayMemberPath = "id_role";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            usersTableAdapter.Insert_Users(LoginTbx.Text, PassTbx.Text, int.Parse(SummTbx.Text), int.Parse(RoleCbx.Text));
            UserDgr.ItemsSource = usersTableAdapter.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (UserDgr.SelectedItem as DataRowView).Row[0];
            usersTableAdapter.UpdateUsers(LoginTbx.Text, PassTbx.Text, int.Parse(SummTbx.Text), int.Parse(RoleCbx.Text), Convert.ToInt32(id));
            UserDgr.ItemsSource = usersTableAdapter.GetData();
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object id = (UserDgr.SelectedItem as DataRowView).Row[0];
            usersTableAdapter.Delete_Users(Convert.ToInt32(id));
            UserDgr.ItemsSource = usersTableAdapter.GetData();

        }
    }
}
