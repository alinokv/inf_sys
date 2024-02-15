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
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        UsersTableAdapter usersTableAdapter = new UsersTableAdapter();

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LoginTbx.Text) && LoginTbx.Text.Length > 5 &&
                !string.IsNullOrEmpty(PassTbx.Text) && PassTbx.Text.Length > 5 &&
                !string.IsNullOrEmpty(ScetTbx.Text))
            {
                usersTableAdapter.Insert_Users(LoginTbx.Text, PassTbx.Text, int.Parse(ScetTbx.Text), 3);
                MainWindow mainwindown = new MainWindow();
                mainwindown.Show();
                this.Close();
            }

        }
    }
}
