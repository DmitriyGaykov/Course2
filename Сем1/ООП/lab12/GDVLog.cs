using System.Data;
using System.Text.Json;

namespace lab12;
static class GDVLog
{
    private const string logfile = "gdvlogfile.json";

    public static void Write(string? name,
                             string? action)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (action is null)
        {
            throw new ArgumentNullException(nameof(action));
        }

        // --------------------------------------------------

        Data data = new(DateTime.Now, name, action);
        using StreamWriter writer = new(logfile, true);
        var textJson = JsonSerializer.Serialize(data);
        writer.WriteLine(textJson);
    }

    public static List<Data> Read()
    {
        using StreamReader reader = new(logfile);

        if (reader is null)
        {
            throw new ArgumentNullException(nameof(reader));
        }

        List<Data> data = new();
        Data dataJson;

        while (!reader.EndOfStream)
        {
            var textJson = reader.ReadLine();

            if (string.IsNullOrWhiteSpace(textJson))
            {
                continue;
            }

            dataJson = JsonSerializer.Deserialize<Data>(textJson);
            data.Add(dataJson);
        }

        return data;
    }

    public static List<Data> Find(DateTime? dt)
    {
        if (dt is null)
        {
            throw new ArgumentNullException(nameof(dt));
        }

        var data = Read();

        return data.Where(el => el.DT == dt).ToList();
    }

    public static List<Data> Find(DateTime? sDt,
                                  DateTime? eDt)
    {
        if (sDt is null)
        {
            throw new ArgumentNullException(nameof(sDt));
        }
        if (eDt is null)
        {
            throw new ArgumentNullException(nameof(eDt));
        }

        var data = Read();

        return data.Where(el => el.DT >= sDt && el.DT <= eDt).ToList();
    }
}

internal struct Data
{
    public DateTime DT { get; set; }
    public string Action { get; set; }
    public string Name { get; set; }

    public Data(DateTime dt,
                string action,
                string name)
    {
        DT = dt;
        Action = action;
        Name = name;
    }

    public override string ToString() => $"{DT} {Action} {Name}";
}