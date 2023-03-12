using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Storages
{
    internal interface IIterator<T>
    {
        T Next { get; }
        T Prev { get; }
        int Index { get; set; }
        void Reset();
        void Add(T obj);
    }
}
