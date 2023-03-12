using lab3.About;
using lab3.History;
using lab3.Search;
using lab3.Sorting;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
//^(375|\\+375)?(29|25|44|33)\\d{7}$
// ^[a-zA-Z0-9_-]{6,16}$
namespace Lab1
{
    public partial class Form1 : Form
    {
        private readonly History history = new();

        private List<Control> Controllers = null;
        public Form1()
        {
            InitializeComponent();

            this.FillControllers();
            this.FillInfo();
            ProgressInfo.SetProgressBarValue();
            history.Add(this);
        }

        private void ClickTextBox(object sender, EventArgs e)
        {
            var textBox = sender as Control;
            IInfo info = ProgressInfo.Controllers[textBox];

            if(textBox.Text == "")
            {
                info.IsUsed = false;
            }
            else
            {
                info.IsUsed = true;
            }

            ProgressInfo.SetProgressBarValue();
        }

        private void ClickOnRadio(object sender, EventArgs e)
        {
            var radio = sender as Control;

            ProgressInfo.Controllers.Values.ToList().ForEach(el =>
            {
                if(el.Controler is RadioButton)
                {
                    el.IsUsed = true;
                }
            });

            ProgressInfo.SetProgressBarValue();
        }

        private void ClickOnCheckBox(object sender, EventArgs e)
        {
            var checkBox = sender as Control;
            IInfo info = ProgressInfo.Controllers[checkBox];

            CheckBox cb = checkBox as CheckBox;

            if(cb is not null)
            {
                info.IsUsed = cb.Checked;
            }

            ProgressInfo.SetProgressBarValue();
        }

        private void ClickOnNumericUpDown(object sender, EventArgs e)
        {
            var numeric = sender as NumericUpDown;
            IInfo info = ProgressInfo.Controllers[numeric];

            info.IsUsed = numeric.Value > 0;

            ProgressInfo.SetProgressBarValue();
        }

        private void ClickOnSender(object sender, EventArgs e)
        {
            int progress = ProgressInfo.GetProgress();
            int max = ProgressInfo.Maximum;
            bool isSuccess = progress == max;

            if(isSuccess)
            {
                Author author = GetInfoAboutAuthor();
                Book book = GetInfoAboutBook();

                if (book is not null)
                {

                    Saver<Author>.Open("author.json");
                    Saver<Author>.SaveObject(ref author);
                    Saver<Author>.Close();

                    Saver<Book>.Open("book.json");
                    Saver<Book>.SaveObject(ref book);
                    Saver<Book>.Close();
                    MessageBox.Show("Успешно. Данные сохраненны!");
                    return;
                }
            }
            MessageBox.Show("Неуспешно. Не хватает данных");
        }
        private void CheckOfNumbers(object obj, EventArgs e)
        {
            var text = obj as TextBox;
            var arr = text.Text.ToArray();

            if (arr.Any(el => el is not (>= '0' and <= '9')))
            {
                text.Text = string.Join("", arr.Where(el => el is (>= '0' and <= '9')).ToArray());
                text.SelectionStart = text.Text.Length;
            }
        }

        private void FillControllers()
        {
            this.Controllers = new List<Control>()
            {
                TypeTextBox,
                SizeTextBox,
                TitleTextBox,
                MaderTextBox,
                CountListsNumeric,
                MadeDateTime,
                AuthorTextBox,
                LoudDateDateTime,
                NameTextBox,
                CountryTextBox,
                RadioMale,
                RadioWoman,
                DirectionListBox,
                AgreeCheckbox
            };
        }

        private void FillInfo()
        {
            IInfo info;

            this.Controllers.ForEach(el =>
            {
                info = new Info(el);

                if (el is (DateTimePicker or ListBox))
                {
                    info.IsUsed = true;
                }

                ProgressInfo.Controllers[el] = info;
            }
            );

            ProgressInfo.ProgressBar = ProgressBarOfReg;
        }

        private Author GetInfoAboutAuthor()
        {
            string name = NameTextBox.Text;
            string country = CountryTextBox.Text;
            Sex sex = RadioMale.Checked ? Sex.Male : Sex.Woman;
            Direction direction = DirectionListBox.Text switch
            {
                "Драматург" => Direction.Drama,
                "Публицист" => Direction.Public,
                "Романтик" => Direction.Romantic,
                "Критик" => Direction.Critic,
                "Поэт" => Direction.Poet,
                _ => Direction.Drama
            };

            return new(name, country, sex, direction);
        }

        private Book GetInfoAboutBook()
        {
            string type = TypeTextBox.Text;
            int size = int.Parse(SizeTextBox.Text);
            string title = TitleTextBox.Text;
            string mader = MaderTextBox.Text;
            uint count = (uint)CountListsNumeric.Value;
            DateTime dtCreating = MadeDateTime.Value;
            string listAuthors = AuthorTextBox.Text;
            DateTime loudDT = LoudDateDateTime.Value;

            Book book = new(type, size, title, mader, count, dtCreating, listAuthors, loudDT);
            var context = new ValidationContext(book);
            var result = new List<ValidationResult>();

            if (Validator.TryValidateObject(book, context, result, true))
            {
                return book;
            }

            MessageBox.Show(string.Join(";\n", result));
            return null;
        }

        private void ClickGetter(object sender, EventArgs e)
        {
            Saver<Author>.PathToFile = "author.json";
            var authors = Saver<Author>.GetObjectsFromFile();

            Saver<Book>.PathToFile = "book.json";
            var books = Saver<Book>.GetObjectsFromFile();

            MessageBox.Show(authors.Last() + "\n" + books.Last());
        }

        private void StartSearch(object sender, EventArgs e)
        {
            Saver<Book>.PathToFile = "book.json";
            Search search = new(Saver<Book>.GetObjectsFromFile(), history);
            search.Show();
            history.Add(search);
            this.Hide();
        }

        private void StartSorting(object sender, EventArgs e)
        {
            Saver<Book>.PathToFile = "book.json";
            Sorting sorting = new(Saver<Book>.GetObjectsFromFile(), history);
            sorting.Show();
            history.Add(sorting);
            this.Hide();
        }

        private void ViewAbout(object sender, EventArgs e)
        {
            About about = new();
            about.Show();
        }

        private void ClickOnBack(object sender, EventArgs e)
        {
            var form = history.Prev();
            form?.Show();

            if (form is not null)
            {
                this.Hide();
            }
        }

        private void ClickOnNext(object sender, EventArgs e)
        {
            var form = history.Next();
            form?.Show();

            if (form is not null)
            {
                this.Hide();
            }
        }

    }
}