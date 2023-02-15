using Lab1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab3.Search;
using static lab3.Search.Search;
using System.Text.Json;

namespace lab3.Sorting;

public partial class Sorting : Form
{
    private List<Book> datas;
    private readonly History.History history;
    private Sorting()
    {
        InitializeComponent();
    }
    public Sorting(List<Book> datas, History.History history) : this()
    {
        this.datas = datas;
        this.history = history;
    }

    public void ClickRadio(object sender, EventArgs e)
    {
        var radio = sender as RadioButton;
        DatasTo.Items.Clear();
        List<NewBook> newList = new();
        
        if(radio == ByTitle)
        {
            datas = datas.OrderBy(el => el.Title).ToList();
        }
        else
        {
            datas = datas.OrderBy(el => el.DTLoud).ToList();
        }

        foreach(var el in datas)
        {
            newList.Add(new(el));
        }

        DatasTo.Items.AddRange(newList.ToArray());
    }

    private void SaveInfo(object sender, EventArgs e)
    {
        string text = "Информация об последней сортировки: \n";
        List<NewBook> list = new();

        foreach (var el in DatasTo.Items)
        {
            list.Add((NewBook)el);
        }

        string json = JsonSerializer.Serialize(list);
        File.WriteAllText("searching.log", text + json);
    }

    private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true; // отменяем закрытие формы
            this.Hide(); // скрываем форму, но она продолжает существовать
        }
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

}
