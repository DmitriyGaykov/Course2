using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab9;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine($"\n\n--------------------------------Exersize 1--------------------------------\n\n");
            Hashtable<string, string> HT = new();

            HT["Дима"] = "Dima";
            HT["Олег"] = "Oleg";
            HT["вася"] = "vasya";
            HT["ясав"] = "yasav";


            Employee Emp1 = new("Dima",
                                "ITechArt",
                                12);

            Employee Emp2 = new("Petya",
                                "LeverX",
                                14);

            Employee Emp3 = new("Olya",
                                "ITechArt",
                                22);

            Console.WriteLine($"Ключ Дима: {HT["Дима"]}\n"
                            + $"Ключ Олег: {HT["Олег"]}\n"
                            + $"Ключ вася: {HT["вася"]}\n"
                            + $"Ключ ясав: {HT["ясав"]}\n");

            Console.WriteLine($"\n\n--------------------------------Exersize 2--------------------------------\n\n");

            Hashtable<Employee, int> Salaries = new();

            Salaries[Emp1] = 300;
            Salaries[Emp2] = 400;
            Salaries[Emp3] = 500;

            Queue<int> q = new();
            var values = Salaries.ToArray();
            q.Push(values);

            Console.WriteLine("Очередь: ");
            q.Print();

            while (q.Length != 0)
            {
                Console.Write(q.Front() == 300 ? "\n\nДима" : "");
                q.Pop();
            }

            Console.WriteLine($"\n\n--------------------------------Exersize 3--------------------------------\n\n");
            // Создайте объект наблюдаемой коллекции ObservableCollection<T>. Создайте 
            /*произвольный метод и зарегистрируйте его на событие CollectionChange. 
             Напишите демонстрацию с добавлением и удалением элементов.В качестве
             типа T используйте свой класс из таблицы.*/


            ObservableCollection<Employee> Employees = new();
            Employees.CollectionChanged += CollectionChange;
            Employees.Add(Emp2);
            Employees.Add(Emp3);
            Employees.Remove(Emp2);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void CollectionChange(object sender,
                                         NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                Console.WriteLine("Добавлен новый элемент");
                break;
            case NotifyCollectionChangedAction.Remove:
                Console.WriteLine("Удален элемент");
                break;
        }
    }
}
