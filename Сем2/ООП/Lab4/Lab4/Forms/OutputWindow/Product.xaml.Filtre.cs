using Lab4.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lab4.Forms.OutputWindow
{
    public partial class Products
    {
        private bool isGetState = false;
        void FillColors()
        {
            var colors = new List<string>();
            ComboBoxItem item;

            foreach(var prod in products)
            {
                item = new ComboBoxItem();
                item.Content= prod.Color;
                FiltreByColor.Items.Add(item);
            }
        
        }

        void CorrectFiltreByPrice()
        {
            Price_Start.TextChanged += new TextChangedEventHandler(Forms.Adder.AddForm.NumberChecker);
            Price_End.TextChanged += new TextChangedEventHandler(Forms.Adder.AddForm.NumberChecker);
        }

        private readonly ObservableCollection<Product> filtred_products = new ObservableCollection<Product>();
        void StartFiltre(object sender, TextChangedEventArgs e)
        {
            if (!isGetState)
            {
                filtred_products.Clear();

                var searchProd = SearchProducts()?.ToList() ?? this.products.ToList();
                var byColor = FiltreByColorProducts()?.ToList() ?? this.products.ToList();
                var byPrice = FiltreByPrice().ToList();
                var bySale = FiltreBySale()?.ToList() ?? this.products.ToList();

                if (this.products.Count() == searchProd.Count() &&
                   this.products.Count() == byColor.Count() &&
                   this.products.Count() == byPrice.Count() &&
                   this.products.Count() == bySale.Count())
                {
                    ProductsList.ItemsSource = this.products;
                    SaveState();
                    return;
                }

                var set = searchProd.Intersect(byPrice.Intersect(byColor.Intersect(bySale))).ToList();

                foreach (var el in set)
                {
                    filtred_products.Add(el);
                }

                ProductsList.ItemsSource = filtred_products;
                SaveState();
            }
        }

        HashSet<Product> FiltreByColorProducts()
        {
            var item = FiltreByColor.SelectedValue as ComboBoxItem;
            if (item.Content.ToString() == "none")
            {
                return null;
            }

            var set = new HashSet<Product>();

            products.Where(el => el.Color.ToLower().Contains(item.Content.ToString().ToLower())).ToList().ForEach(el => set.Add(el));

            return set;
        }

        HashSet<Product> FiltreByPrice()
        {
            var set = new HashSet<Product>();

            int start = int.Parse(Price_Start.Text);
            int end = int.Parse(Price_End.Text);

            products.Where(el => el.Price >= start && el.Price <= end).ToList().ForEach(el => set.Add(el));

            return set;
        }

        HashSet<Product> FiltreBySale()
        {
            var set = new HashSet<Product>();

            if(Sale.IsChecked.Value)
            {
                products.Where(el => el.Sale != 0).ToList().ForEach(el => set.Add(el));
                return set;
            }
            else
            {
                return null;
            }
        }
    }
}
