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
    /// Логика взаимодействия для Manager.xaml
    /// </summary>
    public partial class Manager : Page
    {
        public MainWindow mWindow;
        public AuthoDataDataContext Autho = new AuthoDataDataContext();
        public Manager(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mWindow = mainWindow;
            dataGrid1.ItemsSource = Autho.Goods;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            dataGrid1.ItemsSource = Autho.Goods;
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
            AddGood addGood = new AddGood("Добавить товар");
            if (addGood.ShowDialog() != false)
            {
                if (addGood.goodName.Text != null && addGood.goodArticle.Text != null && addGood.goodPrice != null)
                {
                    Goods NewGood = new Goods
                    {
                        Article = addGood.goodArticle.Text,
                        Name = addGood.goodName.Text,
                        Price = Convert.ToInt32(addGood.goodPrice)
                    };
                    Autho.Goods.InsertOnSubmit(NewGood);
                    Autho.SubmitChanges();
                }
                else
                    MessageBox.Show("Все поля должны быть заполненны!");
            }
            dataGrid1.Items.Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Goods selectedGood = (Goods)dataGrid1.SelectedItem;
                Goods findGood = Autho.Goods.First(p => p.Article == selectedGood.Article);
                AddGood editGood = new AddGood("Изменение продукта");

                editGood.goodArticle.Text = findGood.Article;
                editGood.goodName.Text = findGood.Name;
                editGood.goodPrice.Text = Convert.ToString(findGood.Price);
                if (editGood.ShowDialog() != false)
                {
                    selectedGood.Name = editGood.goodName.Text;
                    selectedGood.Article = editGood.goodArticle.Text;
                    selectedGood.Price = Convert.ToInt32(editGood.goodPrice.Text);
                    Autho.SubmitChanges();
                    dataGrid1.Items.Refresh();
                    MessageBox.Show("Информация по товару успешно изменена");
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
                Goods deleteGood = (Goods)dataGrid1.SelectedItem;
                Autho.Goods.DeleteOnSubmit(deleteGood);
                Autho.SubmitChanges();
                MessageBox.Show("Информация по товару успешно удалена");
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGrid1.Items.Refresh();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            AddTkani addTkani = new AddTkani();
            if (addTkani.ShowDialog() != false)
            {
                if (addTkani.textBox1.Text != null)
                {
                    Textile addPic = Autho.Textile.FirstOrDefault(t => t.Article == addTkani.textBox1.Text);
                    addPic.Photo = addTkani.photo;
                    Autho.SubmitChanges();
                }
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Constructor constructor = new Constructor();
            if (constructor.ShowDialog() != false)
            {
                Product product = new Product
                {
                    Article = constructor.t1.Text,
                    Name = constructor.t1.Text,
                    WidthInMillimetr = Convert.ToDouble(constructor.t2.Text),
                    LengthInMillimetr = Convert.ToDouble(constructor.t3.Text),
                    Photo = constructor.photo
                };
                Autho.Product.InsertOnSubmit(product);
                Autho.SubmitChanges();
            }
        }
    }
}
