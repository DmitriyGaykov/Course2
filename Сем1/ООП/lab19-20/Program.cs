using System.Text;

namespace lab17;

#region Abstract Factory

interface IGenre : IGift
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

    public Gift GiveGift() => new("Кольцо короля замка Хембельтоно");
}

class Detective : IGenre
{
    public string Name { get; set; } = "Detective";
    
    public Detective()
    {
        
    }

    public Detective(string name) => Name = name;

    public Gift GiveGift() => new("Трубка Шерлока Холмса");
}

interface IBook : IPrototype<IBook>
{
    string Name { get; set; }
    IGenre Genre { get; set; }
    uint Count { get; set; }

    string Context { get; set; }

    void GetInfo();
}

class FantasyBook : IBook
{
    public string Name { get; set; } = "Fantasy Book";
    public IGenre Genre { get; set; } = new Fantasy();
    public uint Count { get; set; }

    public string Context { get; set; } = "Fantasy Book Context";

    public void GetInfo() => Console.WriteLine($"Name: {Name},\n" +
                                               $"Genre: {Genre.Name},\n" +
                                               $"Count: {Count}\n");

    public FantasyBook(string name,
                       uint count,
                       IGenre genre)
    {
        Name = name;
        Count = count;
        Genre = genre;
    }

    public IBook Clone() => new FantasyBook(Name.Clone() as string, Count, new Fantasy(Name as string));

    public override string ToString() => Name;
}

class DetectiveBook : IBook
{
    public string Name { get; set; } = "Detective Book";
    public IGenre Genre { get; set; }
    public uint Count { get; set; } = 0;

    public string Context { get; set; } = "Detective Book Context";

    public void GetInfo() => Console.WriteLine($"Name: {Name},\n" +
                                               $"Genre: {Genre.Name},\n" +
                                               $"Count: {Count}\n");

    public DetectiveBook(string name,
                         uint count,
                         IGenre genre)
    {
        Name = name;
        Count = count;
        Genre = genre;
    }
    
    public IBook Clone() => new DetectiveBook(Name as string, Count, new Detective(Name as string));

    public override string ToString() => Name;
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

#region Adapter

interface IBookAdapter
{
    void Info();
}

class BookAdapter : IBookAdapter
{
    private readonly IBook _book;

    public BookAdapter(IBook book) => _book = book;

    public void Info() => _book.GetInfo();
}

#endregion

#region Decorator

abstract class BCD
{
    protected BCD bcd { get; set; }
    public BCD(BCD bcd = null) => this.bcd = bcd;
    public abstract void Decore(IBook book);
}

class Uppper : BCD
{
    public Uppper(BCD bcd = null) : base(bcd) { }

    public override void Decore(IBook book)
    {
        book.Context = book.Context.ToUpper();
        bcd?.Decore(book);
    }
}

class DeleteSpaces : BCD
{
    public DeleteSpaces(BCD bcd = null) : base(bcd) { }

    public override void Decore(IBook book)
    {
        book.Context = book.Context.Replace(" ", "");
        bcd?.Decore(book);
    }
}

class Changer : BCD
{
    public Changer(BCD bcd = null) : base(bcd) { }

    public override void Decore(IBook book)
    {
        book.Context = book.Context.Replace("Е", "е").Replace('И', 'и');
        bcd?.Decore(book);
    }
}

#endregion

#region Command

interface ICommandLibrary
{
    void Execute();
}

class SortBooksByName : ICommandLibrary
{
    private ILibraryBuilder library;
    public void Execute() => library.Books = library.Books.OrderBy(el => el.Name).ToList();

    public SortBooksByName(ILibraryBuilder library) => this.library = library;
}

class SortBooksByGenre : ICommandLibrary
{
    private ILibraryBuilder library;
    public void Execute() => library.Books = library.Books.OrderBy(el => el.Genre.Name).ToList();

    public SortBooksByGenre(ILibraryBuilder library) => this.library = library;
}

class Commander
{
    private List<ICommandLibrary> commands = new();

    public void SetCommand(ICommandLibrary command) => commands.Add(command);

