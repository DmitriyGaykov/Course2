namespace lab17;

static class Library
{
    public static List<Book> Books { get; set; } = new();
    public static Book? GetBook(string Name) => Books.Find(el => el.Name == Name);
}

