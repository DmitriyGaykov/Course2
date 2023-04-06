using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using System.Configuration;
using Lab8.Assets.Models.DataBase;
using Lab8.Assets.Models.LibraryObjects;
using System.Collections.ObjectModel;
using Lab8.Assets.Helpers;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using Lab8.Assets.Models.Strategy;

namespace Lab8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IRefresher
    {
        private readonly DB dataBase;
        private readonly string connectionString;

        private readonly ObservableCollection<Book> books = new ObservableCollection<Book>();
        private readonly ObservableCollection<Author> authors = new ObservableCollection<Author>();

        public MainWindow()
        {
            this.WindowState = WindowState.Maximized;

            InitializeComponent();

            connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
            dataBase = new DB(connectionString);

            BooksTable.Items.Clear();
            BooksTable.ItemsSource = books;

            AuthorsTable.Items.Clear();
            AuthorsTable.ItemsSource = authors;

            BooksTable.MouseDoubleClick += new MouseButtonEventHandler(this.Table_Click);
            AuthorsTable.MouseDoubleClick += new MouseButtonEventHandler(this.Table_Click);

            GetInfoAsync();
        }

        private async void GetInfoAsync()
        {
            var books = await dataBase.RecvFromDBAsync(new Book());
            var authors = await dataBase.RecvFromDBAsync(new Author());

            RewriteList(this.books, books);
            RewriteList(this.authors, authors);

            this.Refresh();
        }

        private void RewriteList<T>(ObservableCollection<T> list1, IList<T> list2)
        {
            lock (list1)
            {
                list1.Clear();
                foreach (T item in list2)
                {
                    list1.Add(item);
                }
            }
        }
    }
}
