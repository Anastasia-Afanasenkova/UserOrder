using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace AuthorizationWPF
{
    /// <summary>
    /// Логика взаимодействия для AddTkani.xaml
    /// </summary>
    public partial class AddTkani : Window
    {
        public byte[] photo { get; set; }
        public AddTkani()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string fileName = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG|*.jpg";
            openFileDialog.Title = "Выбрать картинку";
            if (openFileDialog.ShowDialog() == true)
                fileName = openFileDialog.FileName;
            photo = GetPhoto(fileName);
        }

        public static byte[] GetPhoto(string fileName)
        {
            FileStream stream = new FileStream(
                fileName, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] Photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return Photo;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
