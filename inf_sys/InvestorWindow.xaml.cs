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
    /// Логика взаимодействия для InvestorWindow.xaml
    /// </summary>
    public partial class InvestorWindow : Window
    {
        User_SecurityTableAdapter tableAdapter = new User_SecurityTableAdapter();
        SecuritysTableAdapter securitysTableAdapter = new SecuritysTableAdapter();
        UsersTableAdapter usersTableAdapter = new UsersTableAdapter();
        operationsTableAdapter operationsTableAdapter = new operationsTableAdapter();
        public InvestorWindow()
        {
            InitializeComponent();
            Grid.ItemsSource = tableAdapter.GetData();
            Cbx.ItemsSource = securitysTableAdapter.GetData();
            Cbx.DisplayMemberPath = "id_security";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BuyWindow buy = new BuyWindow();
            buy.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int amountt = 0;
            int iduser = int.Parse(Txb.Text);
            var allmoney = usersTableAdapter.GetData().Rows;

            for (int i = 0; i < allmoney.Count; i++)
            {
                if ((int)allmoney[i][0] == iduser)
                {
                    amountt = (int)allmoney[i][3];
                }
            }
            int secmoney = 0;
            int idsec = int.Parse(Cbx.Text);
            var seccost = securitysTableAdapter.GetData().Rows;

            for (int i = 0; i < seccost.Count; i++)
            {
                if ((int)seccost[i][0] == idsec)
                {
                    secmoney = (int)seccost[i][2];
                }
            }
            int count = amountt + secmoney;

            object id = (Grid.SelectedItem as DataRowView).Row[0];
            usersTableAdapter.Update_Money(count, iduser);
            tableAdapter.DeleteQuery(iduser);
            operationsTableAdapter.InsertOperation(true, DateTime.Now, int.Parse(Cbx.Text));
            Grid.ItemsSource = tableAdapter.GetData();
        }
    }
}
