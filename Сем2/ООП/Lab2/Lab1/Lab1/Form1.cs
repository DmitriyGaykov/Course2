using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Lab1
{
    public partial class Form1 : Form
    {
        private List<Control> Controllers;
        public Form1()
        {
            InitializeComponent();

            this.FillControllers();
            this.FillInfo();
            ProgressInfo.SetProgressBarValue();
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

            MessageBox.Show(isSuccess ? "Успешно. Данные сохраненны!" : "Неуспешно. Не хватает данных");

            if(isSuccess)
            {
                Author author = GetInfoAboutAuthor();
                Book book = GetInfoAboutBook();

                Saver<Author>.Open("author.json");
                Saver<Author>.SaveObject(ref author);
                Saver<Author>.Close();

                Saver<Book>.Open("book.json");
                Saver<Book>.SaveObject(ref book);
                Saver<Book>.Close();
            }
        }

        private void CheckOnNumber(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
            {
                var textBox = sender as TextBox;

                if (!Checker.CheckOnNumber(textBox.Text, 0))
                {
                    textBox.Text = string.Empty;
                }
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

            return new(type, size, title, mader, count, dtCreating, listAuthors, loudDT);
        }

        private void ClickGetter(object sender, EventArgs e)
        {
            Saver<Author>.PathToFile = "author.json";
            var authors = Saver<Author>.GetObjectsFromFile();

            Saver<Book>.PathToFile = "book.json";
            var books = Saver<Book>.GetObjectsFromFile();

            MessageBox.Show(authors.Last() + "\n" + books.Last());
        }
    }
}