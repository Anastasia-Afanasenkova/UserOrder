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
    public partial class Login : Page
    {
        public MainWindow mWindow;
        public AuthoDataDataContext Autho = new AuthoDataDataContext();

        public Login(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mWindow = mainWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mWindow.OpenPage(MainWindow.Pages.Register);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != null)
            {
                var Result = Autho.User.Where(u => u.Login == textBox1.Text && u.Password == textBox2.Password);
                if (Result.Count() > 0)
                    switch (Result.FirstOrDefault().IdRole)
                    {
                        case 1:
                            mWindow.OpenPage(MainWindow.Pages.Admin);
                            break;
                        case 2:
                            mWindow.OpenPage(MainWindow.Pages.User);
                            break;
                        case 3:
                            mWindow.OpenPage(MainWindow.Pages.Manager);
                            break;
                        case 4:
                            mWindow.OpenPage(MainWindow.Pages.Worker);
                            break;
                    }
                else
                    MessageBox.Show("Такого пользователя не существует", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
