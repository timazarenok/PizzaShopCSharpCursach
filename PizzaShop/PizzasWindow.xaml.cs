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
    /// Логика взаимодействия для PizzasWindow.xaml
    /// </summary>
    public partial class PizzasWindow : Window
    {
        public PizzasWindow()
        {
            InitializeComponent();
            SetSizes();
            SetTypes();
            SetPizzas();
        }
        public void SetPizzas()
        {
            List<Drink> sizes = new List<Drink>();
            DataTable dt = SqlDB.Select("" +
                "select Products.id, Products.[name], price, Sizes.[name] as size, Types.[name] as type from Products " +
                "join Sizes on Sizes.id = Products.size " +
                "join Types on Types.id = Products.type ");
            foreach (DataRow dr in dt.Rows)
            {
                sizes.Add(new Drink()
                {
                    ID = dr["id"].ToString(),
                    Name = dr["name"].ToString(),
                    Price = dr["price"].ToString(),
                    Size = dr["size"].ToString(),
                    Type = dr["type"].ToString()
                });
            }
            Sizes.ItemsSource = sizes;
        }
        public void SetSizes()
        {
            List<string> sizes = new List<string>();
            DataTable dt = SqlDB.Select("select * from Sizes");
            foreach (DataRow dr in dt.Rows)
            {
                sizes.Add(dr["name"].ToString());
            }
            Size.ItemsSource = sizes;
        }
        public void SetTypes()
        {
            List<string> types = new List<string>();
            DataTable dt = SqlDB.Select("select * from Types");
            foreach (DataRow dr in dt.Rows)
            {
                types.Add(dr["name"].ToString());
            }
            Type.ItemsSource = types;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int id_size = SqlDB.GetId($"select * from Sizes where [name] = '{Size.SelectedItem}'");
            int id_type = SqlDB.GetId($"select * from Types where [name] = '{Type.SelectedItem}'");
            if (SqlDB.Command($"insert into Products values ('{Name.Text}', {Price.Text}, {id_type}, {id_size})"))
            {
                SetPizzas();
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (SqlDB.Command($"delete from Products where id = {ID.Text}"))
            {
                SetPizzas();
            }
        }

        private void Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
