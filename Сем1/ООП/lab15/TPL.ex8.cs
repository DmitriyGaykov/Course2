using System.Text.Json;

namespace lab15;
static partial class TPL
{
    public static async Task Ex8()
    {

        List<Product> data = new();

        await Task.Run(() => data = GetProducts());
        Console.WriteLine("-----------Задание 8---------");

        foreach (var product in data)
        {
            Console.WriteLine(product);
        }
    }

    public static List<Product> GetProducts()
    {
        List<Product> list = new();

        using StreamReader sr = new("products.json");
        int cnt = 0;
        string json;
        while(!sr.EndOfStream && cnt++ < 200)
        {
            json = sr.ReadLine() ?? "";
            list.Add(JsonSerializer.Deserialize<Product>(json));
            Thread.Sleep(200);
        }
        
        return list;
    }
}
