using Lab4.Forms.Adder;
using Lab4.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab4.Forms.OutputWindow
{
    public partial class Products : Window
    {
        private Product product;

        public void DoSelect(object sender, SelectionChangedEventArgs e)
        {
            if(ProductsList.SelectedItems != null)
            {
                Edit.Visibility = Visibility.Visible;
                Remove.Visibility = Visibility.Visible;
            }
            else
            {
                Edit.Visibility = Visibility.Hidden;
                Remove.Visibility = Visibility.Hidden;
            }
        }
        public void ClickOnAdd(object sender, RoutedEventArgs e)
        {
            AddForm af = new AddForm();
            af.Show();
            this.Close();
        }

        public void OnItem(object sender, MouseButtonEventArgs e)
        {
            var sp = sender as StackPanel;

            if (sp is null) return;

            var id = sp.Uid;
            var temp = products.ToList().Find(el => el.ID == id);

            product = temp is null ? product : temp;
        }

        public void OnEdit(object sender, RoutedEventArgs e)
        {
            if (product is null) return;

            Editer.Editer editer = new Forms.Editer.Editer(product);
            editer.Show();
            this.Close();
        }

        public void OnRemove(object sender, RoutedEventArgs e)
        {
            SaveState();

            if(product is null) return;

            products.Remove(product);
            saver.ClearFile();
            saver.ToJson(products.ToList());

            Edit.Visibility = Visibility.Hidden;
            Remove.Visibility = Visibility.Hidden;

            SaveState();
        }
    }
}
