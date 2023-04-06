using Lab8.Assets.Models.DataBase;
using Lab8.Assets.Models.LibraryObjects;
using Lab8.Assets.Models.Strategy;
using Lab9.Assets.Models.DataBase;
using Microsoft.Win32;
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

namespace Lab8.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddRecord.xaml
    /// </summary>
    public partial class AddRecord : Window
    {
        private readonly IList<Book> books;
        private readonly IList<Author> authors;
        private readonly IRefresher refresher;
        private readonly DBE db;

        public AddRecord(IList<Book> books, IList<Author> authors, IRefresher refresher, DBE db)
        {
            InitializeComponent();

            this.books = books;
            this.authors = authors;
            this.refresher = refresher;
            this.db = db;

            IsBook = false;

            AuthorFNTextBlock.ItemsSource = new ObservableCollection<string>(this.authors.Select(el => el.FullName).ToList());
        }

        private bool isBook = false;
        private bool IsBook
        {
            get => isBook;
            set 
            {
                isBook = value;

                BookOrAuthor.Content = "Добавить " + (IsBook ? "книги" : "автора");
                BookForm.Visibility = isBook ? Visibility.Visible : Visibility.Collapsed;
                AuthorForm.Visibility = isBook ? Visibility.Hidden : Visibility.Visible;
            }
        }

        private void BookOrAuthor_Click(object sender, RoutedEventArgs e) => IsBook = !IsBook;

        
    }
}
