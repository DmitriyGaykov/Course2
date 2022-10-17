using Контрольная1;

namespace ex1;
class Program
{
    public static void Main(string[] args)
    {
        // ex1

        Console.WriteLine(float.MaxValue);

        int[][] matrix = new int[2][];
        matrix[0] = new int[3] { 1, 2, 3 };
        matrix[1] = new int[5] { 1, 2, 3, 4, 5 };

        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }

        // ex2

        Plant plant1 = new("Ягоды",
                           KnownColor.RebeccaPurple);

        Plant plant2 = new("Ягоды",
                           KnownColor.Pink);

        Console.WriteLine(plant1 + "\n"
                        + plant2);

        Console.WriteLine($"plant1 == plant2 = {plant1 == plant2}");

        //  ex3

        Flower fl1 = new("Цветок",
                         KnownColor.Plum);

        IWater ref1 = plant1;
        IWater ref2 = fl1;

        ref2.WaterPlant();
        ((Plant)ref2).WaterPlant();

    }
}