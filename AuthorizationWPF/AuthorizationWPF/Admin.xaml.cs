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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public MainWindow mWindow;
        public AuthoDataDataContext Autho = new AuthoDataDataContext();
        public Admin(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mWindow = mainWindow;
            dataGrid1.ItemsSource = Autho.User;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            dataGrid1.ItemsSource = Autho.User;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            mWindow.OpenPage(MainWindow.Pages.Login);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mWindow.OpenPage(MainWindow.Pages.Login);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Register register = new Register(mWindow);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                User selectedUser = (User)dataGrid1.SelectedItem;
                User findUser = Autho.User.First(u => u.Login == selectedUser.Login);
                AddUser editUser = new AddUser("Изменение пользователя");

                editUser.texBox1.Text = findUser.Login;
                editUser.texBox4.Text = findUser.Name;
                editUser.textBox2.Password = findUser.Password;
                editUser.comboBox1.Text = findUser.UserRole.ToString();
                if (editUser.ShowDialog() != false)
                {
                    selectedUser.Name = editUser.texBox4.Text;
                    selectedUser.Login = editUser.texBox1.Text;
                    selectedUser.Password = editUser.textBox2.Password;
                    selectedUser.IdRole = editUser.comboBox1.SelectedIndex + 1;
                    Autho.SubmitChanges();
                    dataGrid1.Items.Refresh();
                    MessageBox.Show("Информация по пользователю успешно изменена");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                User deleteUser = (User)dataGrid1.SelectedItem;
                Autho.User.DeleteOnSubmit(deleteUser);
                Autho.SubmitChanges();
                MessageBox.Show("Информация по пользователю успешно удалена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGrid1.Items.Refresh();
        }
    }
}
