global using lab4;
global using System.Runtime.Serialization.Formatters.Binary;
global using System.IO;
global using System.Text.Json;
global using System.Xml.Serialization;
global using System.Xml.XPath;
using System.Xml;
using System.Text.Json.Nodes;

namespace lab13;
internal class Program
{

    static void Main(string[] args)
    {
        Tree tree = new("Дуб");

        tree.Plant();

        /* . Из лабораторной №4 выберите класс с наследованием и/или
композицией/агрегацией для сериализации.Выполните
сериализацию/десериализацию объекта используя форматы: 
a.Binary, 
b.SOAP, 
c.JSON, 
d.XML.*/
        try
        {
            CustomSerializer<Tree>.ToBinary(tree);
            CustomSerializer<Tree>.ToJson(tree);
            CustomSerializer<Tree>.ToXML(tree);

            var tree1 = CustomSerializer<Tree>.FromBinary();
            var tree2 = CustomSerializer<Tree>.FromJson();
            var tree3 = CustomSerializer<Tree>.FromXML();

            Console.WriteLine(tree1);
            Console.WriteLine(tree2);
            Console.WriteLine(tree3);

            // ex3

            XmlDocument xml = new();
            xml.Load("Tree.xml");

            var doc = xml.DocumentElement;

            var info = doc.SelectNodes("WasPlanted");

            foreach (XmlNode type in info)
            {
                Console.WriteLine("XML: " + type.InnerText);
            }

            // ex4

            // Используя Linq to XML (или Linq to JSON) создайте новый xml (json) -
            // документ и напишите несколько запросов

            JsonDocument jsonDocument = JsonDocument.Parse(File.ReadAllText("Tree.json"));

            JsonElement root = jsonDocument.RootElement;

            var json = root.GetProperty("WasPlanted");

            Console.WriteLine("Json: " + json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}