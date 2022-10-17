using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///策略模式：封装变化为接口
///把成员方法转化为成员属性
namespace StrategyPattern
{
    public interface IFlyBehavior
    {
        void Fly();
    }

    public interface IQuackBehavior
    {
        void Quack();
    }

    public abstract class Duck
    {
        protected IFlyBehavior flyBehavior;
        protected IQuackBehavior quackBehavior;

        public Duck() { }

        public void PerformFly()
        {
            flyBehavior.Fly();
        }
        public void PerformQuack()
        {
            quackBehavior.Quack();
        }

        public virtual void Display()
        {
            PerformFly();
            PerformQuack();
            Siwm();
        }

        public void Siwm()
        {
            Console.WriteLine("游泳");
        }

        public void SetFlyBehavior(IFlyBehavior fly)
        {
            flyBehavior = fly;
        }

        public void SetQuackBehavior(IQuackBehavior quack)
        {
            quackBehavior = quack;
        }
    }

    public class FlyWithWings : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("用翅膀飞");
        }
    }

    public class FlyNoWay : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("不能飞");
        }
    }

    public class Quack : IQuackBehavior
    {
        void IQuackBehavior.Quack()
        {
            Console.WriteLine("呱呱叫");
        }
    }
    public class MuteQuack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("不能叫");
        }
    }

    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            flyBehavior = new FlyWithWings();
            quackBehavior = new Quack();
        }

        public override void Display()
        {
            Console.WriteLine("我是一只绿头鸭");
            base.Display();
        }
    }

    public class ModelDuck : Duck
    {
        public ModelDuck()
        {
            flyBehavior = new FlyNoWay();
            quackBehavior = new MuteQuack();
        }
        public override void Display()
        {
            Console.WriteLine("我是一只模型鸭");
            base.Display();
        }
    }

    class StrategyPatternMain
    {
        public void Main()
        {
            MallardDuck mallardDuck = new MallardDuck();
            ModelDuck modelDuck = new ModelDuck();
            mallardDuck.Display();
            modelDuck.Display();
            Console.WriteLine("绿头鸭摔断了翅膀");
            mallardDuck.SetFlyBehavior(new FlyNoWay());
            mallardDuck.Display();
        }
    }
}
