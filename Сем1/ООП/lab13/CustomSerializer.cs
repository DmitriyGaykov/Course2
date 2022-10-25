using System.Runtime.Serialization;

namespace lab13;

static class CustomSerializer<T> 
{
    public static void ToBinary(T obj)
    {
        BinaryFormatter bForm = new();
        using (FileStream sr = new(obj.GetType().Name + ".bin", FileMode.OpenOrCreate))
        {
            bForm.Serialize(sr, obj);
        }
    }

    public static object FromBinary()
    {
        BinaryFormatter bForm = new();
        T? obj;
        using (FileStream sr = new(typeof(T).Name + ".bin", FileMode.Open))
        {
            obj = (T)bForm.Deserialize(sr);
        }
        return obj;
    }

    public static void ToJson(T obj)
    {
        var textJson = JsonSerializer.Serialize(obj);

        using (StreamWriter sr = new($"{obj.GetType().Name}.json"))
        {
            sr.Write(textJson);
        }
    }

    public static object FromJson()
    {
        T? obj;
        using (StreamReader sr = new($"{typeof(T).Name}.json"))
        {
            obj = JsonSerializer.Deserialize<T>(sr.ReadToEnd());
        }
        return obj;
    }

    public static void ToXML(T obj)
    {
        XmlSerializer xmlSerializer = new(typeof(T));
        using (FileStream sr = new($"{obj.GetType().Name}.xml", FileMode.OpenOrCreate))
        {
            xmlSerializer.Serialize(sr, obj);
        }
    }

    public static object FromXML()
    {
        T? obj;
        XmlSerializer xmlSerializer = new(typeof(T));
        using (FileStream sr = new($"{typeof(T).Name}.xml", FileMode.Open))
        {
            obj = (T)xmlSerializer.Deserialize(sr);
        }
        return obj;
    }

    static CustomSerializer()
    {
        XmlAttributeOverrides overrides = new XmlAttributeOverrides();
        XmlAttributes attribs = new XmlAttributes();
        attribs.XmlIgnore = true;
        attribs.XmlElements.Add(new XmlElementAttribute("Surname"));
        overrides.Add(typeof(Tree), "Surname", attribs);
    }
}
