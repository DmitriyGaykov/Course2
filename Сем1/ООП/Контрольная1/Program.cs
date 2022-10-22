using Контрольная1;

namespace ex1;
class Program
{
    public static void Main(string[] args)
    {
        string str = Console.ReadLine() ?? "default";
        string last = str[str.Length - 1].ToString();

        str += last;
        Console.WriteLine(str);

        /* задан двумерный массив целых чисел
 проинициализируйте его
 посчитайте общее число положительных*/


        int[,] matr = new int[3, 3]
        {

            { 1, -2, 3 },
            { 4, 5, -6 },
            { 7, 8, 9 }
        };

        int count = 0;

        for (int i = 0; i < matr.GetLength(0); i++)
        {
            for (int j = 0; j < matr.GetLength(1); j++)
            {
                if (matr[i, j] >= 0)
                {
                    count++;
                }
            }
        }

        Console.WriteLine("Количество положительных  = " + count);

        Bag bag1 = new Bag(12, "Bag 1");
        Bag bag2 = new Bag(23, "Bag 2");


        // Сравнение объектов
        Console.WriteLine(bag1.CompareTo(bag2));

        // обнуление суммы
        Console.WriteLine(bag1.Sum);
        bag1.NullSum();
        Console.WriteLine(bag1.Sum);
        // сравнение объектов


    }
}

// класс расширений
static class Extention
{
    // метод расширения
    public static void NullSum(this Bag bag) => bag.Sum = 0;
}