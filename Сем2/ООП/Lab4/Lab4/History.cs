using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace History
{
    public class History
    {
        private const int MaxSizeOfHistory = 8;
        private List<Type> history;
        private HashSet<Type> allTypes = new HashSet<Type>();
        private int? index;
        public List<Type> Storage => history;
        public int? Index
        {
            get => index;
            set => index = value;
        }

        static public Type Back { get; set; }

        public History()
        {
            history = new List<Type>();
            index = null;
        }
      

        public void Add(Type form)
        {
            history.Add(form);
            allTypes.Add(form);

            if (history.Count() > MaxSizeOfHistory)
            {
                history.RemoveAt(0);
            }

            index = history.Count() - 1;
        }

        public Type Next()
        {
            if (index is null || index == history.Count() - 1)
            {
                return null;
            }
            Type form = history[(int)++index];
            return form;
        }

        public Type Prev()
        {
            if (index is null || index == 0)
            {
                return null;
            }

            Type form = history[(int)--index];
            return form;
        }

        public void Reset() => index = history.Count() - 1;
    }
}