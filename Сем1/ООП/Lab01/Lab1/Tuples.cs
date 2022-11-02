namespace Lab1;
static class Tuples
{
    #region PointA
    // Задайте кортеж из 5 элементов с типами int, string, char, string, 
    // ulong
    public static void PointA()
    {
        Console.WriteLine("Point A");
        (int, string, char, string, ulong) tuple = (1, "2", '3', "4", 5);
        Console.WriteLine(tuple);
    }
    #endregion
    #region PointB
    /*Выведите кортеж на консоль целиком и выборочно(например 1,
3, 4 элементы)*/
    public static void PointB()
    {
        Console.WriteLine("\nPoint B");
        (int, string, char, string, ulong) tuple = (1, "2", '3', "4", 5);
        Console.WriteLine(tuple);
        Console.WriteLine(tuple.Item1);
        Console.WriteLine(tuple.Item3);
        Console.WriteLine(tuple.Item4);
    }
    #endregion
    #region PointC
    /*Выполните распаковку кортежа в переменные.
Продемонстрируйте различные способы распаковки кортежа.
Продемонстрируйте использование переменной(_ ). (доступно
начиная с C#7.3)*/
    public static void PointC()
    {
        Console.WriteLine("\nPoint C");
        (int Age, string, char, string, ulong) tuple = (1, "2", '3', "4", 5);
        var (a, b, c, d, e) = tuple;
        Console.WriteLine($"{a} {b} {c} {d} {e}");

        (int, string, char, string, ulong) tuple2 = (1, "2", '3', "4", 5);
        var (a2, _, c2, d2, _) = tuple2;
        Console.WriteLine($"{a2} {c2} {d2}");

        a = tuple.Age;
    }
    #endregion
    #region PointD
    // Сравните два кортежа.
    public static void PointD()
    {
        Console.WriteLine("\nPoint D");
        (int, string, char, string, ulong) tuple = (1, "2", '3', "4", 5);
        (int, string, char, string, ulong) tuple2 = (1, "2", '3', "4", 5);
        Console.WriteLine(tuple == tuple2);
    }
    #endregion
}