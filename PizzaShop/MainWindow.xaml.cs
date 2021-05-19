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
        public void CreateOrder()
        {
            if(SqlDB.Command($"insert into Orders values({SqlDB.UserID}, (select getdate()))"))
            {
                IDOrder = SqlDB.GetId($"select top 1 * from Orders order by id desc");
            }
        }
        public void SetProducts()
        {
            List<Drink> products = new List<Drink>();
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
        private void SetCart()
        {
            List<Drink> products = new List<Drink>();
            DataTable dt = SqlDB.Select("" +
                "select Order_Products.id, Products.[name], price, Sizes.[name] as size, Types.[name] as type from Order_Products " +
                "join Products on Products.id = Order_Products.product_id " +
                "join Sizes on Sizes.id = Products.size " +
                $"join Types on Types.id = Products.type where order_id={IDOrder}");
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
            Cart.ItemsSource = products;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (SqlDB.Command($"delete from Order_Products where id={ID.Text}"))
            {
                MessageBox.Show("Удален");
                SetCart();
            }
        }

        private void ID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Products_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Products.SelectedItem = sender;
            Drink product = (Drink)Products.SelectedItem;
            if(SqlDB.Command($"insert into Order_Products values ({IDOrder}, {product.ID})"))
            {
                SetCart();
            }
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            CreateOrder();
            SetCart();
        }
    }
}
