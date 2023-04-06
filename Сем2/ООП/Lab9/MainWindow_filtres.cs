using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public partial class MainWindow : Window, IRefresher
    {
        private async void StartFiltre(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Dispatcher.Invoke(() =>
                {
                    var byText = ByText();
                    var byAuthorName = ByAuthorName();

                    var res = byText.Intersect(byAuthorName).ToList();

                    RewriteList(this.books, res);
                });
            });
        }
        private IList<Book> ByText()
        {
            using var db = new DBE();
            var searchText = SearchBox.Text;

            if(string.IsNullOrWhiteSpace(searchText))
            {
                return db.Books.ToList();
            }

            var list = db.Books.Where(el => el.Title.ToLower().Contains(searchText.ToLower())).ToList();
            return list;
        }
        private IList<Book> ByAuthorName()
        {
            using var db = new DBE();
            var authorName = SearchAuthorBox.Text;

            if (string.IsNullOrWhiteSpace(authorName))
            {
                return db.Books.ToList();
            }

            var idWithNames = db.Books.Join(
                    db.Authors,
                    b => b.AuthorId,
                    a => a.Id,
                    (b, a) => new
                    {
                        Id = b.Id,
                        AuthorName = a.FullName.ToLower()
                    }
                );

            var ids = idWithNames.Where(el => el.AuthorName.Contains(authorName.ToLower())).Select(el => el.Id);

            var list = db.Books.Where(el => ids.Any(i => i == el.Id)).ToList();

            return list;
        }
    }
}
