using lab3;
namespace Lab1;
internal class Program
{
    public static void Main(string[] argc)
    {
        #region Task 1
        Console.WriteLine("---------------------------Task 1----------------------------------\n\n");
        Set<int> Set1 = new();
        Set<int> Set2 = new();
        Set1.Adds(1, 22, 3, 6, 5, 9, 10);
        Set2 += 4;
        Set2 += 5;
        Set2 += 6;
        Set1 -= 6;
        var Set3 = Set1 * Set2;
        var Set4 = Set3;
        var Set5 = Set1 & Set2;

        Console.WriteLine("Set 1:\n");
        Set1.Print();

        Console.WriteLine("\n\nSet 2:\n");
        Set2.Print();

        Console.WriteLine("\n\nSet 3:\n");
        Set3.Print();

        Console.WriteLine("\n\nSet 4:\n");
        Set4.Print();

        Console.WriteLine("\n\nSet 5:\n");
        Set5.Print();
        Console.WriteLine("\n\n");

        if (Set3 < Set4)
        {
            Console.WriteLine("Set 3 is equaled Set 4");
        }

        if (Set4 > Set1)
        {
            Console.WriteLine("Set 4 is subset of Set 1");
        }
        #endregion

        #region Task 2
        Console.WriteLine("\n\n---------------------Task 2:----------------------------\n");
        string Str = "Hello";
        Console.WriteLine(Str.AddDotToEnd());
        #endregion

        #region Task 3
        Console.WriteLine("\n\n---------------Task 3---------------\n\n");
        Set<int> Set6 = new();
        Set6.Adds(6, -34, 34, 49, 10, 6);

        Console.WriteLine("\n\nSet 6:\n");
        Set6.Print();

        Set6.DellFirst();

        Console.WriteLine("\n\nSet 6 after deleting:\n");
        Set6.Print();

        #endregion

        #region Task 4 | Production and Developer

        Console.WriteLine("\n\n---------------------Task 4:----------------------------\n");
        Console.WriteLine(
            $"Production: {Set<int>.Production.Name}\n" +
            $"ID: {Set<int>.Production.ID}\n\n\n"
            );

        Console.WriteLine(
            $"Developer: {Set<int>.Developer.FIO}\n" +
            $"ID: {Set<int>.Developer.ID}\n" +
            $"Company: {Set<int>.Developer.Division}\n\n\n"
            );


        #endregion

        #region Task 5 | Static Operations

        Console.WriteLine("\n\n---------------------Task 5:----------------------------\n");
        Set<int> Set7 = new();
        Set7.Adds(4, -4, -994, 23, 84, -7, 1, 1, 1);

        Console.WriteLine("\n\nSet 7:\n");
        Set7.Print();
        Console.WriteLine("\n\n");

        Console.WriteLine(
            $"Sum of all elements: {StaticOperations.Sum(Set7)}\n" +
            $"Difference between max and min: {StaticOperations.DiffBetweenMaxAndMin(Set7)}\n" +
            $"Length of Set: {StaticOperations.LengthOfSet(Set7)}\n\n"
            );
        #endregion

    }
}