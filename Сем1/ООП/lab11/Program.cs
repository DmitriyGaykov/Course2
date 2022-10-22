global using lab8;

namespace lab11;

class Program
{
    public static void Main(string[] args)
    {
        Headmaster Dima = new("Дима");
        Person Alex = new("Саша");

        Reflector.KnowInfo(typeof(Headmaster));
        Reflector.KnowMethodsByParameter(typeof(Headmaster),
                                         typeof(string));
        Reflector.ClearFile();
        Reflector.ToFile();

        Reflector.Invoke(typeof(Headmaster),
                         Dima,
                         "TestHeadmaster");


        Reflector.Invoke(typeof(Headmaster),
                         Dima,
                         "TestHeadmaster",
                         "Hello World!");

        Reflector.KnowInfo(typeof(Person));
        Reflector.KnowMethodsByParameter(typeof(Person),
                                         typeof(string));

        Reflector.ToFile();
        Reflector.KnowInfo(typeof(DriveInfo));
        Reflector.KnowMethodsByParameter(typeof(DriveInfo),
                                         typeof(string));

        Reflector.ToFile();

        var _dt = Reflector.Create<DateTime>(12, 12, 12);

        _dt.AddHours(12);

        Console.WriteLine($"_dt = {_dt},\n");
    }

}