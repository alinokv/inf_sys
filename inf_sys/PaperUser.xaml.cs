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
    /// Логика взаимодействия для PaperUser.xaml
    /// </summary>
    public partial class PaperUser : Window
    {
        SecuritysTableAdapter securitysTableAdapter = new SecuritysTableAdapter();
        UsersTableAdapter usersTableAdapter = new UsersTableAdapter();
        User_SecurityTableAdapter tableAdapter = new User_SecurityTableAdapter();
        public PaperUser()
        {
            InitializeComponent();
            Grid.ItemsSource = tableAdapter.GetData();
            NameCbx.ItemsSource = usersTableAdapter.GetData();
            PriceCbx.ItemsSource = securitysTableAdapter.GetData();
            NameCbx.DisplayMemberPath = "id_user";
            PriceCbx.DisplayMemberPath = "id_security";
            
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            tableAdapter.Insert_User_Security(int.Parse(NameCbx.Text), int.Parse(PriceCbx.Text));
            Grid.ItemsSource = tableAdapter.GetData();
        }
        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            object id = (Grid.SelectedItem as DataRowView).Row[0];
            tableAdapter.Delete_UserSecurity(Convert.ToInt32(id));
            Grid.ItemsSource = tableAdapter.GetData();
        }
        private void Update_Button(object sender, RoutedEventArgs e)
        {
            object id = (Grid.SelectedItem as DataRowView).Row[0];
            tableAdapter.Update_User_Security(int.Parse(NameCbx.Text), int.Parse(PriceCbx.Text), Convert.ToInt32(id));
            Grid.ItemsSource = tableAdapter.GetData();
        }


    }
}
