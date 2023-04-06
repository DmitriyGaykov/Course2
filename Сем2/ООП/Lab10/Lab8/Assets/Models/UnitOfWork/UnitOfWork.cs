using Lab8.Assets.Models.LibraryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Assets.Models.UnitOfWork
{
    public class UnitOfWork
    {
        private readonly OrderContext db;
        public UnitOfWork(OrderContext db) 
        {
            this.db = db;
        }

        public IList<Book> Books
        {
            get => db.Books;
        }

        public IList<Author> Authors
        {
            get => db.Authors;
        }
    }
}
