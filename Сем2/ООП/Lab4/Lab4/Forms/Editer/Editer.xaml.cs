using Lab4.Products;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab4.Forms.Editer
{
    /// <summary>
    /// Логика взаимодействия для Editer.xaml
    /// </summary>
    public partial class Editer : Window
    {
        private Product defaultProduct;

        private Editer() { }
        public Editer(Lab4.Products.Product product)
        {
            defaultProduct = product;
            InitializeComponent();
            Product_Price.TextChanged += NumberChecker;
            Product_Sale.TextChanged += NumberChecker;
            Product_Size.TextChanged += NumberChecker;

            Product_Name.Text = defaultProduct.Name;
            Product_Color.Text = defaultProduct.Color;
            Product_Price.Text = defaultProduct.Price.ToString();
            Product_Country.Text = defaultProduct.Country.ToString();
            Product_Description.Text = defaultProduct.Description.ToString();

            BitmapImage image = new BitmapImage(new Uri(defaultProduct.Img));
            Product_Image.Source = image;

            Product_Sale.Text = defaultProduct.Sale.ToString();
            Product_Size.Text = ((Clothes)defaultProduct).Size.ToString();
        }

        private void OnCancle(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void ClickOnLoudImg(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";

            if (dialog.ShowDialog() == true)
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(dialog.FileName);
                bitmap.EndInit();
                Product_Image.Source = bitmap;
            }
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            Regex regName = new Regex(@"^[A-Za-zА-Яа-я0-9]{1,50}$");
            Regex regColor = new Regex(@"^[A-Za-zА-Яа-я ]{1,20}$");
            Queue<string> mistakes = new Queue<string>();

            string name = Product_Name.Text.Trim();
            string price = Product_Price.Text.Trim();
            string sale = Product_Sale.Text.Trim();
            string img = Product_Image.Source?.ToString();
            string description = Product_Description.Text.Trim();
            string country = Product_Country.Text.Trim();
            string size = Product_Size.Text.Trim();
            string color = Product_Color.Text.Replace("  ", " ").ToLower();

            if (!regName.IsMatch(name))
            {
                mistakes.Enqueue("Имя введено некорректно!");
            }
            if (price is null || price is "")
            {
                mistakes.Enqueue("Цена не введена!");
            }
            if (sale is null || sale is "" || int.Parse(sale) > 100)
            {
                sale = "0";
                MessageBox.Show("Скидка установлена на 0");
            }
            if (!regColor.IsMatch(color))
            {
                mistakes.Enqueue("Цвет введен некорректно!");
            }
            if (img is null)
            {
                mistakes.Enqueue("Изображение не выбрано!");
            }

            if (description is null || description is "")
            {
                mistakes.Enqueue("Описание не введено!");
            }
            if (country is null | country is "")
            {
                mistakes.Enqueue("Странна введена не корректно!");
            }
            if (size is null || country == "")
            {
                mistakes.Enqueue("Размер введен некорректно!");
            }
            if (byte.Parse(sale) > 100)
            {
                mistakes.Enqueue("Скидка не может быть больше 100");
            }
            if (mistakes.Count() != 0)
            {
                MessageBox.Show(string.Join("\n", mistakes.ToArray()));
            }
            else
            {
                // todo: Проверки
                Clothes clothes = new Clothes(name, img, country, color, description, double.Parse(price), UInt16.Parse(size), byte.Parse(sale));
                Saver.Saver saver = new Lab4.Saver.Saver("products.json", true);

                if (CheckOnId(clothes))
                {
                    var prods = saver.FromJson().Where(el => !el.Equals(defaultProduct)).ToList();
                    prods.Add(clothes);

                    saver.ClearFile();
                    saver.ToJson(prods);

                    MessageBox.Show($"Товар добавлен: {clothes.ToString()}");

                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Товар уже был добавлен ранее");
                }
            }
        }

        private void NumberChecker(object sender, RoutedEventArgs e)
        {
            var input = sender as TextBox;

            if (input.Text.Any(el => !(el >= '0' && el <= '9')))
            {
                input.Text = string.Join("", input.Text.Where(el => (el >= '0' && el <= '9')));
                input.Focus();
                input.Select(input.Text.Length, 0);
            }
        }

        private bool CheckOnId(Product p)
        {
            Saver.Saver saver = new Saver.Saver("products.json");
            var prods = saver.FromJson();
            return !prods.Any(el => el.Equals(p) && !el.Equals(defaultProduct));
        }
    }
}
