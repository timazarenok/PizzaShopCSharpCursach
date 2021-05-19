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

namespace PizzaShop
{
    /// <summary>
    /// Логика взаимодействия для OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        public OrdersWindow()
        {
            InitializeComponent();
            SetOrders();
        }
        private void SetOrders()
        {
            List<Order> orders = new List<Order>();
            DataTable dt = SqlDB.Select("select * from Orders");
            foreach (DataRow dr in dt.Rows)
            {
                orders.Add(new Order()
                {
                    ID = dr["id"].ToString(),
                    Date = dr["date"].ToString()
                });
            }
            Orders.ItemsSource = orders;
        }
        private void SetOrderProducts(string IDOrder)
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
            Products.ItemsSource = products;
        }
        private void Orders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Orders.SelectedItem = sender;
            Order order = (Order)Orders.SelectedItem;
            SetOrderProducts(order.ID);
        }
    }
}
