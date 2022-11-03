namespace lab14;

static class Exesizes
{
    private static void OutN(object n)
    {
        string nums = string.Empty;
        
        for (uint i = 0; n is uint N && i < N; i++)
        {
            nums += i.ToString() + " ";
        }
        
        Console.WriteLine(nums);
        File.WriteAllText("nums.txt", nums);
    }

    public static void Ex3(uint n)
    {
        Thread thr = new(new ParameterizedThreadStart(OutN));
        thr.Name = "Вывод чисел";
        thr.Start(n);

        //  Во 
        // время выполнения выведите информацию о статусе потока, имени, приоритете, числовой
        // идентификатор и т.д.

        Console.WriteLine($"После запуска!\n" +
                          $"Имя потока: {thr.Name},\t" +
                          $"Статус потока: {thr.ThreadState}," +
                          $"\t Приоритет потока: {thr.Priority}," +
                          $"\t Идентификатор потока: {thr.ManagedThreadId}");

        // Вызовите методы управления потоком (запуск, приостановка, возобновление и т.д.)

        // Thread.Sleep(1000);
        // thr.Abort();
    }

    private static uint N;

    private static readonly Mutex mut = new();
    public static void Ex4(uint n = 10000)
    { 
        Thread thr1 = new(new ParameterizedThreadStart(outN));
        Thread thr2 = new(new ParameterizedThreadStart(outN));

        N = n;
       
        thr2.Start(false);
        thr1.Start(true);
        
        // thr1.Start(n);
        
        // thr2.Priority = ThreadPriority.Highest;
        
        // thr2.Start(n);

    }

    private static object locker = new();
    private static void outN(object isEvenNum)
    {
        for (int i = 1; i <= (uint)N; i++)
        {
            mut.WaitOne();
            if ((bool)isEvenNum &&
                i % 2 == 0)
            {
                Console.WriteLine(i);
            }
            else if (!(bool)isEvenNum &&
                     i % 2 != 0)
            {
                Console.WriteLine(i);
            }
         mut.ReleaseMutex();
        }
 
    }

}
