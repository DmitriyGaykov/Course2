using lab4;
using System.Runtime.Serialization.Json;

namespace lab5;
static class Controller
{
    #region Fields

    private const string PATH = "Bouquet.txt";
    private const string PATH_JSON = "Bouquet.json";

    #endregion

    #region Work with Flowers

    public static void FindByColor(ref ClassBouquet Bouquet, string Color)
    {
        var repliedColorFlowers = Bouquet.AllFlowerIn.Where
        (
            el => el.Color.ToString().ToUpper().Trim() == Color.ToUpper().Trim()
        ).ToArray();

        if (repliedColorFlowers.Length == 0)
        {
            Console.WriteLine("Растения с таким цветом не найдено");
            return;
        }
        else
        {
            foreach (var el in repliedColorFlowers)
            {
                Console.WriteLine(el.ToString() + " ");
            }
        }
    }
    public static void SortByPrice(ref ClassBouquet Bouquet)
    {
        var currFlowers = new AFlower[Bouquet.AllFlowerIn.Length];
        Array.Copy(Bouquet.AllFlowerIn, currFlowers, Bouquet.AllFlowerIn.Length);

        var tmp = currFlowers.OrderBy(el => el.Price).ToArray();
        Array.Copy(tmp, Bouquet.Flowers, tmp.Length);
    }

    #endregion

    #region Work with File

    public static void WriteBouquetToFile(ref ClassBouquet Bouquet)
    {
        using (var sw = new StreamWriter(PATH))
        {
            string Info;
            Info = Bouquet.InfoAbout();
            sw.Write(Info);
        }
    }
    public static ClassBouquet ReadBouquetFromFile()
    {
        using (var sr = new StreamReader(PATH))
        {
            var Bouquet = new ClassBouquet();
            var count = int.Parse(sr.ReadLine());
            Index last = ^1;
            for (var i = 0; i < count; i++)
            {
                var type = sr.ReadLine();
                KnownColor color = new();
                color = (KnownColor)int.Parse(sr.ReadLine());
                var name = sr.ReadLine();
                var price = int.Parse(sr.ReadLine());
                var year = int.Parse(sr.ReadLine());
                var month = int.Parse(sr.ReadLine());
                var day = int.Parse(sr.ReadLine());
                var date = new DateTime(year, month, day);
                switch (type)
                {
                    case "lab4.Rose":
                        Bouquet.AddFlower(new Rose(name, color, price));
                        break;
                    case "lab4.Gladiolus":
                        Bouquet.AddFlower(new Gladiolus(name, color, price));
                        break;
                }
                Bouquet.AllFlowerIn[last].WasPlanted = date;
            }
            return Bouquet;
        }
    }

    #endregion

    #region Work with JSON

    public static void WriteBouquetToJson(std.Program.StructBouquet Bouquet)
    {
        var jsonText = JsonConvert.SerializeObject(Bouquet.CurrentCount);

        for (var i = 0; i < Bouquet.CurrentCount; i++)
        {
            jsonText += "\n" + Bouquet.Flowers[i].GetType();
            jsonText += "\n" + JsonConvert.SerializeObject(Bouquet.Flowers[i]);
        }

        using StreamWriter sw = new(PATH_JSON);
        sw.Write(jsonText);
    }
    public static ClassBouquet ReadBouquetFromJson()
    {
        using StreamReader sr = new(PATH_JSON);
        std.Program.StructBouquet Bouquet = new();
        Bouquet.Flowers = new AFlower[10];
        ClassBouquet result = new();
        var jsonText = sr.ReadLine();

        Bouquet.CurrentCount = int.Parse(jsonText);

        for (var i = 0; i < Bouquet.CurrentCount; i++)
        {
            var type = sr.ReadLine();
            jsonText = sr.ReadLine();

            if (type == "lab4.Rose")
            {
                Bouquet.Flowers[i] = JsonConvert.DeserializeObject<Rose>(jsonText);
            }
            else if (type == "lab4.Gladiolus")
            {
                Bouquet.Flowers[i] = JsonConvert.DeserializeObject<Gladiolus>(jsonText);
            }

            result.AddFlower(Bouquet.Flowers[i]);
        }
        return result;
    }

    #endregion
}

