namespace lab17;

#region Abstract Factory

interface IGenre
{
    string Name { get; set; }
}

class Fantasy : IGenre
{
    public string Name { get; set; } = "Fantasy";

    public Fantasy()
    {
            
    }

    public Fantasy(string name) => Name = name;
}

class Detective : IGenre
{
    public string Name { get; set; } = "Detective";
    
    public Detective()
    {
        
    }

    public Detective(string name) => Name = name;
}

interface IBook : IPrototype<IBook>
{
    string Name { get; set; }
    IGenre Genre { get; set; }
    uint Count { get; set; }
}

class FantasyBook : IBook
{
    public string Name { get; set; } = "Fantasy Book";
    public IGenre Genre { get; set; } = new Fantasy();
    public uint Count { get; set; }

    public FantasyBook(string name,
                       uint count,
                       IGenre genre)
    {
        Name = name;
        Count = count;
        Genre = genre;
    }

    public IBook Clone() => new FantasyBook(Name.Clone() as string, Count, new Fantasy(Name as string));
}

class DetectiveBook : IBook
{
    public string Name { get; set; } = "Detective Book";
    public IGenre Genre { get; set; }
    public uint Count { get; set; } = 0;

    public DetectiveBook(string name,
                         uint count,
                         IGenre genre)
    {
        Name = name;
        Count = count;
        Genre = genre;
    }
    
    public IBook Clone() => new DetectiveBook(Name as string, Count, new Detective(Name as string));
}

interface IBookFactory
{
    IGenre GetGenre();

    IBook GetBook(string name,
                  uint count,
                  IGenre genre);
}

class DetectiveBookFactory : IBookFactory
{
    public IGenre GetGenre() => new Detective();
    
    public IBook GetBook(string name,
                         uint count,
                         IGenre genre) => new DetectiveBook(name, count, genre);
}

class FantasyBookFactory : IBookFactory
{
    public IGenre GetGenre() => new Fantasy();

    public IBook GetBook(string name,
                         uint count,
                         IGenre genre) => new FantasyBook(name, count, genre);
}

#endregion

#region Builder

interface ILibraryBuilder
{
    public uint MaxCount { get; set; }
    public string Name { get; set; }
    public ILibrarian Librarian { get; set; }
    List<IBook> Books { get; set; }
}

class Library : ILibraryBuilder
{
    public uint MaxCount { get; set; }
    public string Name { get; set; }
    public List<IBook> Books { get; set; }
    public ILibrarian Librarian { get; set; }

    private Library() { }
    private Library(uint count,
                    string name,
                    ILibrarian librarian,
                    params IBook[] books)
    {
        this.SetMaxCount(count);
        this.SetName(name);
        this.SetLibrarian(librarian);
        this.SetBooks(books);
    }

    private void SetMaxCount(uint count) => MaxCount = count;
    private void SetName(string name) => Name = name;
    private void SetBooks(params IBook[] books) => Books = new List<IBook>(books);
    private void SetLibrarian(ILibrarian librarian)
    { 
        Librarian = librarian;
        Librarian.Library = this;
    }

    public static Library CreateLibrary(uint count,
                                        string name,
                                        ILibrarian librarian,
                                        params IBook[] books)
    {
        return new Library(count, name, librarian, books);
    }
}

#endregion

#region Person

interface IPerson
{
    string Name { get; set; }
}

#endregion

#region Librarian

interface ILibrarian : IPerson
{
    ILibraryBuilder Library { get; set; }
    IBook GiveBook(string name);
}

class Librarian : ILibrarian
{
    public string Name { get; set; } = "Unknown";
    public ILibraryBuilder Library { get; set; }
    public IBook GiveBook(string name)
    {
        var book = Library.Books.Find(el => el.Name == name);
        if (book is null)
        {
            Console.WriteLine("Book not found");
            return null;
        }

        if (book.Count == 0)
        {
            Console.WriteLine("Book is not available");
            return null;
        }

        book.Count--;
        return book;
    }

    public Librarian(string name)
    {
        Name = name;
    }

    public Librarian()
    {
        this.Name = "Unknown";
    }
    
    
}

#endregion

#region Reader

interface IReader : IPerson
{
    List<IBook> Books { get; set; }
    void TakeBook(ILibrarian librarian,
                  string name);
}

class Reader : IReader
{
    public string Name { get; set; } = "Unknown";
    public List<IBook> Books { get; set; } = new List<IBook>();

    public Reader(string name)
    {
        Name = name;
    }

    public Reader()
    {
        this.Name = "Unknown";
    }

    public void TakeBook(ILibrarian librarian,
                         string name)
    {
        var book = librarian.GiveBook(name);
        if (book is not null)
        {
            Books.Add(book);
        }
    }
}

#endregion

class Program
{
    static void Main()
    {
        var admin = Admin.GetAdmin();
        admin.ChangeBGColor(ConsoleColor.Red);

        FantasyBookFactory fbf = new();
        DetectiveBookFactory dbf = new();

        IBook fb = fbf.GetBook("Harry Potter", 10, fbf.GetGenre());
        IBook db = dbf.GetBook("Sherlock Holmes", 5, dbf.GetGenre());

        ILibrarian librarian = new Librarian("John Doe");

        ILibraryBuilder library = Library.CreateLibrary(15, "Library 1", librarian, fb, db);

        IReader reader = new Reader("Jane Doe");

        reader.TakeBook(librarian, "Harry Potter");

        db.Name = "Book 1";
        IBook nb = db.Clone();
        nb.Name = "Book 2";
        nb.Genre.Name = "Detectfffive";
        
        Console.WriteLine($"First book:\n" +
                          $"Name: {db.Name}\n" +
                          $"Count: {db.Count}\n" +
                          $"Genre: {db.Genre.Name}\n");

        Console.WriteLine($"Second book:\n" +
                          $"Name: {nb.Name}\n" +
                          $"Count: {nb.Count}\n" +
                          $"Genre: {nb.Genre.Name}\n");
    }
}

#region Admin

class Admin
{
    public static string Name { get; set; }
    private static Admin admin = null;
    private Admin() { }

    static Admin()
    {
        if (admin is null)
        {
            admin = new Admin();
        }
    }

    public static Admin GetAdmin() => admin;

    public void ChangeBGColor(ConsoleColor color) => Console.BackgroundColor = color;

    // Изменить шрифт консоли

    public void ChangeFontColor(ConsoleColor color) => Console.ForegroundColor = color;

    // Изменить размер консоли

    public void ChangeConsoleSize(int width, int height) => Console.SetWindowSize(width, height);

    // Изменить заголовок консоли

    public void ChangeConsoleTitle(string title) => Console.Title = title;

    // Изменить курсор консоли

    public  void ChangeCursorSize(int size) => Console.CursorSize = size;

    // Изменить видимость курсора

    public void ChangeCursorVisibility(bool visibility) => Console.CursorVisible = visibility;

    // Изменить позицию курсора

    public void ChangeCursorPosition(int x, int y) => Console.SetCursorPosition(x, y);

}

#endregion

#region Prototype

interface IPrototype<T>
{
    T Clone();
}

#endregion