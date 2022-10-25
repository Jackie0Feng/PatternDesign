using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    class Facada
    {
        public Func1 func1;
        public Func2 func2;
        public Facada(Func1 func1, Func2 func2)
        {
            this.func1 = func1;
            this.func2 = func2;
        }

        public void Do()
        {
            func1.Do();
            func2.Do();
        }
    }

    class Func1
    {
        public void Do()
        {
            Console.WriteLine("func1 do");
        }
    }

    class Func2
    {
        public void Do()
        {
            Console.WriteLine("func2 do");
        }
    }

    internal class FacadePatternMain : IPattern
    {
        public void Main()
        {
            Func1 func1 = new Func1(); ;
            Func2 func2 = new Func2();
            Facada facada = new Facada(func1, func2);
            facada.Do();
        }
    }
}
