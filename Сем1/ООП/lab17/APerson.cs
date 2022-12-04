namespace lab17;
abstract class APerson
{
    #region Fields

    protected string name;
    protected List<Book> books;

    #endregion

    #region Props

    public string? Name
    {
        get => name;
        set => name = value ??
                      "Unknown";
    }

    public List<Book>? Books
    {
        get => books;
        set => books = value ??
                       new();
    }

    #endregion

    #region Constructors
    
    public APerson(string? name,
                   List<Book>? books)
    {
        Name = name;
        Books = books;
    }
    
    public APerson()
    {
        this.name = "Unknown";
        this.books = new();
    }
    
    #endregion
}
