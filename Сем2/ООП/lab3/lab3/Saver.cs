using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Lab1;

static class Saver<T>
    where T : new()
{
    static private string pathToFile = null;
    static private StreamWriter file;
    static public string PathToFile
    {
        get => pathToFile;
        set => pathToFile = value;
    }

    static private string Serialize(ref T obj) => JsonSerializer.Serialize(obj);

    static public void Open(string? path = null)
    {
        if(path is not null)
        {
            PathToFile = path;
        }
        else if(
            path is null &&
            pathToFile is null
            )
        {
            throw new Exception("Не указали файл для открытия");
        }

        file = new StreamWriter(pathToFile, true);
    }

    static public void Close() 
    { 
        file?.Close();
        file = null;
    }

    static public void SaveObject(ref T obj)
    {
        if(file is null)
        {
            throw new Exception("Задайте файл, скоторым будем работать!");
        }

        var json = Serialize(ref obj);
        file.WriteLine(json);
    }
    static public void ClearAll()
    {
        if (file is null) return;
        file = new(pathToFile, false);
        file = new(pathToFile, true);
    }

    static public List<T> GetObjectsFromFile()
    {
        try
        {

            if (pathToFile is null)
            {
                return null;
            }

            List<T> list = new();

            using StreamReader sr = new(pathToFile);
            string str;
            T obj;

            while (!sr.EndOfStream)
            {
                str = sr.ReadLine();
                obj = JsonSerializer.Deserialize<T>(str);

                if (obj is not null)
                {
                    list.Add(obj);
                }
            }

            return list;
        }
        catch
        {
            return new();
        }
    }
}
