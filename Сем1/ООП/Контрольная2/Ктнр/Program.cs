using ex1;
using ex2;
using ex3;

try
{
    NextList<int> nl = new()
    {
        23,
        2323
    };

    if (nl.Find(23))
    {
        Console.WriteLine("Found");
    }

    Ex2.Run();

    Circ c = new();

    Artist a1 = new("Andrey");
    Artist a2 = new("Dima");
    c.NewYear(a1, a2);
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}
