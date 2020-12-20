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

namespace AuthorizationWPF
{
    /// <summary>
    /// Логика взаимодействия для UserOrder.xaml
    /// </summary>
    public partial class UserOrder : Window
    {
        public AuthoDataDataContext Autho = new AuthoDataDataContext();
        public UserOrder()
        {
            InitializeComponent();
            d1.ItemsSource = Autho.Order;
            c1.ItemsSource = Autho.Goods.Select(g => g.Article);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            l1.Text = $"= {Autho.Goods.FirstOrDefault(g => g.Article == c1.Text).Price * Convert.ToInt32(t1.Text)}";
            Order order = new Order
            {
                Number = Convert.ToInt32(t1.Text),
                Date = DateTime.Now,
                IdStageOfExecution = 1,
                Customer = t2.Text,
                Cost = Autho.Goods.FirstOrDefault(g => g.Article == c1.Text).Price * Convert.ToInt32(t1.Text)
            };
            Autho.Order.InsertOnSubmit(order);
            Autho.SubmitChanges();
            d1.Items.Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Autho.Order.DeleteOnSubmit((Order)d1.SelectedItem);
            Autho.SubmitChanges();
        }
    }
}
