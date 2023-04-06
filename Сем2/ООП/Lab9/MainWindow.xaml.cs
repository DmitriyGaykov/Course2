global using System;
global using System.Collections.Generic;
global using System.Configuration;
global using System.Data.SqlClient;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using System.Windows;
global using System.Windows.Controls;
global using System.Windows.Data;
global using System.Windows.Documents;
global using System.Windows.Input;
global using System.Windows.Media;
global using System.Windows.Media.Imaging;
global using System.Windows.Navigation;
global using System.Windows.Shapes;
global using System.Configuration;
global using Lab8.Assets.Models.DataBase;
global using Lab8.Assets.Models.LibraryObjects;
global using System.Collections.ObjectModel;
global using Lab8.Assets.Helpers;
global using System.IO;
global using static System.Net.Mime.MediaTypeNames;
global using System.Threading;
global using Lab8.Assets.Models.Strategy;
global using Lab9.Assets.Models.DataBase;

namespace Lab8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IRefresher
    {
        private readonly string connectionString;

        private readonly ObservableCollection<Book> books = new ObservableCollection<Book>();
        private readonly ObservableCollection<Author> authors = new ObservableCollection<Author>();

        private readonly DBE dataBase;

        private bool Onload = false;

        public MainWindow()
        {
            this.WindowState = WindowState.Maximized;

            InitializeComponent();
            AddRecord.Visibility = Visibility.Hidden;
            WaitLoad();

            connectionString = ConfigurationSettings.AppSettings["ConnectionString"];

            using (dataBase = new DBE(connectionString)) { }

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
            await Task.Run(() => GetInfo());
        }
        private void GetInfo()
        {
            using var db = new DBE();

            var books = db.Books?.ToList() ?? new List<Book>(); 
            var authors = db.Authors?.ToList() ?? new List<Author>(); 

            RewriteList(this.books, books);
            RewriteList(this.authors, authors);

            this.Refresh();
            Onload = true;
        }

        private void RewriteList<T>(IList<T> list1, IList<T> list2)
        {
            Dispatcher.Invoke(() =>
            {
                lock (list1)
                {
                    list1.Clear();
                    foreach (T item in list2)
                    {
                        list1.Add(item);
                    }
                }
            });
        }

        private async void WaitLoad()
        {
            await Task.Run(() =>
            {
                while (!Onload) ;
                Dispatcher.Invoke(() =>
                {
                    AddRecord.Visibility = Visibility.Visible;
                });
            });
        }
    }
}
