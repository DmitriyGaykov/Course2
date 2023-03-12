using History;
using Lab4.Forms.Adder;
using Lab4.Storages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClickOnOutput(object sender, RoutedEventArgs e)
        {
            Forms.OutputWindow.Products products = new Forms.OutputWindow.Products();
            products.Show();
            this.Close();
        }

        private void ClickOnAdd(object sender, RoutedEventArgs e)
        {
            AddForm af = new AddForm();
            af.Show();
            this.Close();
        }

        private void ClickOnRu(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("SourceDict/Rus.xaml", UriKind.Relative);
            ResourceDictionary res = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(res);
        }

        private void ClickOnEn(object sender, RoutedEventArgs e)    
        {
            var uri = new Uri("SourceDict/En.xaml", UriKind.Relative);
            ResourceDictionary res = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(res);
        }

        private void ClickOnBy(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("SourceDict/By.xaml", UriKind.Relative);
            ResourceDictionary res = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(res);
        }

        private void ClickOnChina(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("SourceDict/China.xaml", UriKind.Relative);
            ResourceDictionary res = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(res);
        }

        private void Themes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = sender as ListView;
            var item = list.SelectedItem as ListViewItem;

            var uri = new Uri($"Styles/View/Themes/{item.Uid}.xaml", UriKind.Relative);

            // MessageBox.Show(File.ReadAllText($"..\\..\\Styles\\View\\Themes\\{item.Uid}.xaml"));

            ResourceDictionary res = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.RemoveAt(3); 
            Application.Current.Resources.MergedDictionaries.Add(res);
        }
    }
}
