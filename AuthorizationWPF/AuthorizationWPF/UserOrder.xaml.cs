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
            d1.ItemsSource = Autho.Order.Where(o => o.User.Login == Login.userLogin);
            c1.ItemsSource = Autho.Product.Select(p => p.Article);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OrderedProduct orderedProduct = new OrderedProduct
            {
                IdProduct = Autho.Product.FirstOrDefault(p => p.Article == c1.Text).IdProduct,
                Qty = Convert.ToInt16(t1.Text)
            };
            Autho.OrderedProduct.InsertOnSubmit(orderedProduct);
            Autho.SubmitChanges();
            l1.Text = $"= {Autho.Product.FirstOrDefault(p => p.Article == c1.Text).Price * Convert.ToInt32(t1.Text)}";
            Order order = new Order
            {
                Number = Autho.OrderedProduct.FirstOrDefault(op => op.IdProduct == Autho.Product.FirstOrDefault(p => p.Article == c1.Text).IdProduct).OrderNumber,
                Date = DateTime.Now,
                IdStageOfExecution = 1,
                Customer = Login.userLogin,
                Cost = Autho.Product.FirstOrDefault(p => p.Article == c1.Text).Price * Convert.ToInt32(t1.Text)
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

        private void t1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (c1.Text != "")
            {
                try
                {
                    l1.Text = $"= {Autho.Product.FirstOrDefault(p => p.Article == c1.Text).Price * Convert.ToInt32(t1.Text)}";
                }
                catch
                {
                    MessageBox.Show("Введите числовое значение");
                }
            }
        }
    }
}
