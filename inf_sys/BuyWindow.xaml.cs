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
    /// Логика взаимодействия для BuyWindow.xaml
    /// </summary>
    public partial class BuyWindow : Window
    {
        SecuritysTableAdapter securitysTableAdapter = new SecuritysTableAdapter();
        UsersTableAdapter usersTableAdapter = new UsersTableAdapter();
        User_SecurityTableAdapter User_SecurityTableAdapter = new User_SecurityTableAdapter();
        operationsTableAdapter operationsTableAdapter = new operationsTableAdapter();

        public BuyWindow()
        {
            InitializeComponent();
            Grid.ItemsSource = securitysTableAdapter.GetData();
            UserId.ItemsSource = usersTableAdapter.GetData();
            UserId.DisplayMemberPath = "id_user";
            SecId.ItemsSource = securitysTableAdapter.GetData();
            SecId.DisplayMemberPath = "id_security";
            
        }
        private void AddUserSecurity_Click(object sender, RoutedEventArgs e)
        {
            
            int amountt = 0;
            int iduser = int.Parse(UserId.Text);
            var allmoney = usersTableAdapter.GetData().Rows;
            
            for (int i = 0; i < allmoney.Count; i++)
            {
                if ((int)allmoney[i][0] == iduser)
                {
                    amountt = (int)allmoney[i][3];
                }
            }
            int secmoney = 0;
            int idsec = int.Parse(SecId.Text);
            var seccost = securitysTableAdapter.GetData().Rows;

            for (int i = 0; i < seccost.Count; i++)
            {
                if ((int)seccost[i][0] == idsec)
                {
                    secmoney = (int)seccost[i][2];
                }
            }
            int count = amountt - secmoney;

            usersTableAdapter.Update_Money(count, iduser);
            User_SecurityTableAdapter.Insert_User_Security(int.Parse(UserId.Text), int.Parse(SecId.Text));
            operationsTableAdapter.InsertOperation(true, DateTime.Now, int.Parse(SecId.Text));

            
        }
    }   
}
