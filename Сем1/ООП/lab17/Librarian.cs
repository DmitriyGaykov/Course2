namespace lab17;
sealed class Librarian : APerson
{
    public void GetOrder(Reader pers, 
                         string name)
    {
        var book = Library.GetBook(name);
        if (book is null)
        {
            Console.WriteLine("Book not found");
        }
        else
        {
            this.GiveBook(pers, book);
        }
    }
    
    public void GiveBook(Reader pers,
                         Book book) => pers.Books.Add(book);
}
