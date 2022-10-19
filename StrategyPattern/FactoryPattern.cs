using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    abstract class Creator
    {
        abstract public Product FactoryMethod(string type);
    }

    abstract class Product
    {
        protected string Name;
        protected string Description;
        public abstract void Display();
    }

    class LittelHamburger : Product
    {
        public LittelHamburger()
        {
            Name = "小汉堡";
            Description = "这是一个小汉堡";
        }
        public override void Display()
        {
            Console.WriteLine(Name + " " + Description);
        }
    }

    class BigHamburger : Product
    {
        public BigHamburger()
        {
            Name = "大汉堡";
            Description = "这是一个大汉堡";
        }
        public override void Display()
        {
            Console.WriteLine(Name + " " + Description);
        }
    }

    class HamburgerCreator : Creator
    {
        public override Product FactoryMethod(string type)
        {
            switch (type)
            {
                case "大汉堡":
                    return new BigHamburger();
                case "小汉堡":
                    return new LittelHamburger();
                default:
                    return null;
            }
        }
    }

    internal class FactoryPatternMain : IPattern
    {


        public void Main()
        {
            Creator creator = new HamburgerCreator();
            Product product = creator.FactoryMethod("大汉堡");
            Product product1 = creator.FactoryMethod("小汉堡");

            product.Display();
            product1.Display();
        }
    }
}
