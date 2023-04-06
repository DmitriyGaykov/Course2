using Lab8.Assets.Helpers;
using Lab8.Assets.Models.LibraryObjects;
using Lab8.Assets.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Text.RegularExpressions;

namespace Lab8.Windows
{
    public partial class AddRecord
    {
        private void AddAuthorRecord_Click(object sender, RoutedEventArgs e)
        {
            IDBTable author;

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
                db.AddAsync(author);

                authors.Add((Author)author);
                refresher.Refresh();

                MessageBox.Show("Автор добавлен!");
                this.Close();
            }
        }
    }
}
