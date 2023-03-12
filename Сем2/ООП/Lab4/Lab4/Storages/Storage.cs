using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Storages
{
    public class Storage<T> : IIterator<T> 
    {
        public const ushort Default = 10;

        private readonly ushort MaxCount;
        private readonly IList<T> states;
        
        public Storage() : this(Default)
        {
           
        }

        public Storage(ushort maxCount)
        {
            MaxCount = maxCount;
            states = new List<T>(this.MaxCount);
        }

        public T Next 
        { 
            get => states[Index + 1 == states.Count ? Index : ++Index];
        }
        public T Prev 
        { 
            get => states[Index - 1 == -1 ? Index : --Index]; 
        }
        public int Index 
        { 
            get;
            set;
        }

        public void Add(T obj) => SaveState(obj);
        public void Reset() => Index = states.Count - 1;

        public void SaveState(T state, bool resetIndex = true)
        {
            if (states.Count ==  MaxCount)
            {
                states.RemoveAt(0);
            }

            states.Add(state);

            if (resetIndex)
            {
                this.Reset();
            }
        }

        public async void SaveStateAsync(T state, bool resetIndex = true)
        {
            await Task.Run(() => SaveState(state, resetIndex));
        }
    }
}
