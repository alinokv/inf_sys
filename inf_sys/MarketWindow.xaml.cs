using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Логика взаимодействия для MarketWindow.xaml
    /// </summary>
    public partial class MarketWindow : Window
    {
        public MarketWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                int number = Convert.ToInt32(textBox.Text);
                int result = 100 - (100 / (1 + number));
                label.Content = result.ToString();
            }
        }

    }
}
