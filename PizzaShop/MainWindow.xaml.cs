using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetProducts();
            CreateOrder();
        }
        public int IDOrder { get; set; }
        public string Login { get; set; }
        public List<Drink> products = new List<Drink>();
        public void CreateOrder()
        {
            if(SqlDB.Command($"insert into Orders values({SqlDB.UserID}, null, null, (select getdate()))"))
            {
                IDOrder = SqlDB.GetId($"select top 1 * from Orders order by id desc");
            }
        }
        public void SetProducts()
        {
            products = new List<Drink>();
            DataTable dt = SqlDB.Select("" +
                "select Products.id, Products.[name], price, Sizes.[name] as size, Types.[name] as type from Products " +
                "join Sizes on Sizes.id = Products.size " +
                "join Types on Types.id = Products.type ");
            foreach (DataRow dr in dt.Rows)
            {
                products.Add(new Drink()
                {
                    ID = dr["id"].ToString(),
                    Name = dr["name"].ToString(),
                    Price = dr["price"].ToString(),
                    Size = dr["size"].ToString(),
                    Type = dr["type"].ToString()
                });
            }
            Products.ItemsSource = products;
        }
        

        private void Products_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Products.SelectedItem = sender;
            Drink product = (Drink)Products.SelectedItem;
            if(SqlDB.Command($"insert into Order_Products values ({IDOrder}, {product.ID})"))
            {
                
            }
        }

        private void Deserts_Click(object sender, RoutedEventArgs e)
        {
            List<Drink> deserts = products.FindAll(el => el.Type == "Десерт");
            Products.ItemsSource = deserts;
        }

        private void Pizza_Click(object sender, RoutedEventArgs e)
        {
            List<Drink> pizzas = products.FindAll(el => el.Type == "Пицца");
            Products.ItemsSource = pizzas;
        }

        private void Souses_Click(object sender, RoutedEventArgs e)
        {
            List<Drink> souses = products.FindAll(el => el.Type == "Соус");
            Products.ItemsSource = souses;
        }

        private void Drink_Click(object sender, RoutedEventArgs e)
        {
            List<Drink> drinks = products.FindAll(el => el.Type == "Напиток");
            Products.ItemsSource = drinks;
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            Cart window = new Cart();
            window.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if(SqlDB.Command($"delete from Orders where Orders.id={IDOrder}"))
            {
                Login window = new Login();
                window.Show();
                Close();
            } 
        }
    }
}
