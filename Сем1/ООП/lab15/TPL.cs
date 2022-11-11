using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace lab15;

static partial class TPL
{
    public static void Ex1(int N)
    {
        Console.WriteLine("-----------Задание 1-----------");
        Stopwatch stw = new();
        
        Task task = new(() => FindSimpleNums(N, stw));
        
        Console.WriteLine($"Статус до запуска: {task.Status}");
        stw.Start();
        task.Start();
        Console.WriteLine($"Статус после запуска: {task.Status}");
    }

    public static void Ex2(int N)
    {
        Console.WriteLine("-----------Задание 2-----------");
        CancellationTokenSource cts = new();
        var token = cts.Token;

        Task task = new(() => FindSimpleNums(N, ref token), token);

        Console.WriteLine($"Статус до запуска: {task.Status}");

        task.Start();

        Console.WriteLine($"Статус после запуска: {task.Status}");
        
        cts.Cancel();

        Thread.Sleep(3000);

        Console.WriteLine($"Статус после отмены: {task.Status}");
    }
    
    private static List<int> FindSimpleNums(int N,
                                            Stopwatch stw = null)
    {
        List<int> simpleNums = new();

        for(int i = 2; i <= N; i++)
        {
            simpleNums = simpleNums.Append(i).ToList();
        }

        int p = 2;
        int preP = 0;

        var list = new List<int>();
        string str = string.Empty;

        while (p != preP)
        {
            preP = p;
            str += p + "\n";
            simpleNums = simpleNums.Where(el => el == p || el % p != 0).ToList();
            
            list = simpleNums.Where(el => el > p).ToList();
            p = list.Count > 0 ? list.Min() : preP;
        }

        if (stw is not null)
        {
            stw.Stop();
            Console.WriteLine($"Время выполнения: {stw.ElapsedMilliseconds}");
        }

        Console.WriteLine("Выполнено!");
        // Console.WriteLine(str);

        return simpleNums;
    }

    private static List<int> FindSimpleNums(int N,
                                            ref CancellationToken token)
    {
        List<int> simpleNums = new();

        for (int i = 2; i <= N; i++)
        {
            simpleNums = simpleNums.Append(i).ToList();

            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Задача отменена");
                return null;
            }
        }

        int p = 2;
        int preP = 0;

        var list = new List<int>();
        string str = string.Empty;

        while (p != preP)
        {
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Задача отменена");
                return null;
            }
            preP = p;
            str += p + "\n";
            simpleNums = simpleNums.Where(el => el == p || el % p != 0).ToList();

            list = simpleNums.Where(el => el > p).ToList();
            p = list.Count > 0 ? list.Min() : preP;
        }
        
        Console.WriteLine("Выполнено!");
        // Console.WriteLine(str);

        return simpleNums;
    }
}