    public void DoCommand(int num) => commands[num].Execute();
}

#endregion

#region Strategy

interface IGift
{
    Gift GiveGift();
}

class Gift
{
    public string Name { get; set; } = "";

    public Gift(string name) => Name = name;

    public override string ToString() => "Подарок: " + Name;
}

// Продолжение в Жанре

#endregion

#region Observer 

interface IObserver
{
    List<IPerson> Persons { get; set; }

    void Observe(string info);
}

interface IObserved
{
    void Observe(string info);
}

#endregion

#region Builder

interface ILibraryBuilder : IPerson, IObserver
{
    uint MaxCount { get; set; }
    ILibrarian Librarian { get; set; }

    void AddBook(IBook book);
}

class Library : ILibraryBuilder
{
    public uint MaxCount { get; set; }
    public string Name { get; set; }
    public List<IBook> Books { get; set; }
    public ILibrarian Librarian { get; set; }
    public List<IPerson> Persons { get; set; } = new();

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
    private void SetBooks(params IBook[] books) => Books = new(books);
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

    public void AddBook(IBook book)
    { 
        Books.Add(book);

        string info = "";

        info = $"Добавлена книга {book}";

        this.Observe(info);
    }

    public void Observe(string info)
    {
        Persons.ForEach(el => el.Observe(info));
    }
}

#endregion

#region Person

interface IPerson : IObserved
{
    string Name { get; set; }
    List<IBook> Books { get; set; }
}

class Person : IPerson
{
    public string Name { get; set; }
    public List<IBook> Books { get; set; }

    public Person(string name) => Name = name;

    public void Observe(string info) => Console.WriteLine($"Dear {Name}.\n{info}");
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
    public List<IBook> Books { get; set; }

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

        var gift = book.Genre.GiveGift();

        Console.WriteLine($"Вы взяли книгу {book.Name}. Плюс ко всему вы получаете подарок {gift} за жанр {book.Genre.Name}\n\n");

        book.Count--;
        return book;
    }

    public void Observe(string info) => Console.WriteLine($"Dear {Name}.\n{info}");

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

    public void Observe(string info) => Console.WriteLine($"Dear {Name}. \n{info}");
}

#endregion

class Program
{
    static void Main()
    {
        var admin = Admin.GetAdmin();
       // admin.ChangeBGColor(ConsoleColor.Red);

        FantasyBookFactory fbf = new();
        DetectiveBookFactory dbf = new();

        IBook fb = fbf.GetBook("Harry Potter", 10, fbf.GetGenre());
        IBook db = dbf.GetBook("Sherlock Holmes", 5, dbf.GetGenre());
        IBook db2 = dbf.GetBook("Nancy Drew", 5, dbf.GetGenre());
        IBook fb2 = fbf.GetBook("Lord of the Rings", 10, fbf.GetGenre());

        ILibrarian librarian = new Librarian("John Doe");

        ILibraryBuilder library = Library.CreateLibrary(15, "Library 1", librarian, fb, db);
        library.Persons.Add(librarian);

        library.AddBook(db2);
        library.AddBook(fb2);
        

        librarian.GiveBook("Harry Potter");

        Console.WriteLine("Books in library:");
        foreach (var book in library.Books)
        {
            Console.WriteLine(book.Name);
        }
        Console.WriteLine("\n\n\n");

        IBookAdapter adapter = new BookAdapter(fb);

        adapter.Info();

        fb.Context = "Жили были не тужили";

        BCD decorator = new Uppper(new DeleteSpaces(new Changer()));

        decorator.Decore(fb);

        Console.WriteLine(fb.Context);

        Console.WriteLine("\n\n\n");

        Commander commander = new();
        
        ICommandLibrary sortByName = new SortBooksByName(library);
        ICommandLibrary sortByGenre = new SortBooksByGenre(library);

        commander.SetCommand(sortByName);
        commander.SetCommand(sortByGenre);

        commander.DoCommand(0);

        Console.WriteLine("Books in library after command:");
        foreach (var book in library.Books)
        {
            Console.WriteLine(book.Name);
        }
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