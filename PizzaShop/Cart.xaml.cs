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
using System.Windows.Shapes;

namespace PizzaShop
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        public Cart()
        {
            InitializeComponent();
            SetCart();
        }
        public int IDOrder { get; set; }
        private void SetCart()
        {
            IDOrder = SqlDB.GetId($"select top 1 * from Orders order by id desc");
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
            CartList.ItemsSource = products;
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
        private void End_Click(object sender, RoutedEventArgs e)
        {
            if(SqlDB.Command($"Update Orders set [name]='{Name.Text}', [telephone]='{Telephone.Text}' where Orders.id={IDOrder}"))
            {
                if (SqlDB.Command($"insert into Payment values({IDOrder}, '{Address.Text}', {((bool)IsCard.IsChecked ? 1 : 0)}, '{CardNumber.Text}')"))
                {
                    MessageBox.Show("Заказ оформлен");
                }
            }
        }

        private void Telephone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,-,+]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CardNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CardNumber.IsReadOnly = !(bool)IsCard.IsChecked;
            Regex regex = new Regex("[^0-9,+]+"); 
            e.Handled = regex.IsMatch(e.Text);                                                                                                                                                 
        }
    }
}