
namespace ex2;

static class Ex2
{
    public static void Run()
    {
        string[] arrStr = new string[]
        {
            "andrey",
            "dima",
            "igor",
            "ivan",
            "kolya",
            "misha",
            "oleg",
            "zay"
        };

        var cnt = arrStr.Where(el => el.First() is ('a' or 'A' or 'z' or 'Z')).ToList().Count;

        Console.WriteLine(cnt);
    }
}
