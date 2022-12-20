using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
namespace Program
{
   
    class GoodStack<T> : Stack<T>
        where T: new()
    {
        public T Pop() => throw new InsufficientExecutionStackException();
        public bool Remove() => throw new InsufficientExecutionStackException();
    }

    struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString() => $"({x}, {y})";
    }
    
    class _Program
    {
        static void Main()
        {
            #region Ex1

            var _gs = new GoodStack<Point>();

            _gs.Push(new Point(1, 23));
            _gs.Push(new Point(2, 23));
            _gs.Push(new Point(3, 23));
            _gs.Push(new Point(4, 23));

            foreach (var item in _gs)
            {
                Console.WriteLine(item);
            }

            try
            {
                _gs.Pop();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion

            #region Ex2

            string[] arr = new string[]
            {
                "skdfkdsf.",
                "Asdodsk.",
                "Влад"
            };

            int count = arr.Where(el => el.Last() is ('.' or ',' or '!' or '?') && el.First() is ('A' or 'W')).Count();

            Console.WriteLine($"Количество: {count}");

            #endregion
        }
    }
}
