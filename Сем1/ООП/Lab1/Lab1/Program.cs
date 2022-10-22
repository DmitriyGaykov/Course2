namespace Lab1;
class Program
{
    /*1) Создайте локальную функцию в main и вызовите ее
(https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-andstructs/local-functions ) . Формальные параметры функции – массив 
целых и строка.Функция должна вернуть кортеж, содержащий: 
максимальный и минимальный элементы массива, сумму элементов
массива и первую букву строки.*/

    /*2) Работа с checked/unchecked: (https://docs.microsoft.com/enus/dotnet/csharp/language-reference/keywords/checked-and-unchecked )
a.Определите две локальные функции.
b.Разместите в одной из них блок checked, в котором определите
переменную типа int с максимальным возможным значением
этого типа.Во второй функции определите блок unchecked с
таким же содержимым. 
c.Вызовите две функции.Проанализируйте результат*/
    static void Main(string[] args)
    {
        Console.WriteLine("----Types----");
        Console.WriteLine("\n\nEx Converting");
        Types.Converting();

        Console.WriteLine("\n\nEx BoxingAndUnBoxing");
        Types.BoxingAndUnBoxing();

        Console.WriteLine("\n\nEx Implicit");
        Types.ImplicitValue();

        Console.WriteLine("\n\nEx UseNullable");
        Types.UseNullable();

        Console.WriteLine("\n\nEx Var");
        Types.Var();


        Console.WriteLine("\n\n----String----");

        Console.WriteLine("\n\nEx Equal");
        ExString.EqualsString();

        Console.WriteLine("\n\nEx Null string");
        ExString.NullString();

        Console.WriteLine("\n\nEx String Builder");
        ExString.StringBuilder();

        Console.WriteLine("\n\n----Arrays----");
        Console.WriteLine("\n\nEx A");
        ExArrays.PointA();

        Console.WriteLine("\n\nEx B");
        ExArrays.PointB();

        Console.WriteLine("\n\nEx C");
        ExArrays.PointC();

        Console.WriteLine("\n\nEx D");
        ExArrays.PointD();

        Console.WriteLine("\n\n----Tuples----");

        Console.WriteLine("\n\nEx A");
        Tuples.PointA();

        Console.WriteLine("\n\nEx B");
        Tuples.PointB();

        Console.WriteLine("\n\nEx C");
        Tuples.PointC();

        Console.WriteLine("\n\nEx D");
        Tuples.PointD();

        #region PointA
        (int Max, int Min, int Sum, char FirstLetter) GetInfoAboutArray(int[] Arr, string Str)
        {
            return (Arr.Max(), Arr.Min(), Arr.Sum(), Str[0]);
        }

        int[] Arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        string Str = "Hello";
        var Info = GetInfoAboutArray(Arr, Str);
        #endregion
        #region PointB
        void CheckedFunc()
        {
            checked
            {
                int MaxInt = int.MaxValue;
            }
        }
        int UncheckedFunc()
        {
            unchecked
            {
                int MaxInt = int.MaxValue + 1;
                return MaxInt;
            }
        }
        CheckedFunc();


        Console.WriteLine(UncheckedFunc());
        #endregion
    }
}