using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    /// <summary>
    /// 适配器
    /// 目标
    /// 被适配器
    /// </summary>

    interface Target
    {
        void TDoSomething();
    }

    class Adaptee
    {
        public void ADoSomething()
        {
            Console.WriteLine("适配者再做");
        }
    }

    class Adapter : Target
    {
        Adaptee adaptee;
        public Adapter(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }

        public void TDoSomething()
        {
            adaptee.ADoSomething();
        }
    }



    internal class AdapterPatternMain : IPattern
    {
        public void Main()
        {
            Adaptee adaptee = new Adaptee();
            Adapter adapter = new Adapter(adaptee);
            adapter.TDoSomething();
        }
    }
}
