namespace Lab1;
static class Types
{
    #region Variables
    public static int IntValue { get; set; } = 0;
    public static double DoubleValue { get; set; } = 0.0;
    public static string StringValue { get; set; } = "267";
    public static bool BoolValue { get; set; } = false;
    public static char CharValue { get; set; } = ' ';
    public static float FloatValue { get; set; } = 0.0f;
    public static long LongValue { get; set; } = 0;
    public static short ShortValue { get; set; } = 0;
    public static byte ByteValue { get; set; } = 0;
    public static decimal DecimalValue { get; set; } = 0.0m;
    #endregion
    #region Convert
    public static void Converting()
    {
        #region Explicit

        DoubleValue = (double)IntValue;
        Console.WriteLine($"Explicit conversion from int to double: {DoubleValue}");

        StringValue = Convert.ToString(IntValue);
        Console.WriteLine($"Explicit conversion from int to string: {StringValue}");

        BoolValue = Convert.ToBoolean(IntValue);
        Console.WriteLine($"Explicit conversion from int to bool: {BoolValue}");

        CharValue = Convert.ToChar(IntValue);
        Console.WriteLine($"Explicit conversion from int to char: {CharValue}");

        FloatValue = Convert.ToSingle(IntValue);
        Console.WriteLine($"Explicit conversion from int to float: {FloatValue}");
        #endregion
        #region Implicit

        IntValue = ShortValue;
        Console.WriteLine($"Implicit conversion from short to int: {IntValue}");

        IntValue = ByteValue;
        Console.WriteLine($"Implicit conversion from byte to int: {IntValue}");

        IntValue = CharValue;
        Console.WriteLine($"Implicit conversion from char to int: {IntValue}");

        LongValue = IntValue;
        Console.WriteLine($"Implicit conversion from int to long: {LongValue}");

        FloatValue = IntValue;
        Console.WriteLine($"Implicit conversion from int to float: {FloatValue}");
        #endregion
    }
    #endregion
    #region BoxingAndUnBoxing
    // Выполните упаковку и распаковку значимых типов.
    public static void BoxingAndUnBoxing()
    {
        // Упаковка
        object Obj = IntValue;
        Console.WriteLine($"Boxing: {Obj}");
        // Распаковка
        IntValue = (int)Obj;
        Console.WriteLine($"Unboxing: {IntValue}");
    }
    #endregion
    #region ImplicitValue
    // Продемонстрируйте работу с неявно типизированной переменной.
    public static void ImplicitValue()
    {
        var ImplicitValue = 10;
        Console.WriteLine($"Implicit value: {ImplicitValue}");
    }
    #endregion
    #region Nullable
    private struct Datas
    {
        public Datas() => this.Name = "Dima";

        public string Name { get; set; }
        public int? Age { get; set; } = null;
    }
    public static void UseNullable()
    {
        int? Age;
        string? Name;

        Datas Data = new();
        Age = Data.Age;
        Name = Data.Name;

        Console.WriteLine($"Nullable: {Age ?? 0} {Name ?? "No name"}");
    }
    #endregion
    #region Var
    /*Определите переменную типа var и присвойте ей любое
значение.Затем следующей инструкцией присвойте ей значение
другого типа.Объясните причину ошибки.*/
    public static void Var()
    {
        var Var = 10;
        Console.WriteLine($"Var: {Var}");
        // Var = "Hello";
    }
    #endregion
}