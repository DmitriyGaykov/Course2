namespace Lab1;
class ExArrays
{
    #region PointA
    // Создайте целый двумерный массив и выведите его на консоль в отформатированном виде(матрица).
    public static void PointA()
    {
        Console.WriteLine("Point A");
        int[,] Arr = new int[2, 3];

        FillArray(ref Arr);
        OutArr(ref Arr);
    }

    private static void FillArray(ref int[,] Arr)
    {
        for (int i = 0, M = 0; i < Arr.GetLength(0); i++)
        {
            for (var j = 0; j < Arr.GetLength(1); j++)
            {
                Arr[i, j] = M++;
            }
        }
    }
    private static void OutArr(ref int[,] Arr)
    {
        for (var i = 0; i < Arr.GetLength(0); i++)
        {
            for (var j = 0; j < Arr.GetLength(1); j++)
            {
                Console.Write($"{Arr[i, j]}\t");
            }
            Console.WriteLine("");
        }
    }
    #endregion
    #region PointB
    /*Создайте одномерный массив строк.Выведите на консоль его
содержимое, длину массива. Поменяйте произвольный элемент
(пользователь определяет позицию и значение).*/
    public static void PointB()
    {
        Console.WriteLine("\nPoint B\n");
        int[] Arr = new int[10];
        int RepIndex;
        int NewVal;
        FillArray(ref Arr);
        OutArr(ref Arr);
        (RepIndex, NewVal) = GetRepIndex();

        Arr[RepIndex] = NewVal;
        OutArr(ref Arr);
    }
    private static void FillArray(ref int[] Arr)
    {
        for (var i = 0; i < Arr.Length; i++)
        {
            Arr[i] = i + 1;
        }
    }
    private static void OutArr(ref int[] Arr)
    {
        Console.WriteLine($"\nLength: {Arr.Length}");
        foreach (var el in Arr)
            Console.Write($"{el}\t");
        Console.WriteLine("");
    }
    private static (int, int) GetRepIndex()
    {
        string? MaskInd,
                MaskNewVal;
        int Index;
        int NewVal;
        // Init Index
        do
        {
            Console.WriteLine("Введите индекс элемента: ");
            MaskInd = Console.ReadLine();
        } while (!int.TryParse(MaskInd, out var number) || int.Parse(MaskInd) > 9);
        Index = int.Parse(MaskInd);
        // Init NewVal
        do
        {
            Console.WriteLine("Введите новое значение: ");
            MaskNewVal = Console.ReadLine();
        } while (!int.TryParse(MaskNewVal, out var number));
        NewVal = int.Parse(MaskNewVal);
        return (Index, NewVal);
    }
    #endregion
    #region PointC
    /*
     Создайте ступечатый (не выровненный) массив вещественных
чисел с 3-мя строками, в каждой из которых 2, 3 и 4 столбцов
соответственно. Значения массива введите с консоли.
     */
    public static void PointC()
    {
        float[][] Arr = new float[3][];
        CreateArray(ref Arr);
        OutArr(ref Arr);
    }
    private static void CreateArray(ref float[][] Arr)
    {
        Arr[0] = new float[2];
        Arr[1] = new float[3];
        Arr[2] = new float[4];
        for (var i = 0; i < Arr.Length; i++)
        {
            FillArray(ref Arr[i]);
        }
    }
    private static void FillArray(ref float[] Arr)
    {
        float M = 0.0f;
        for (var i = 0; i < Arr.Length; i++)
        {
            Arr[i] = M;
            M += 0.24f;
        }
    }
    private static void OutArr(ref float[][] Arr)
    {
        for (var i = 0; i < Arr.Length; i++)
        {
            Console.WriteLine("");
            for (var j = 0; j < Arr[i].Length; j++)
            {
                Console.Write($"{Arr[i][j]}\t");
            }
        }
    }
    #endregion
    #region PointD
    /*Создайте неявно типизированные переменные для хранения
массива и строки.*/
    public static void PointD()
    {
        var Arr = new[] { 1, 2, 3, 4, 5 };
        var Str = "Hello World!";
        Console.WriteLine($"\n{Str}");
        foreach (var el in Arr)
            Console.Write($"{el}\t");
    }
    #endregion
}
