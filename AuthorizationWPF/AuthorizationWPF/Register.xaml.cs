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
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public MainWindow mWindow;
        public AuthoDataDataContext Autho = new AuthoDataDataContext();

        public Register(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mWindow = mainWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mWindow.OpenPage(MainWindow.Pages.Login);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (texBox1.Text != null && textBox2.Password != null && textBox3.Password != null)
            {
                if (textBox2.Password == textBox3.Password)
                {
                    User NewUser = new User
                    {
                        Login = texBox1.Text,
                        Password = textBox2.Password,
                        IdRole = comboBox1.SelectedIndex + 2,
                        Name = texBox4.Text
                    };
                    Autho.User.InsertOnSubmit(NewUser);
                    try
                    {
                        Autho.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                    }
                } 
            }
        }
    }
}
