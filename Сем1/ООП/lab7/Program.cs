using lab4;
namespace lab7;
class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Set<Gladiolus> Set1 = new();
            Gladiolus Glad1 = new("Гладиоус лучезарный");
            Gladiolus Glad2 = new("Глаиоус необычный");
            Set1.Adds(Glad1, Glad2);
            Set1.ToFile();
            var Set2 = Set1.FromFile();
            Set2.Print();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Нажмите любую клавишу для выхода");
            Console.ReadKey();
        }
    }
}