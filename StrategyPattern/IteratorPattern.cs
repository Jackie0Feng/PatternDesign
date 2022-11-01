using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    interface IIterator
    {
        bool HasNext();
        object Next();
    }

    interface IAggregate
    {
        IIterator CreateIterator();
    }

    class ListIterator<T> : IIterator
    {
        List<T> list;
        int index = 0;
        public ListIterator(List<T> list)
        {
            this.list = list;
        }

        public bool HasNext()
        {
            if (list == null || index >= list.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public object Next()
        {
            return list[index++];
        }
    }

    class ArrayIterator<T> : IIterator
    {
        T[] list;
        int index = 0;

        public ArrayIterator(T[] list)
        {
            this.list = list;
        }

        public bool HasNext()
        {
            if (list == null || index >= list.Length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public object Next()
        {
            return list[index++];
        }
    }

    class ListMenu : IAggregate
    {
        List<int> list;
        public ListMenu()
        {
            list = new List<int>();
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
        }

        public IIterator CreateIterator()
        {
            return new ListIterator<int>(list);
        }
    }

    class ArrayMenu : IAggregate
    {
        int[] list;
        public ArrayMenu()
        {
            list = new int[4];
            list[0] = 0;
            list[1] = 1;
            list[2] = 2;
            list[3] = 3;
        }

        public IIterator CreateIterator()
        {
            return new ArrayIterator<int>(list);
        }
    }

    internal class IteratorPatternMain : IPattern
    {
        public void Main()
        {
            IAggregate a = new ListMenu();
            IAggregate b = new ArrayMenu();
            foreachByIterator(a);
            foreachByIterator(b);


        }
        void foreachByIterator(IAggregate list)
        {
            IIterator aIterator = list.CreateIterator();
            while (aIterator.HasNext())
            {
                Console.WriteLine(aIterator.Next());
            }
        }

    }
}
