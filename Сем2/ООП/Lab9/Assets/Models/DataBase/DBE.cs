using Lab8.Assets.Models.LibraryObjects;
using Lab8.Assets.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.Assets.Models.DataBase;

public class DBE : DbContext
{
    #region Fields

    public static string ConnectionString = null;

    #endregion

    #region Ctors

    public DBE() : base(ConnectionString ?? throw new Exception())
    {

    }

    public DBE(string options) : base(options)
    {
        ConnectionString = options;
    }

    #endregion

    #region Props

    #region Tables

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    #endregion

    #endregion

    #region Methods

    public async void AddAsync(IDBTable row) => await Task.Run(() => Add(row));

    public void Add(IDBTable row)
    {
        using var context = new DBE();

        if(row is Author a && !context.Authors.Select(el => el.Id).Any(el => el.Equals(a.Id)))
        {
            context.Authors.Add(a);
        }
        else if(row is Book b && !context.Books.Select(el => el.Id).Any(el => el.Equals(b.Id)))
        {
            context.Books.Add(b);
        }

        context.SaveChanges();
    }

    public async void UpdateAsync(IDBTable row)
    {
        await Task.Run(() => Update(row));
    }

    public void Update(IDBTable row)
    {
        using var context = new DBE();

        if(row is Book b)
        {
            context.Books.AddOrUpdate(b);
        }
        else if(row is Author a)
        {
            context.Authors.AddOrUpdate(a);
        }

        context.SaveChanges();
    }

    public async Task DeleteAsync(IDBTable row) => await Task.Run(() => Delete(row));

    public void Delete(IDBTable row)
    {
        using var context = new DBE();

        if(row is Book b)
        {
            var book = context.Books.Find(b.Id);
            context.Books.Remove(book);
        }
        else if(row is Author a)
        {
            var author = context.Authors.Find(a.Id);
            context.Authors.Remove(author);
        }

        context.SaveChanges();
    }

    #endregion
}
