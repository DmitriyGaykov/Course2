using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using History;
using Lab4.Products;
using Lab4.Storages;

namespace Lab4.Forms.OutputWindow
{
    /// <summary>
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class Products : Window
    {
        private readonly Storage<ProductsSaveInfo> storage = new Storage<ProductsSaveInfo>();
        private readonly string Path = "products.json";
        private readonly Lab4.Saver.Saver saver;

        private ObservableCollection<Product> products;
        public Products()
        {
            InitializeComponent();
            saver = new Lab4.Saver.Saver(this.Path, true);

            products = new ObservableCollection<Product>(saver.FromJson());
            ProductsList.ItemsSource = products;
            ProductsList.SelectionChanged += new SelectionChangedEventHandler(DoSelect);

            this.FillColors();
            this.CorrectFiltreByPrice();

            Search.TextChanged += new TextChangedEventHandler(StartFiltre);
            Price_End.TextChanged += new TextChangedEventHandler(StartFiltre);
            Price_Start.TextChanged += new TextChangedEventHandler(StartFiltre);
            FiltreByColor.SelectionChanged += new SelectionChangedEventHandler((object sender, SelectionChangedEventArgs e) => StartFiltre(sender, null));
            Sale.Click += new RoutedEventHandler((object sender, RoutedEventArgs e) => StartFiltre(sender, null));

            SaveState();
        }

        private void ClickOnBack(object sender, RoutedEventArgs e) 
        {
            Window window = new MainWindow();
            window.Show();
            this.Close();
        }

       
    }
}
