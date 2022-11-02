namespace Lab2;
/*
2) Создайте несколько объектов вашего типа.Выполните вызов
конструкторов, свойств, методов, сравнение объекты, проверьте тип
созданного объекта и т.п.
3) Создайте массив объектов вашего типа.И выполните задание, 
выделенное курсивом в таблице.
a) список покупателей в алфавитном порядке;
b) список покупателей, у которых номер кредитной карточки 
находится в заданном интервале.
4) Создайте и выведите анонимный тип(по образцу вашего класса).
5) Ответьте на вопросы, приведенные ниже
*/
class Lab2
{
    public static void Main(string[] argc)
    {
        #region Ex2
        Customer User1 = new();
        uint AmountUs1;
        string InfoUs1;
        (User1.Name, User1.Surname, User1.MiddleName, User1.CardNumber) = ("Иван", "Иванов", "Иванович", 126578);
        User1.TopUpBalance(out AmountUs1);
        InfoUs1 = User1.ToString();
        Console.WriteLine(InfoUs1);

        Customer User2 = new("Петр", "Петров", "Петрович");
        User2.CardNumber = 100456;
        uint AmountUs2 = User2.Balance;
        string InfoUs2;
        User2.WithdrawBalance(ref AmountUs2);
        InfoUs2 = User2.ToString();
        Console.WriteLine(InfoUs2);

        Customer User3 = new(956732, "Сидор", "Сидоров", "Сидорович", 930);
        Customer User4 = new(784100, "Андрей", "Андреев", "Андреевич", 1000);

        // Проверка типа объекта:
        Console.WriteLine($"Тип данных User1: {User1.GetType()}");

        // Сравнение объектов:
        Console.WriteLine($"User1 == User2: {User1.Equals(User2)}");
        #endregion

        #region Ex3
        Console.WriteLine("\n\nЗадание 2:\nВывод данных о клиентах:");
        Customer[] Customers = new Customer[4] { User1, User2, User3, User4 };

        //Вывод данных о массиве:
        GetInfo(ref Customers);

        //Сортировка массива:
        Customers = Customers.OrderBy(x => x.Surname).ToArray();
        Console.WriteLine("После сортировки:");
        GetInfo(ref Customers);

        //Список клиентов, у которых номер находится в заданном интервале:
        Console.WriteLine("\n\nСписок клиентов, у которых номер находится в заданном интервале:");
        GetInfo(ref Customers, 100000, 200000);
        #endregion

        #region Ex4
        Console.WriteLine("\n\nЗадание 4:\nАнонимный тип:");
        var User5 = new { Name = "Антон", Surname = "Антонов", MiddleName = "Антонович", CardNumber = 100000 };
        Console.WriteLine($"Имя: {User5.Name}\nФамилия: {User5.Surname}\nОтчество: {User5.MiddleName}\nНомер карты: {User5.CardNumber}");
        #endregion
    }

    public static void GetInfo(ref Customer[] Customers)
    {
        foreach (Customer Customer in Customers)
        {
            Console.WriteLine(Customer.ToString());
        }
    }
    public static void GetInfo(ref Customer[] Customers, int Start, int End)
    {
        foreach (Customer Customer in Customers.Where(El => El.CardNumber >= Start && El.CardNumber <= End))
        {
            Console.WriteLine(Customer.ToString());
        }
    }
}