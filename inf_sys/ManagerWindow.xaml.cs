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
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        User_SecurityTableAdapter tableAdapter = new User_SecurityTableAdapter();
        public ManagerWindow()
        {
            InitializeComponent();
            Grid.ItemsSource = tableAdapter.GetData();
        }
    }
}
