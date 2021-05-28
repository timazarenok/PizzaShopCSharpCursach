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
    /// Логика взаимодействия для DrinkSizesWindow.xaml
    /// </summary>
    public partial class TypesWindow : Window
    {
        public TypesWindow()
        {
            InitializeComponent();
            SetTypes();
        }
        public void SetTypes()
        {
            List<Types> types = new List<Types>();
            DataTable dt = SqlDB.Select("select * from Types");
            foreach (DataRow dr in dt.Rows)
            {
                types.Add(new Types()
                {
                    ID = dr["id"].ToString(),
                    Name = dr["name"].ToString()
                });
            }
            Types.ItemsSource = types;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (SqlDB.Command($"insert into Types values ('{Name.Text}')"))
            {
                SetTypes();
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (SqlDB.Command($"delete from Types where id = {ID.Text}"))
            {
                SetTypes();
            }
        }

        private void ID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
