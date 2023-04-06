﻿using Lab8.Assets.Helpers;
using Lab8.Assets.Models.DataBase;
using Lab8.Assets.Models.LibraryObjects;
using Lab8.Assets.Models.Strategy;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab8.Windows.Editing
{
    /// <summary>
    /// Логика взаимодействия для EditRecord.xaml
    /// </summary>
    public partial class EditRecord : Window
    {
        private readonly IList<Book> books;
        private readonly IList<Author> authors;
        private readonly IRefresher refresher;
        private readonly DB db;
        private readonly IDBTable table;

        public EditRecord(IList<Book> books, IList<Author> authors, IRefresher refresher, DB db, IDBTable table)
        {
            InitializeComponent();

            this.books = books;
            this.authors = authors;
            this.refresher = refresher;
            this.db = db;

            this.table = table;

            IsBook = table is Book;

            SetDefault();

            AuthorFNTextBlock.ItemsSource = new ObservableCollection<string>(this.authors.Select(el => el.FullName).ToList());
        }

        private void SetDefault()
        {
            if(IsBook)
            {
                var book = table as Book;

                TitleTextBlock.Text = book.Title;
                ImageBook.Source = book.Src;
            }
            else
            {
                var author = table as Author;

                FullNameTextBlock.Text = author.FullName;
                AliasTextBlock.Text = author.Alias;
            }
        }

        private bool isBook = false;
        private bool IsBook
        {
            get => isBook;
            set
            {
                isBook = value;

                BookForm.Visibility = isBook ? Visibility.Visible : Visibility.Collapsed;
                AuthorForm.Visibility = isBook ? Visibility.Hidden : Visibility.Visible;
            }
        }

        private void BookOrAuthor_Click(object sender, RoutedEventArgs e) => IsBook = !IsBook;

        private void AddAuthorRecord_Click(object sender, RoutedEventArgs e)
        {
            Author author;

            var fullName = FullNameTextBlock.Text;
            var alias = AliasTextBlock.Text;

            var warnings = new Queue<string>();

            Regex aliasReg = new Regex(@"^[А-Я]\.[А-Я]\. [А-Я]([а-я])+$");
            Regex fullNameReg = new Regex(@"^[А-Я]([а-я])+ [А-Я]([а-я])+$");

            if (fullName is null || fullName is "" || !fullNameReg.IsMatch(fullName))
            {
                warnings.Enqueue("Не введены фамилия и имя автора");
            }
            if (alias is null || alias is "" || !aliasReg.IsMatch(alias))
            {
                warnings.Enqueue("Не введены инициалы автора");
            }

            if (warnings.Count > 0)
            {
                MessageBox.Show(string.Join("\n", warnings), "Ошибки");
                return;
            }

            Random rand = new Random();
            int authorId = 0;
            while (authors.Any(el => el.Id == authorId))
            {
                authorId = rand.Next(0, 2_000_000_000);
            }


            author = new Author(authorId, fullName, alias);

            if (books.Any(el => el.Equals(author)))
            {
                MessageBox.Show("Такой автор уже есть в БД!");
            }
            else
            {
                db.UpdateObjectAsync(author);
                //refresher.Refresh();

                var _author = table as Author;
                _author.FullName = author.FullName;
                _author.Alias = author.Alias;

                MessageBox.Show("Автор добавлен!");
                this.Close();
            }
        }

        private void LoadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image|*.jpg;*.jpeg;*.png;";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    ImageBook.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                }
                catch
                {
                    MessageBox.Show("Выберите файл подходящего формата.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void AddBookRecord_Click(object sender, RoutedEventArgs e)
        {
            Book book;

            var title = TitleTextBlock.Text;
            var authorFN = AuthorFNTextBlock.SelectedItem as String;
            var image = ImageBook.Source;

            var warnings = new Queue<string>();

            if (title is null || title is "")
            {
                warnings.Enqueue("Не введено название книги!");
            }
            if (authorFN is null || authorFN is "")
            {
                warnings.Enqueue("Не введены фамилия и имя автора");
            }
            if (image is null)
            {
                warnings.Enqueue("Изображение не выбрано");
            }

            if (warnings.Count > 0)
            {
                MessageBox.Show(string.Join("\n", warnings), "Ошибки");
                return;
            }

            int idAuthor = this.authors.First(el => el.FullName == authorFN).Id;
            int bookId = 0;

            Random rand = new Random();

            while (books.Any(el => el.Id == bookId))
            {
                bookId = rand.Next(0, 2_000_000_000);
            }

            book = new Book(bookId, title, idAuthor, MyConverter.ImageToBytes(image as BitmapImage));

            if (books.Any(el => el.Equals(book)))
            {
                MessageBox.Show("Такая книга уже есть!");
            }
            else
            {
                db.UpdateObjectAsync(book);

                var _book = table as Book;

                _book.Image = book.Image;
                _book.AuthorId = book.AuthorId;
                _book.Title = book.Title;

                //refresher.Refresh();

                MessageBox.Show("Книга добавлена!");
                this.Close();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            db.DeleteObjectAsync(table);

            if(table is Book b)
            {
                books.Remove(b);
            }
            else if(table is Author a)
            {
                authors.Remove(a);
            }

            refresher.Refresh();

            MessageBox.Show("Удалено!");
            this.Close();
        }
    }
}
