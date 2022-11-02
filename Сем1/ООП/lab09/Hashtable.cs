
using System.Collections;
using System.Text.RegularExpressions;

namespace Lab9;
class Hashtable<T, G> : IEnumerable
    where T : notnull
    where G : notnull
{
    #region Fields

    private Datas[] _Elements = new Datas[MaxCount];
    private const int MaxCount = 30;
    private int length;

    #endregion

    #region Ctors


    #endregion

    #region Props

    public int Length
    {
        get => length;
        private set => length = value;
    }

    #endregion

    #region Methods

    public void Remove(T key)
    {
        int index = Hash(key);

        if (_Elements[index].Key.Equals(key))
        {
            _Elements[index] = null;
        }
        else
        {
            for (int i = 0; i < MaxCount && i != index; i++)
            {
                if (_Elements[i].Key.Equals(key))
                {
                    _Elements[index] = null;
                }
            }
        }
    }
    public IEnumerator GetEnumerator()
    {
        return _Elements.GetEnumerator();
    }
    public bool Add(T key,
                    G value)
    {
        if (Length == MaxCount)
        {
            return false;
        }

        int index = Hash(key);

        if (_Elements[index] is null)
        {
            _Elements[index] = new Datas(key, value);
            this.Length++;
            return true;
        }
        else if (_Elements[index].Key.Equals(key))
        {
            _Elements[index].Value = value;
            this.Length++;
            return true;
        }
        else
        {
            for (int i = 0; i < MaxCount && i != index; i++)
            {
                if (_Elements[i] == null)
                {
                    _Elements[i] = new Datas(key, value);
                    this.Length++;
                    return true;
                }
            }
        }
        return false;
    }
    public G[] ToArray()
    {
        var arr = new G[Length];
        int index = 0;
        foreach (var item in _Elements)
        {
            if (item is not null)
            {
                arr[index++] = item.Value;
            }
        }

        return arr;
    }

    public void Print()
    {
        foreach (var item in _Elements)
        {
            if (item is not null)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    public void Remove(int n)
    {
        if (n < 0 || n > MaxCount)
        {
            throw new IndexOutOfRangeException();
        }

        int count = 0;

        for (int i = 0; i < MaxCount; i++)
        {
            if (count == n)
            {
                break;
            }
            if (_Elements[i] is not null)
            {
                count++;
                _Elements[i] = null;
            }
        }
    }

    public G Get(T key)
    {
        int index = Hash(key);

        if (_Elements[index] is not null &&
            _Elements[index].Key.Equals(key))
        {
            return _Elements[index].Value;
        }
        else
        {
            for (int i = 0; i < MaxCount && i != index; i++)
            {
                if (_Elements[i] is not null &&
                    _Elements[i].Key.Equals(key))
                {
                    return _Elements[i].Value;
                }
            }
        }
        return default(G);
    }
    private bool IsThere(T key)
    {
        for (int i = 0; i < length; i++)
        {
            if (_Elements[i].Key.Equals(key))
            {
                return true;
            }
        }

        return false;
    }
    private int Hash(T key)
    {
        return Math.Abs(key.GetHashCode() % MaxCount);
    }

    #endregion

    #region Indexer

    public G this[T key]
    {
        get => Get(key);
        set => Add(key, value);
    }

    #endregion

    #region Class Datas

    private class Datas
    {
        public T Key { get; set; }
        public G Value { get; set; }
        public Datas(T key, G value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString() => $"Key: \n{Key}\n\n" +
                                             $"Value: \n{Value}\n";
    }

    #endregion
}
