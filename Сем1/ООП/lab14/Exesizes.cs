namespace lab14;

static class Exesizes
{
    public static Mutex mut = new();
    
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


        Console.WriteLine(Thread.CurrentThread.ThreadState);
        mut.WaitOne(10000);
        Console.WriteLine(Thread.CurrentThread.ThreadState);

        Console.WriteLine($"После запуска!\n" +
                          $"Имя потока: {thr.Name},\t" +
                          $"Статус потока: {thr.ThreadState}," +
                          $"\t Приоритет потока: {thr.Priority}," +
                          $"\t Идентификатор потока: {thr.ManagedThreadId}");
        mut.Dispose();
    }

}
