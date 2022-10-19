using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    /// <summary>
    /// 装饰器模式
    /// 组件和装饰器
    /// </summary>

    public interface IFood
    {
        string Name { get; }
        string Description { get; set; }

        string GetDescription();
        double Cost();
    }

    /// <summary>
    /// 被装饰食物接口
    /// </summary>
    public abstract class AbstractFood : IFood
    {
        public string Name { get; }

        public string Description { get; set; }

        public virtual string GetDescription()
        {
            return Description;
        }

        abstract public double Cost();
    }

    /// <summary>
    /// 抽象调料装饰器
    /// </summary>
    public abstract class CondimentDecorator : AbstractFood
    {
        protected IFood food;
        public abstract override string GetDescription();
    }

    public class Hamburger : AbstractFood
    {
        public Hamburger()
        {
            Description = "汉堡包";
        }
        public override double Cost()
        {
            return 1;
        }
    }


    public class Salt : CondimentDecorator
    {
        public Salt(IFood food)
        {
            this.food = food;
        }
        public override string GetDescription()
        {
            return food.GetDescription() + "加盐";
        }

        public override double Cost()
        {
            return food.Cost() + 0.1f;
        }
    }

    public class Suger : CondimentDecorator
    {
        public Suger(IFood food)
        {
            this.food = food;
        }
        public override string GetDescription()
        {
            return food.GetDescription() + "加糖";
        }

        public override double Cost()
        {
            return food.Cost() + 0.2f;
        }
    }



    internal class DecoratorPatternMain : IPattern
    {

        public void Main()
        {

            IFood hamburger = new Hamburger();
            hamburger = new Salt(hamburger);
            hamburger = new Suger(hamburger);
            hamburger = new Salt(hamburger);

            Console.WriteLine(hamburger.GetDescription());

        }
    }
}
