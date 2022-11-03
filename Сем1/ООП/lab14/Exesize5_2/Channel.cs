namespace Exesize5_2;

class Channel
{
    #region Fields

    private string name;
    private static Semaphore sem = new(2, 2);
    private static Random rand = new();

    #endregion

    #region Props

    public string? Name
    {
        get => name;
        set => name = value ??
                      "default";
    }

    #endregion

    #region Ctors

    public Channel(string? name) => Name = name;

    ~Channel() => sem.Dispose();

    #endregion

    #region Methods

    public void Get()
    {
        sem.WaitOne();
        DateTime dt = DateTime.Now;
        DateTime start = dt;
        int time;
        
        while(dt < start.AddSeconds(3))
        {
            time = rand.Next(100, 2000);
            dt = dt.AddMilliseconds(time);
            Console.WriteLine($"{Thread.CurrentThread.Name} : смотрит {Name}. Осталось {(dt - start).Milliseconds}");
            Thread.Sleep(time);
        }

        sem.Release();
    }

    #endregion
}
