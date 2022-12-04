namespace lab17;
internal class Book
{
    #region Fields

    private string name;
    private uint count;

    #endregion

    #region Props

    public string? Name
    {
        get => name;
        set => name = value ??
                      "Unknown";
    }

    public uint? Count
    {
        get => count;
        set => count = value ??
                       0;
    }

    #endregion

    #region Ctors

    public Book(string? name,
                uint? count)
    {
        Name = name;
        Count = count;
    }

    public Book()
    {
        this.name = "Unknown";
        this.count = 0;
    }

    #endregion
}
