namespace Lab9;
class Queue<T>
{
    #region Fields

    private T[] _Elements;
    private int MaxCount = 30;
    private int length;

    #endregion

    #region Props

    public int Length
    {
        get => length;
        private set => length = value;
    }

    #endregion

    #region Ctors

    public Queue() => _Elements = new T[MaxCount];

    #endregion

    #region Methods

    public void Push(T value)
    {
        if (Length == MaxCount)
        {
            QueueResize();
        }

        _Elements[Length++] = value;
    }

    public void Pushs(params T[] values)
    {
        foreach (var value in values)
        {
            Push(value);
        }
    }

    public void Push(T[] values)
    {
        foreach (var value in values)
        {
            Push(value);
        }
    }

    public void Pop()
    {
        if (Length == 0)
        {
            return;
        }

        for (int i = 0; i < Length - 1; i++)
        {
            _Elements[i] = _Elements[i + 1];
        }

        Length--;
    }

    public T Front()
    {
        if (Length == 0)
        {
            return default(T);
        }

        return _Elements[0];
    }

    public void Print()
    {
        for (int i = 0; i < Length; i++)
        {
            Console.Write(_Elements[i] + "\t");
        }
        Console.WriteLine();
    }

    private void QueueResize() =>
        Array.Resize(ref _Elements, MaxCount *= 2);

    #endregion
}
