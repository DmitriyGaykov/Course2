namespace Exesize5;
class Warehouse
{
    #region Field
    
    private uint count;
    private static object locker = new();
    
    #endregion

    #region Props

    public uint? Count
    {
        get => count;
        set => count = value ??
                       0;
    }

    #endregion

    #region Ctors

    public Warehouse(uint? count) => Count = count;

    #endregion

    #region Methods

    public void Get(object time)
    {
        while (Count != 0)
        {
            lock (locker)
            {
                Count--;
                Console.WriteLine($"{Thread.CurrentThread.Name} разгрузил. Теперь {Count}");
            }

            Thread.Sleep((int)time);
        }
    }

    #endregion
}
