using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    /// <summary>
    /// 抽象工厂模式
    /// 工厂模式+策略模式
    /// </summary>

    abstract class Creator
    {
        /// <summary>
        /// 工厂方法
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        abstract public Product FactoryMethod(string type);
    }

    /// <summary>
    /// 调料工厂采用组合方式
    /// </summary>
    abstract class IngredientCreator
    {
        /// <summary>
        /// 工厂方法
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        abstract public string CreateSalt();
        abstract public string CreateSuger();
    }

    /// <summary>
    /// 加了调料的复杂产品
    /// </summary>
    abstract class Product
    {
        protected string Salt;
        protected string Suger;

        protected string Name;
        protected string Description;

        //组合一个调料工厂
        protected IngredientCreator ingredientCreator;

        public abstract void Display();
    }

    class SugerIngredient : IngredientCreator
    {
        public override string CreateSalt()
        {
            return "不加盐";
        }

        public override string CreateSuger()
        {
            return "加糖";
        }
    }
    class SaltIngredient : IngredientCreator
    {
        public override string CreateSalt()
        {
            return "加盐";
        }

        public override string CreateSuger()
        {
            return "不加糖";
        }
    }

    class LittelHamburger : Product
    {
        public LittelHamburger(IngredientCreator ingredient)
        {
            Name = "小汉堡";
            Description = "这是一个小汉堡";
            this.ingredientCreator = ingredient;
            Salt = ingredientCreator.CreateSalt();
            Suger = ingredientCreator.CreateSuger();
        }

        public LittelHamburger()
        {
            Name = "小汉堡";
            Description = "这是一个小汉堡";
        }
        public override void Display()
        {
            Console.WriteLine(Name + " " + Description);
            Console.WriteLine(Salt);
            Console.WriteLine(Suger);
        }
    }

    class BigHamburger : Product
    {
        public BigHamburger(IngredientCreator ingredient)
        {
            Name = "大汉堡";
            Description = "这是一个大汉堡";
            this.ingredientCreator = ingredient;
            Salt = ingredientCreator.CreateSalt();
            Suger = ingredientCreator.CreateSuger();
        }

        public BigHamburger()
        {
            Name = "大汉堡";
            Description = "这是一个大汉堡";
        }
        public override void Display()
        {

            Console.WriteLine(Name + " " + Description);
            Console.WriteLine(Salt);
            Console.WriteLine(Suger);
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
                case "甜大汉堡":
                    return new BigHamburger(new SugerIngredient());
                case "咸小汉堡":
                    return new LittelHamburger(new SaltIngredient());
                case "咸大汉堡":
                    return new BigHamburger(new SaltIngredient());
                case "甜小汉堡":
                    return new LittelHamburger(new SugerIngredient());
                default:
                    return null;
            }
        }
    }

    internal class AbstractFactoryPatternMain : IPattern
    {
        public void Main()
        {
            Creator creator = new HamburgerCreator();
            Product product = creator.FactoryMethod("大汉堡");
            Product product1 = creator.FactoryMethod("小汉堡");
            Product product2 = creator.FactoryMethod("甜大汉堡");
            Product product3 = creator.FactoryMethod("甜小汉堡");
            Product product4 = creator.FactoryMethod("咸大汉堡");
            Product product5 = creator.FactoryMethod("咸小汉堡");

            product.Display();
            product1.Display();
            product2.Display();
            product3.Display();
            product4.Display();
            product5.Display();
        }
    }
}
