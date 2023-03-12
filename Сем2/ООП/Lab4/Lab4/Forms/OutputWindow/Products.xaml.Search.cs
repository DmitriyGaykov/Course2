using Lab4.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lab4.Forms.OutputWindow
{
    public partial class Products
    {
        public HashSet<Product> SearchProducts()
        {
            var searchTextBox = Search;

            if(searchTextBox.Text is "")
            {
                return null;
            }

            var set = new HashSet<Product>();

            products.Where(el => el.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList().ForEach(el => set.Add(el));

            return set;
        }
    }
}
