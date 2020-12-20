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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AuthorizationWPF
{
    /// <summary>
    /// Логика взаимодействия для UserForm.xaml
    /// </summary>
    public partial class UserForm : Page
    {
        public MainWindow mWindow;
        public AuthoDataDataContext Autho = new AuthoDataDataContext();
        private int tableIndex;
        public UserForm(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mWindow = mainWindow;
            dataGrid1.ItemsSource = Autho.Product;
            tableIndex = 2;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            dataGrid1.ItemsSource = Autho.Furniture;
            tableIndex = 0;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            dataGrid1.ItemsSource = Autho.Textile;
            tableIndex = 1;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            dataGrid1.ItemsSource = Autho.Product;
            tableIndex = 2;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            mWindow.OpenPage(MainWindow.Pages.Login);
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            switch (tableIndex)
            {
                case 0:
                    dataGrid1.ItemsSource = Autho.Furniture;
                    break;
                case 1:
                    dataGrid1.ItemsSource = Autho.Textile;
                    break;
                case 2:
                    dataGrid1.ItemsSource = Autho.Product;
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mWindow.OpenPage(MainWindow.Pages.Login);
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            UserOrder userOrder = new UserOrder();
            userOrder.ShowDialog();
        }
    }
}
