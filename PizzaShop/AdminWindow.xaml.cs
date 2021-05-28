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

namespace PizzaShop
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Sizes_Click(object sender, RoutedEventArgs e)
        {
            SizesWindow window = new SizesWindow();
            window.Show();
        }

        private void Types_Click(object sender, RoutedEventArgs e)
        {
            TypesWindow window = new TypesWindow();
            window.Show();
        }

        private void Pizza_Click(object sender, RoutedEventArgs e)
        {
            PizzasWindow window = new PizzasWindow();
            window.Show();
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow window = new OrdersWindow();
            window.Show();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Login window = new Login();
            window.Show();
            Close();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow window = new InfoWindow();
            window.Show();
        }
    }
}
