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
using inf_sys.inf_sysDataSetTableAdapters;

namespace inf_sys
{
    /// <summary>
    /// Логика взаимодействия для Autorisetion.xaml
    /// </summary>
    public partial class Autorisetion : Window
    {
        UsersTableAdapter usersTableAdapter = new UsersTableAdapter();

        public Autorisetion()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var alllogins = usersTableAdapter.GetData().Rows;
            for (int i = 0; i < alllogins.Count; i++)
            {
                if (alllogins[i][1].ToString() == LoginTbx.Text &&
                    alllogins[i][2].ToString() == PassTbx.Text)
                {
                    int roleID = (int)alllogins[i][4];

                    switch (roleID)
                    {
                        case 1:
                            //admin
                            AdminWindow admin = new AdminWindow();
                            admin.Show();
                            this.Close();
                            break;
                        case 2:
                            //treder
                            TradeWindow trade = new TradeWindow();
                            trade.Show();
                            this.Close();
                            break;
                        case 3:
                            //invest
                            InvestorWindow investor = new InvestorWindow();
                            investor.Show();
                            this.Close();
                            break;
                        case 4:
                            //manager
                            ManagerWindow manager = new ManagerWindow();
                            manager.Show();
                            this.Close();
                            break;
                    }
                }
            }
        }
    }
}
