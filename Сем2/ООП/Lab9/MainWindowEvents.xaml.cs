using Lab8.Assets.Models.LibraryObjects;
using Lab8.Assets.Models.Strategy;
using Lab8.Windows;
using Lab8.Windows.Editing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab8
{
    public partial class MainWindow
    {
        private bool showBook = false;
        private bool ShowBookProp
        {
            get => showBook;
            set
            {
                showBook = value;

                BooksTable.Visibility = showBook ? Visibility.Visible : Visibility.Hidden;
                AuthorsTable.Visibility = showBook ? Visibility.Hidden : Visibility.Visible;

                ShowTable.Content = showBook ? "Книги" : "Авторы";
            }
        }

        private void ShowTable_Click(object sender, RoutedEventArgs e) => ShowBookProp = !ShowBookProp;

        private void AddRecord_Click(object sender, RoutedEventArgs e)
        {
            var form = new AddRecord(books, authors, this, dataBase);
            form.Show();
        }

        private void Table_Click(object sender, MouseButtonEventArgs e)
        {
            var table = ((DataGrid)sender).SelectedItem as IDBTable;  
            var form = new EditRecord(books, authors, this, dataBase, table);
            form.Show();
        }

        public void Refresh()
        {
            Dispatcher.Invoke(() =>
            {
                BooksTable.Items.Refresh();
                AuthorsTable.Items.Refresh();
            });
        }
    }
}
