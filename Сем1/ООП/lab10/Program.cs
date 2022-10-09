using System.Text;

namespace lab10;

class Program
{
    private static readonly Dictionary<string, TimeOfYear> TimeOf = new()
    {
        {"July", TimeOfYear.Summer},
        {"August", TimeOfYear.Summer},
        {"September", TimeOfYear.Autumn},
        {"October", TimeOfYear.Autumn},
        {"November", TimeOfYear.Autumn},
        {"December", TimeOfYear.Winter},
        {"January", TimeOfYear.Winter},
        {"February", TimeOfYear.Winter},
        {"March", TimeOfYear.Spring},
        {"April", TimeOfYear.Spring},
        {"May", TimeOfYear.Spring},
        {"June", TimeOfYear.Summer}
    };

    static void Main(string[] args)
    {
        // --------------------------Ex1--------------------------
        Console.WriteLine("\n\n\n\n--------------------------Ex1--------------------------\n\n");
        /*. Задайте массив типа string, содержащий 12 месяцев(June, July, May,
December, January ….).Используя LINQ to Object напишите запрос выбирающий
последовательность месяцев с длиной строки равной n, запрос возвращающий
только летние и зимние месяцы, запрос вывода месяцев в алфавитном порядке,
запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4 - х..*/

        string[] month = new string[] { "June",
                                        "July",
                                        "May",
                                        "December",
                                        "January",
                                        "February",
                                        "March",
                                        "April",
                                        "August",
                                        "September",
                                        "October",
                                        "November" };

        /////////////////////////////////////////////////////
        var firstReq = from mon in month
                       where mon.Length == 4
                       select mon;

        Console.WriteLine("First request:");
        Print(firstReq);


        /////////////////////////////////////////////////////
        var secReq = from mon in month
                     where TimeOf[mon] is (TimeOfYear.Summer or TimeOfYear.Winter)
                     select mon;

        Console.WriteLine("Second request:");
        Print(secReq);


        /////////////////////////////////////////////////////
        var thirdReq = from mon in month
                       orderby mon
                       select mon;

        Console.WriteLine("Third request:");
        Print(thirdReq);


        /////////////////////////////////////////////////////
        var fourthReq = from mon in month
                        where mon.Contains("u") && mon.Length >= 4
                        select mon;

        Console.WriteLine("Fourth request:");
        Print(fourthReq);

        // --------------------------Ex2--------------------------
        Console.WriteLine("\n\n\n\n--------------------------Ex2--------------------------\n\n");
        /*Создайте коллекцию List<T> и параметризируйте ее типом(классом)
из лабораторной №2(при необходимости реализуйте нужные интерфейсы).
Заполните ее минимум 10 элементами.
Если в задании указано свойство, которым ваш класс не обладает, то его
нужно расширить, чтобы класс соответствовал условию.Один из запросов
реализуйте используя язык LINQ и используя методы расширения LINQ.*/
        Random rand = new();
        List<Customer> custs = new()
        {
            new(rand.Next(100000, 999999), "Ivanov", "Ivan", "Ivanovich", 100),
            new(rand.Next(100000, 999999), "Petrov", "Petr", "Petrovich", 123),
            new(rand.Next(100000, 999999), "Sidorov", "Sidor", "Sidorovich", 1293),
            new(rand.Next(100000, 999999), "Kuznetsov", "Kuznetsov", "Kuznetsovich", 312),
            new(rand.Next(100000, 999999), "Korenchuk", "Andrey", "Vasilevich", 9875),
            new(rand.Next(100000, 999999), "Kravchenko", "Alexey", "Dmitrievich", 954),
            new(rand.Next(100000, 999999), "Grigorenko", "Daria", "Sergeevna", 94),
            new(rand.Next(100000, 999999), "Avsykevich", "Polina", "Vadimovna", 65),
            new(rand.Next(100000, 999999), "Trubach", "Dmitriy", "Sergeevech", 666),
            new(rand.Next(100000, 999999), "Sever", "Alex", "?", 9132)
        };

        foreach (var cust in custs)
        {
            Console.WriteLine(cust + "\n");
        }

        Console.WriteLine("В алфавитном порядке:");

        var sortedList = from cust in custs
                         orderby cust.Surname
                         select cust;

        Print(sortedList);

        Console.WriteLine("\n\nНомер кредитной карты в интервале");

        int start = 100000;
        int end = 500000;

        var cardList = from cust in custs

                       where cust.CardNumber >= start &&
                             cust.CardNumber <= end

                       select cust;

        Print(cardList);

        Console.WriteLine("\n\nМаксимальный покупатель:");

        var maxCust = from cust in custs
                      orderby cust.Balance descending
                      select cust;

        Console.WriteLine(maxCust.First());

        Console.WriteLine("\n\nПервый пять богатых людей:");

        var maxCustArr = maxCust.ToArray();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(maxCustArr[i]);
        }


        // --------------------------Ex5--------------------------
        Console.WriteLine("\n\n\n\n--------------------------Ex5--------------------------\n\n");

        List<Person> perss = new()
        {
            new("Trubach", "Копейка"),
            new("Kravchenko", "Лукашенская 82"),
            new("Sever", "Свердлова 21"),
        };

        var joinedList = from cust in custs
                         join pers in perss on
                         cust.Surname equals pers.Surname
                         select new
                         {
                             Surname = cust.Surname,
                             Name = cust.Name,
                             CardNumber = cust.CardNumber,
                             Address = pers.Address,
                         };

        foreach (var el in joinedList.ToList())
        {
            Console.WriteLine($"\n\nSurname: {el.Surname}\n" +
                              $"Name: {el.Name}\n" +
                              $"CardNumber: {el.CardNumber}\n" +
                              $"Address: {el.Address}\n");
        }
    }

    private static void Print<T>(IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("\n\n");
    }

    private enum TimeOfYear
    {
        Winter,
        Spring,
        Summer,
        Autumn
    }

    private record Person
    {
        public string Surname { get; set; }
        public string Address { get; set; }

        public Person(string surname,
                      string address)
        {
            Surname = surname;
            Address = address;
        }
    }
}