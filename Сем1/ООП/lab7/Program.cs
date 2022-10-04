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
            Gladiolus Glad2 = new("Гладиоус необычный");
            Gladiolus Glad3 = new("Аргументированный гладиолус");

            Set1.Adds(Glad1, Glad2, Glad3);

            Set1.ToFile();
            var Set2 = Set1.FromFile();

            Set<int> sNums = new();
            sNums.Adds(2, 3, 45, -23);

            Set2.Print();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("\n\n\nНажмите любую клавишу для выхода...................");
            Console.ReadKey();
        }
    }
}