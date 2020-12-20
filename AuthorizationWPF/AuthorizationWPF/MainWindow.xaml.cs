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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OpenPage(Pages.Login);
        }

        public enum Pages
        {
            Login,
            Register,
            Admin,
            Manager,
            User,
            Worker
        }

        public void OpenPage(Pages page)
        {
            switch (page)
            {
                case Pages.Login:
                    frame1.Navigate(new Login(this));
                    break;
                case Pages.Register:
                    frame1.Navigate(new Register(this));
                    break;
                case Pages.Admin:
                    frame1.Navigate(new Admin(this));
                    break;
                case Pages.Manager:
                    frame1.Navigate(new Manager(this));
                    break;
                case Pages.User:
                    frame1.Navigate(new UserForm(this));
                    break;
            }
        }
    }
}
