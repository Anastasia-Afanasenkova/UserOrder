using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Constructor.xaml
    /// </summary>
    public partial class Constructor : Window
    {
        public byte[] photo { get; set; }
        public AuthoDataDataContext Autho = new AuthoDataDataContext();
        public Constructor()
        {
            InitializeComponent();
            c1.ItemsSource = Autho.Textile.Select(t => t.Article);
            c2.ItemsSource = Autho.Furniture.Select(f => f.ArticteF);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddTkani addTkani = new AddTkani();
            if (addTkani.ShowDialog() != false)
            {
                if (addTkani.textBox1.Text != null)
                {
                    Textile addPic = Autho.Textile.FirstOrDefault(t => t.Name == addTkani.textBox1.Text);
                    addPic.Photo = addTkani.photo;
                    Autho.SubmitChanges();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Textile tkan = Autho.Textile.FirstOrDefault(t => t.Article == c1.Text);
            MemoryStream ms = new MemoryStream();
            photo = tkan.Photo.ToArray();
            ms.Write(tkan.Photo.ToArray(), 0, tkan.Photo.Length) ;
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.StreamSource = ms;
            bmp.EndInit();
            i1.Source = bmp;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
