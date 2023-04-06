using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using Lab8.Assets.Models.LibraryObjects;
using Lab8.Assets.Helpers;
using Lab8.Assets.Models.Strategy;

namespace Lab8.Windows
{
    public partial class AddRecord
    {
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
            IDBTable book;

            var title = TitleTextBlock.Text;
            var authorFN = AuthorFNTextBlock.SelectedItem as String;
            var image = ImageBook.Source;

            var warnings = new Queue<string>();

            if(title is null || title is "")
            {
                warnings.Enqueue("Не введено название книги!");
            }
            if(authorFN is null || authorFN is "")
            {
                warnings.Enqueue("Не введены фамилия и имя автора");
            }
            if(image is null)
            {
                warnings.Enqueue("Изображение не выбрано");
            }

            if(warnings.Count > 0)
            {
                MessageBox.Show(string.Join("\n", warnings), "Ошибки");
                return;
            }

            int idAuthor = this.authors.First(el => el.FullName == authorFN).Id;
            int bookId = 0;

            Random rand = new Random();

            while(books.Any(el => el.Id == bookId))
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
                db.InsertObjectAsync(book);
                books.Add((Book)book);
                refresher.Refresh();

                MessageBox.Show("Книга добавлена!");
                this.Close();
            }
        }
    }
}
