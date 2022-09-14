using lab4;
using lab5;
using System.Xml.Linq;

namespace std;

class Program
{
    public static void Main(string[] args)
    {
        Rose Rose1 = new("Роза Пересмешница", Color.Black, 10);
        Rose Rose2 = new("Роза Дикая", Color.Red, 200);
        Rose Rose3 = new("Роза Недоросль", Color.Blue, 3);
        Gladiolus Glad1 = new("Гладиолус лучезарный", Color.DarkBlue, 900);
        Gladiolus Glad2 = new("Гладиолус лунный", Color.Cyan, 700);

        Rose1.Plant();
        Rose2.Plant();
        Rose3.Plant();
        Glad1.Plant();
        Glad2.Plant();

        while (!Rose1.IsGrow() || !Rose2.IsGrow() || !Rose3.IsGrow() || !Glad1.IsGrow() || !Glad2.IsGrow()) ;

        ClassBouquet Bouquet = new();
        Bouquet.AddsFlower(Rose1, Glad1, Glad2, Rose2, Rose3);
        Console.WriteLine("\n\n" + Bouquet.ToString() + "\n\n");

        Controller.SortByPrice(ref Bouquet);

        Console.WriteLine($"После сортировки: \n{Bouquet.ToString()}");

        Console.WriteLine("\n\nВведите цвет расстения:");
        string? repliedColor = Console.ReadLine();

        Controller.FindByColor(ref Bouquet, repliedColor);
    }
}