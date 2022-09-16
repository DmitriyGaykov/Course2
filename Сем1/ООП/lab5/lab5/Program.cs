using lab4;
using lab5;
namespace std;
class Program
{
    public static void Main(string[] args)
    {
        Rose Rose1 = new("Роза Пересмешница", KnownColor.Black, 10);
        Rose Rose2 = new("Роза Краснообразная", KnownColor.Red, 200);
        Rose Rose3 = new("Роза Недоросль", KnownColor.Blue, 3);
        Gladiolus Glad1 = new("Гладиолус лучезарный", KnownColor.DarkBlue, 900);
        Gladiolus Glad2 = new("Гладиолус лунный", KnownColor.Cyan, 700);

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

        #region Additional Exercise 1

        // Доп 1
        // Controller.WriteBouquetToFile(ref Bouquet);

        Console.WriteLine("\n\n\nДоп1\n");
        var newBouquet = Controller.ReadBouquetFromFile();
        Console.WriteLine(newBouquet.ToString());

        #endregion

        #region Additional Exercise 2

        Console.WriteLine("\n\nДоп2\n");
        StructBouquet strBouq = new(Bouquet.AllFlowerIn);

        Controller.WriteBouquetToJson(strBouq);
        var newBouq = Controller.ReadBouquetFromJson();

        Console.WriteLine(newBouq.ToString());

        #endregion
    }

    public struct StructBouquet
    {
        public AFlower[] Flowers { get; set; }
        public int CurrentCount { get; set; }

        public StructBouquet(AFlower[] Flowers)
        {
            this.Flowers = Flowers;
            this.CurrentCount = Flowers.Length;
        }
    }
}