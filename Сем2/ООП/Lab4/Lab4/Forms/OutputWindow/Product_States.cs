using Lab4.Products;
using Lab4.Storages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab4.Forms.OutputWindow
{
    public partial class Products
    {
        private void BackToPrevState(object sender, RoutedEventArgs e)
        {
            GetState();
        }

        private void ToNextState(object sender, RoutedEventArgs e)
        {
            GetState(false);
        }

        public async void GetStateAsync(bool isPrev = true)
        {
            await Task.Run(() => GetState(isPrev));
        }

        public void GetState(bool isPrev = true)
        {
            isGetState = true;

            ProductsSaveInfo info = isPrev ? storage.Prev : storage.Next;

            ProductsList.ItemsSource = info.Products;
            Search.Text = info.SearchData;
            FiltreByColor.SelectedIndex = info.SelectedColor;
            Sale.IsChecked = info.IsSale;
            products = new ObservableCollection<Product>(info.AllProducts);

            saver.ClearFile();
            saver.ToJson(info.AllProducts.ToList());

            SaveState(false);
            isGetState = false;
        }

        public async void SaveStateAsync(bool resetIndex = true)
        {
            await Task.Run(() => SaveState(resetIndex));
        }
        public readonly object locker = new object();
        public void SaveState(bool resetIndex = true)
        {
            lock (locker)
            {
                var info = new ProductsSaveInfo(new ObservableCollection<Product>((ObservableCollection<Product>)ProductsList.ItemsSource),
                                                Search.Text,
                                                FiltreByColor.SelectedIndex,
                                                Sale.IsChecked.Value,
                                                new ObservableCollection<Product>(products));

                storage.SaveStateAsync(info, resetIndex);
            }
        }

        public class ProductsSaveInfo
        {
            public ObservableCollection<Product> Products { get; set; }
            public ObservableCollection<Product> AllProducts { get; set; }
            public string SearchData { get; set; }
            public int SelectedColor { get; set; }
            public bool IsSale { get; set; }

            public ProductsSaveInfo(ObservableCollection<Product> products,
                                     string searchData,
                                     int selectedColor, 
                                     bool isSale,
                                     ObservableCollection<Product> allProducts)
            {
                this.SearchData = searchData;
                this.Products = products;
                this.SelectedColor = selectedColor;
                this.IsSale = isSale;
                this.AllProducts = allProducts;
            }
        }
    }
}
