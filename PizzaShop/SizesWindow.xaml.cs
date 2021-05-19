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
    /// Логика взаимодействия для SizesWindow.xaml
    /// </summary>
    public partial class SizesWindow : Window
    {
        public SizesWindow()
        {
            InitializeComponent();
            SetSizes();
        }
        public void SetSizes()
        {
            List<Size> sizes = new List<Size>();
            DataTable dt = SqlDB.Select("select * from Sizes");
            foreach (DataRow dr in dt.Rows)
            {
                sizes.Add(new Size()
                {
                    ID = dr["id"].ToString(),
                    Name = dr["name"].ToString(),
                    Value = dr["value"].ToString()
                });
            }
            Sizes.ItemsSource = sizes;
        }

        private void Gramms_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (SqlDB.Command($"insert into Sizes values ('{Name.Text}', {Gramms.Text})"))
            {
                SetSizes();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(SqlDB.Command($"delete from Sizes where id = {ID.Text}"))
            {
                SetSizes();
            }
        }
    }
}
