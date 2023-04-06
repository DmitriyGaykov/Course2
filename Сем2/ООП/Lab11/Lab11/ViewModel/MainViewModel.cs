using GalaSoft.MvvmLight.Messaging;
using Lab11.Model.Database;
using Lab11.Model.Database.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;

namespace Lab11.ViewModel;

public class MainViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public ObservableCollection<Item> Items { get; set; }
    //public ICommand EditColumns { get; init; }
    public Action<object, DataGridCellEditEndingEventArgs> EditEvent { get; init; }

    public MainViewModel()
    {
        GetDatasAsync();

        EditEvent += Edit;
    }

    public void OnPropertyChanged(string propName)
    {
        if (PropertyChanged is not null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
    public async void GetDatasAsync()
    {
        await Task.Run(() =>
        {
            using DB db = new DB();

            int i = 0;
            int take = 5;
            ref int skip = ref take;
            int all = db.Persons.Count();

            Items = new();

            while (i < all)
            {
                var persons = db.Persons.OrderBy(el => el.Id).Skip(i * skip).Take(take);
                var marks = db.Marks.OrderBy(el => el.PersonId).Skip(i * skip).Take(take);

                i++;

                if (persons is null || marks is null)
                {
                    return;
                }

                var res = (from p in persons.ToList()
                           join m in marks.ToList() on p.Id equals m.PersonId
                           select new { Person = p, Mark = m })
                       .Select(x => new Item
                       {
                           Name = x.Person.Name,
                           Spec = x.Person.Group.Spec.Name,
                           GroupNumber = x.Person.Group.GroupNumber,
                           Mark = x.Mark.StudentMark ?? 0,
                           CountOfPasses = x.Mark.NumberOfPasses ?? 0
                       }).ToList();

                foreach (var item in res)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Items.Add(item);
                    });
                }
                OnPropertyChanged("Items");
            }
        });
    }

    public void Edit(object sender, DataGridCellEditEndingEventArgs e)
    {
        var cell = ((DataGrid) sender).CurrentCell;
        byte newValue = byte.Parse(((TextBox)e.EditingElement).Text == "" ? ((TextBox)e.EditingElement).Text : "0");

        Item item = cell.Item as Item;
       
        string header = cell.Column.Header.ToString();

        EditAsync(item, header);

        ((TextBox)e.EditingElement).TextChanged += header == "Оценка" ? new TextChangedEventHandler(CheckOnMark) : new TextChangedEventHandler(CheckOnNumber);
    }

    public async void EditAsync(Item item, string header)
    {
        await Task.Run(() =>
        {
            using DB db = new DB();

            Mark mark = db.Marks.FirstOrDefault(el => el.PersonId == db.Persons.FirstOrDefault(el => el.Name.Equals(item.Name)).Id);

            if (header is "Оценка")
            {
                mark.StudentMark = (byte) item.Mark;
            }
            else if (header is "Количество пропусков")
            {
                mark.NumberOfPasses = item.CountOfPasses;
            }

            db.Marks.AddOrUpdate(mark);

            db.SaveChanges();
        });
    }

    public void CheckOnMark(object sender, TextChangedEventArgs e)
    {
        var textBox = sender as TextBox;

        textBox.Text = string.Join("", textBox.Text.Where(el => el is >= '0' and <= '9'));

        if (textBox.Text != string.Empty)
        {
            byte val = byte.Parse(textBox.Text);

            if(val is > 10 or < 0)
            {
                textBox.Text = "0";
                MessageBox.Show("Оценка не может быть ниже 0 и выше 10");
            }
        }

        textBox.Select(textBox.Text.Length, textBox.Text.Length);
    }

    public void CheckOnNumber(object sender, TextChangedEventArgs e)
    {
        var textBox = sender as TextBox;

        textBox.Text = string.Join("", textBox.Text.Where(el => el is >= '0' and <= '9'));
        textBox.Select(textBox.Text.Length, textBox.Text.Length);
    }
}

public record Item
{
    public string Name { get; set; }
    public string Spec { get; set; }
    public int GroupNumber { get; set; }
    public int Mark { get; set; }
    public int CountOfPasses { get; set; }

    public Item(string name,
                string spec,
                int group,
                int mark,
                int countOfPasses)
    {
        Name = name;
        Spec = spec;
        GroupNumber = group;
        Mark = mark;
        CountOfPasses = countOfPasses;
    }

    public Item()
    {
        
    }
}