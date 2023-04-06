using Lab8.Assets.Models.LibraryObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Assets.Models.UnitOfWork
{
    public class OrderContext
    {
        public IList<Book> Books { get; private set; }
        public IList<Author> Authors { get; private set; } 

        public OrderContext(IList<Book> books, IList<Author> authors) 
        {
            this.Books = books;
            this.Authors = authors;
        }
    }
}
