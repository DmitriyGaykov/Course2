using System.Reflection;
namespace lab11;
static class Reflector
{
    private static string Info { get; set; } = String.Empty;
    private const string PATH = "info.txt";

    static Reflector()
    {
        KnowInfo += KnowNameOfAssembly;
        KnowInfo += KnowPublicConstructors;
        KnowInfo += KnowPublicMethods;
        KnowInfo += KnowFieldsAndProperties;
        KnowInfo += KnowInterfaces;
    }

    public static Action<Type> KnowInfo;

    // Определение имени сборки, в которой определен класс;
    public static void KnowNameOfAssembly(Type type)
    {
        Info = String.Empty;
        Info += type.Assembly.FullName + "\n\n";
        Console.WriteLine("Имя сборки, в которой определен класс: " + type.Assembly.FullName + "\n");
    }

    // есть ли публичные конструкторы;

    public static void KnowPublicConstructors(Type type)
    {
        Console.WriteLine("Публичные конструкторы: ");
        Info += "Публичные конструкторы\n";

        foreach (var constructor in type.GetConstructors())
        {
            Console.WriteLine(constructor);
            Info += constructor + "\n";
        }
        Info += "\n\n";
        Console.WriteLine("\n");
    }

    // извлекает все общедоступные публичные методы класса
    // (возвращает IEnumerable<string>);

    public static void KnowPublicMethods(Type type)
    {
        Console.WriteLine("Публичные методы: ");
        Info += "Публичные методы\n";

        foreach (var method in type.GetMethods())
        {
            Console.WriteLine(method);
            Info += method + "\n";
        }

        Console.WriteLine("\n");
        Info += "\n\n";
    }

    // получает информацию о полях и свойствах класса (возвращает
    // IEnumerable<string>);

    public static void KnowFieldsAndProperties(Type type)
    {
        Console.WriteLine("Поля и свойства: ");
        Info += "Поля и свойства\n";

        foreach (var field in type.GetFields())
        {
            Console.WriteLine(field);
            Info += field + "\n";
        }

        foreach (var property in type.GetProperties())
        {
            Console.WriteLine(property);
            Info += property + "\n";
        }
        Console.WriteLine("\n");
        Info += "\n\n";
    }

    // получает все реализованные классом интерфейсы (возвращает
    // IEnumerable<string>);

    public static void KnowInterfaces(Type type)
    {
        Console.WriteLine("Реализованные интерфейсы: ");
        Info += "Реализованные интерфейсы\n";

        foreach (var @interface in type.GetInterfaces())
        {
            Console.WriteLine(@interface);
            Info += @interface + "\n";
        }

        Console.WriteLine("\n");
        Info += "\n\n";
    }

    // выводит по имени класса имена методов, которые содержат
    // заданный(пользователем) тип параметра(имя класса передается
    // в качестве аргумента);

    public static void KnowMethodsByParameter(Type type,
                                              Type parameter)
    {
        Console.WriteLine("Методы, содержащие заданный тип параметра: ");
        Info += "Методы, содержащие заданный тип параметра\n";

        foreach (var method in type.GetMethods())
        {
            foreach (var parameterInfo in method.GetParameters())
            {
                if (parameterInfo.ParameterType == parameter)
                {
                    Console.WriteLine(method);
                    Info += method + "\n";
                }
            }
        }

        Console.WriteLine("\n");
        Info += "\n\n";
    }

    /* метод Invoke, который вызывает метод класса, при этом значения
     для его параметров необходимо 1) прочитать из текстового файла
     (имя класса и имя метода передаются в качестве аргументов) 2)
 сгенерировать, используя генератор значений для каждого типа.
 Параметрами метода Invoke должны быть : объект, имя метода,
 массив параметров.*/

    public static void Invoke(Type type,
                              object? obj,
                              string methodName)
    {
        var method = type.GetMethod(methodName);

        if (method == null)
        {
            Console.WriteLine("Метод не найден");
            return;
        }

        var parameters = method.GetParameters();

        var values = new object[parameters.Length];

        for (var i = 0; i < parameters.Length; i++)
        {
            values[i] = GenerateValue(parameters[i].ParameterType);
        }

        method.Invoke(obj, values);
    }

    public static void Invoke(Type type,
                              object? obj,
                              string methodName,
                              params string[] parameters)
    {
        var method = type.GetMethod(methodName);

        if (method == null)
        {
            Console.WriteLine("Метод не найден");
            return;
        }

        var methodParameters = method.GetParameters();

        var values = new object[methodParameters.Length];

        for (var i = 0; i < methodParameters.Length; i++)
        {
            values[i] = Convert.ChangeType(parameters[i],
                                           methodParameters[i].ParameterType);
        }

        method?.Invoke(obj, values);
    }

    public static void ToFile() => File.AppendAllText(PATH, Info);

    public static void ClearFile() => File.WriteAllText(PATH, string.Empty);

    private static object GenerateValue(Type type)
    {
        if (type == typeof(int))
        {
            return 1;
        }
        if (type == typeof(string))
        {
            return "string";
        }
        if (type == typeof(double))
        {
            return 1.0;
        }
        if (type == typeof(bool))
        {
            return true;
        }
        if (type == typeof(char))
        {
            return 'c';
        }
        if (type == typeof(float))
        {
            return 1.0f;
        }
        if (type == typeof(long))
        {
            return 1L;
        }
        if (type == typeof(short))
        {
            return (short)1;
        }
        if (type == typeof(byte))
        {
            return (byte)1;
        }
        if (type == typeof(sbyte))
        {
            return (sbyte)1;
        }
        if (type == typeof(uint))
        {
            return (uint)1;
        }
        if (type == typeof(ulong))
        {
            return (ulong)1;
        }
        if (type == typeof(ushort))
        {
            return (ushort)1;
        }
        return null;
    }

    /*2. Добавьте в Reflector обобщенный метод Create, который создает объект
переданного типа(на основе имеющихся публичных конструкторов) и возвращает
его пользователю.*/

    public static T Create<T>(params object[] parms)
    {
        var type = typeof(T);

        var typeArr = parms.Select(p => p.GetType()).ToArray();

        var constructor = type.GetConstructor(typeArr.Length == 0 ? Type.EmptyTypes : typeArr);

        if (constructor == null)
        {
            Console.WriteLine("Конструктор не найден");
        }

        return (T)constructor.Invoke(parms);
    }
}
