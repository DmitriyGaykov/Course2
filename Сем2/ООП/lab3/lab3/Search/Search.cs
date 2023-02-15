using Lab1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab3.History;

namespace lab3.Search;

public partial class Search : Form
{
    private List<Book> datas;
    private readonly History.History history;
    private Search()
    {
        InitializeComponent();
    }
    public Search(List<Book> datas, History.History history) : this()
    {
        this.datas = datas;
        this.history = history;
    }
    public void CheckOfNumbers(object obj, EventArgs e)
    {
        var text = obj as TextBox;
        var arr = text.Text.ToArray();

        if (arr.Any(el => el is not (>= '0' and <= '9')))
        {
            text.Text = string.Join("", arr.Where(el => el is (>= '0' and <= '9')).ToArray());
            text.SelectionStart = text.Text.Length;
        }
    }
    private HashSet<Book> StartSearch()
    {
        var textFromMader = SearchMaderTB.Text;
        var setYear = new HashSet<Book>(datas);

        int numFromYear;
        if (SearchYearTB.Text != string.Empty && int.TryParse(SearchYearTB.Text, out numFromYear))
        {
            setYear = SearchByYear(numFromYear);
        }

        int from = (int)FromNum.Value;
        int to = (int)ToNum.Value;

        var setMader = SearchByMader(textFromMader);
        var setCountLists = SearchByCountLists(from, to);

        setMader.IntersectWith(setYear);
        setMader.IntersectWith(setCountLists);

        return setMader;
    }
    private HashSet<Book> SearchByMader(string mader)
    {
        string pattern = $@"\b{mader}\w*";
        return new(datas.Where(el => Regex.IsMatch(el.Mader, pattern)).ToList());
    }
    private HashSet<Book> SearchByYear(int year) => new(datas.Where(el => el.DTOfCreating.Year == year).ToList());
    private HashSet<Book> SearchByCountLists(int from, int to) => new(datas.Where(el => el.CountLists > from && el.CountLists < to));
    private void ChangedText(object sender, EventArgs e)
    {
        var set = StartSearch();
        HashSet<NewBook> setNewBook = new();

        foreach(var el in set)
        {
            setNewBook.Add(new(el));
        }

        DatasTo.Items.Clear();
        DatasTo.Items.AddRange(setNewBook.ToArray());
    }
    public class NewBook
    {
        private Book book;
        public Book Book 
        { 
            get => book; 
            set => book = value; 
        }
        public NewBook(Book book) => this.book = book;
        public override string ToString() => $"Title: {book.Title}  Date of creating: {book.DTOfCreating}  Mader: {book.Mader}  Count of lists: {book.CountLists}  Date of Loud: {book.DTLoud}";
    }

    private void SaveInfo(object sender, EventArgs e)
    {
        string text = "Информация об последнем поиске: \n";
        List<NewBook> list = new();

        foreach(var el in DatasTo.Items)
        {
            list.Add((NewBook)el);
        }

        string json = JsonSerializer.Serialize(list);
        File.WriteAllText("searching.log", text + json);
    }
    private void ClickOnBack(object sender, EventArgs e)
    {
        var form = history.Prev();
        form?.Show();

        if (form is not null)
        {
            this.Hide();

            if (form is Form1)
            {
                var index = history.Index;
                history.Add(form);
                history.Index = index;
            }
        }
    }

    private void ClickOnNext(object sender, EventArgs e)
    {
        var form = history.Next();
        form?.Show();

        if (form is not null)
        {
            this.Hide();

            if (form is Form1)
            {
                var index = history.Index;
                history.Add(form);
                history.Index = index;
            }
        }
    }

    private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true; // отменяем закрытие формы
            this.Hide(); // скрываем форму, но она продолжает существовать
        }
    }
}
