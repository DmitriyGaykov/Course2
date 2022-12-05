using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1;
class NextList<T> : IEnumerable, IList<T>
{
    private List<T> list = new();

    public bool Find(T el)
    {
        if (list.Contains(el))
        {
            return true;
        }

        throw new Exception("Такого элемента нет!");
    }
    public List<T>? NList
    {
        get => list;
        set => list = value ??
                      throw new ArgumentNullException(nameof(value));
    }

    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public IEnumerator GetEnumerator() => list.GetEnumerator();


    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, T item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public void Add(T item) => list.Add(item);

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
