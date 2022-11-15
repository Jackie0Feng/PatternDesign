# Head First 设计模式

[TOC]
## 完整源码
[GitHub仓库](https://github.com/Jackie0Feng/PatternDesign)

## 设计模式入门

*   面向对象基础
    *   抽象
    *   封装
    *   继承
    *   多态
*   良好的面向对象设计
    *   复用性
    *   扩充性
    *   可维护性
*   面向对象原则
    *   封装变化
    *   多用组合，少用继承
    *   针对接口编程，不针对实现编程
    *   为交互对象之间的松耦合努力
    *   开放闭合原则
        *   一个类对扩展开放，对修改关闭
        *   原先的main调用不受影响
    *   依赖倒置原则
        *   要依赖抽象，不要依赖具体类
        *   高层组件和底层组件都应该依赖于抽象
    *   最少知识原则
        *   类之间的交流越简单越好
    *   好莱坞原则
        *   高层依赖底层
        *   底层不依赖高层
    *   单一职责原则
        *   类的功能越单一越好

## 具体设计模式

### 策略模式

*   定义算法族，分别封装起来，让他们之间可以互相替换。让算法的变化独立于使用算法的客户。（将变化部分封装为成员变量，借用成员变量的多态实现方法的互换）
*   具体实现

    *   实现场景：不同的鸭子具有不同的行为
    *   将行为抽象为接口
    *   将接口作为成员变量，行为类继承行为接口
    *   实例鸭子类时指定特定行为类
        *   行为相当于算法，算法变化独立于使用算法的用户（鸭子）
```
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

        public class NormalQuack : IQuackBehavior
        {
            public void Quack()
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
                quackBehavior = new NormalQuack();
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
```

### 观察者模式

*   在对象之间定义一对多的关系，当主对象改变时，所有依赖其的对象收到通知，自动更新

*   具体实现
    *   主题接口维护一个观察者列表
    *   给所有观察者发送消息（调用观察者方法）
        *   主题通过参数推数据
        *   观察者通过参数拉数据

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternDesign;

namespace ObserverPattern
{
    /// <summary>
    /// 主题
    /// 添加监听者
    /// 删除监听者
    /// </summary>
    public interface ISubject
    {
        bool isChange { get; set; }
        List<IObserver> obervers { get; set; }

        void AddObserver(IObserver oberver);
        void RemoveObserver(IObserver oberver);

        void SetChange(ISubject subject);
        void NotifyObservers();
    }

    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public class WeatherData : ISubject
    {

        public string Name { get; set; }
        public string Description { get; set; }

        public bool isChange { get; set; }

        public WeatherData()
        {
            Name = "天气数据";
            Description = "今天气温25度";

            isChange = false;
            obervers = new List<IObserver>();
        }

        public List<IObserver> obervers { get; set; }

        public void AddObserver(IObserver oberver)
        {
            obervers.Add(oberver);
        }

        public void RemoveObserver(IObserver oberver)
        {
            obervers.Remove(oberver);
        }
        public void SetChange(ISubject subject)
        {
            isChange = true;
            NotifyObservers();
        }

        public void NotifyObservers()
        {
            if (isChange)
            {
                foreach (IObserver oberver in obervers)
                {
                    oberver.Update(this);
                }
                isChange = false;
            }
        }


    }

    public class Display1 : IObserver
    {
        public void Update(ISubject subject)
        {
            WeatherData weatherData = (WeatherData)subject;
            Console.WriteLine("展示牌一：");
            Console.WriteLine(weatherData.Name);
            Console.WriteLine(weatherData.Description);
        }
    }

    public class Display2 : IObserver
    {
        public void Update(ISubject subject)
        {
            WeatherData weatherData = (WeatherData)subject;
            Console.WriteLine("展示牌二：");
            Console.WriteLine(weatherData.Name);
            Console.WriteLine(weatherData.Description);
        }
    }

    public class Display3 : IObserver
    {
        public void Update(ISubject subject)
        {
            WeatherData weatherData = (WeatherData)subject;
            Console.WriteLine("展示牌三：");
            Console.WriteLine(weatherData.Name);
            Console.WriteLine(weatherData.Description);
        }
    }

    public class WeatherDataByS : IObservable<WeatherDataByS>, IDisposable
    {
        List<IObserver<WeatherDataByS>> observers;

        public WeatherDataByS()
        {
            observers = new List<IObserver<WeatherDataByS>>();
        }

        public IDisposable Subscribe(IObserver<WeatherDataByS> observer)
        {
            observers.Add(observer);
            return this;
        }

        public void NotifyObservers()
        {

            foreach (IObserver<WeatherDataByS> observer in observers)
            {
                observer.OnNext(this);
                observer.OnCompleted();
            }
        }

        public void Dispose()
        {
            Console.WriteLine("通知公告板");
        }
    }

    public class DisplayByS1 : IObserver<WeatherDataByS>
    {
        public void OnNext(WeatherDataByS value)
        {
            value.Dispose();
        }

        public void OnError(Exception error)
        {
            error.ToString();
        }

        public void OnCompleted()
        {
            Console.WriteLine("通知完成");
        }
    }


    internal class ObserverPatternMain : IPattern
    {
        public void Main()
        {
            ISubject weatherData = new WeatherData();

            IObserver display1 = new Display1();
            IObserver display2 = new Display2();
            IObserver display3 = new Display3();

            weatherData.AddObserver(display1);
            weatherData.AddObserver(display2);
            weatherData.AddObserver(display3);

            weatherData.SetChange(weatherData);


            IObservable<WeatherDataByS> observable = new WeatherDataByS();
            IObserver<WeatherDataByS> observer = new DisplayByS1();

            observable.Subscribe(observer);
            ((WeatherDataByS)observable).NotifyObservers();
        }
    }
}

```

### 装饰者模式

*   动态的将责任附加到对象上。有别于继承的扩展功能。
*   组件，装饰器
    *   组件（被装饰者）和装饰器是同一类型
    *   装饰器可以以一定顺序添加或替换组件方法（拓展/改变）
        *   装饰器内部有组件变量

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternDesign;

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

```

### 工厂模式
*   定义
    *   定义了一个创建对象的接口，但由子类决定要实例化的类是哪一个。工厂方法让类把实例化延迟到子类
*   解决问题
    *   将客户程序从具体类解耦
*   实现思路
    *   抽象产品
        *   具体产品继承抽象产品接口
            *   通过产品接口与具体类型产品解耦，从而生产不同类型产品
    *   创建者
        *   创建抽象产品的接口
            *   具体创建者实现创建接口

```
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

```

### 抽象工厂模式

*   提供一个接口，用于创建相关或依赖对象家族，而不需要明确指定具体类
    *   客户要一个产品，描述一个必要的概念即可或得一个复杂产品，复杂产品生产过程封装在工厂中，抽象工厂模式可以在不改变用户点餐方式，给工厂加复杂度
    *   工厂模式+策略模式
*   抽象工厂与工厂的区别
    *   工厂模式使用继承，将具体对象的创建延迟给子类实现
    *   抽象工厂使用组合，将具体对象的创建被组合的工厂子类实现

```
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

```

### 单例模式
*   定义
    *   确保一个类只有一个实例，并提供全局访问点，延迟实例化
*   解决问题
    *   保证只有一个实例
    *   提供全局访问点，方便访问
*   实现思路
    *   简单单例
            *   私有静态属性
            *   私有构造器
            *   公有静态全局访问点
                *   延迟实例化
    *   线程安全单例
        *   静态构造器保证线程安全
```
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace SingletonPattern
    {
    public class Singleton
    {
    private static Singleton instance;
    private Singleton() { }
    public static Singleton Instance
    {
    get
    {
    if (instance == null)
    {
    instance = new Singleton();
    }
    return instance;
    }
    }

            public void Display()
            {
                Console.WriteLine("我是简单单例");
            }

        }

        /// <summary>
        /// 完全懒汉多线程安全单例模式
        /// </summary>
        public sealed class SyncSingleton
        {
            private SyncSingleton() { }
            public static SyncSingleton Instance { get { return Nested.instance; } }
            private class Nested
            {
                //Explicit static constructor to tell C# compiler
                //not to mark type as beforefieldinit
                static Nested()
                {
                }
                internal static readonly SyncSingleton instance = new SyncSingleton();
            }
            public void Display()
            {
                Console.WriteLine("这是一个线程安全的单例模式");
            }
        }

        internal class SingletonPatternMain : IPattern
        {
            public void Main()
            {
                Singleton.Instance.Display();
                SyncSingleton.Instance.Display();
            }
        }

    }
```

### 命令模式
*   定义
    *   将请求封装成对象，使用不同的请求来参数化其他对象的命令
*   解决的问题
    *   将请求者与执行者之间解耦（运行时灵活指定）
    *   支持撤销操作
    *   支持宏命令
    *   可实现日志和事物系统
*   实现思路
    *   请求者
        *   命令
        *   设置命令方法
    *   命令
        *   执行者
        *   执行方法，撤销方法...
    *   执行者
        *   提供相关功能的接口
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    /// <summary>
    /// 命令模式
    /// 请求者
    /// 命令
    /// 执行者
    /// </summary>

    interface IInvoker
    {
        void SetCommand(ICommand command);
        void SetCommand(ICommand[] commands);
        void ExecuteCommand();
        void ExecuteCommands();
    }

    abstract class Invoker : IInvoker
    {
        protected ICommand command;
        protected ICommand[] commands;

        public abstract void SetCommand(ICommand command);
        public abstract void SetCommand(ICommand[] commands);
        public abstract void ExecuteCommand();
        public abstract void ExecuteCommands();
    }

    interface ICommand
    {
        void Execute();
        void Undo();
    }

    abstract class Command : ICommand
    {
        public IReceiver receiver { set; get; }

        public Command(IReceiver receiver)
        {
            this.receiver = receiver;
        }

        public virtual void Execute()
        {
            receiver.DoSomething();
        }

        public virtual void Undo()
        {
            receiver.UndoSomething();
        }
    }

    interface IReceiver
    {
        void DoSomething();
        void UndoSomething();
    }

    class Ligtht : IReceiver
    {
        public void DoSomething()
        {
            Console.WriteLine("开灯");
        }

        public void UndoSomething()
        {
            Console.WriteLine("关灯");
        }
    }

    class RemoteControl : Invoker
    {
        protected ICommand command;
        protected ICommand[] commands;

        public override void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public override void SetCommand(ICommand[] commands)
        {
            this.commands = commands;
        }

        public override void ExecuteCommand()
        {
            command.Execute();
        }

        public override void ExecuteCommands()
        {
            foreach (var item in commands)
            {
                item.Execute();
            }
        }
    }


    class LightOnCommand : Command
    {
        public LightOnCommand(IReceiver receiver) : base(receiver)
        {
        }
    }

    class LitghtOffCommand : Command
    {
        public LitghtOffCommand(IReceiver receiver) : base(receiver)
        {
        }
    }

    internal class CommandPatternMain : IPattern
    {
        public void Main()
        {
            IInvoker remoteControl = new RemoteControl();
            IReceiver light = new Ligtht();
            LightOnCommand lightOnCommand = new LightOnCommand(light);
            LitghtOffCommand litghtOffCommand = new LitghtOffCommand(light);


            remoteControl.SetCommand(lightOnCommand);
            remoteControl.ExecuteCommand();
            remoteControl.SetCommand(litghtOffCommand);
            remoteControl.ExecuteCommand();

        }
    }
}
```

### 适配器模式
*   定义
    *   将一个类的接口，转换成客户期望的另一个接口。
*   解决问题
    *   让客户从实现的接口解耦
*   实现思路
    *   适配器：实现目标接口
        *   组合被适配者
        *   使用被适配者方法实现目标接口方法
    *   被适配者
```
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
```

### 外观模式
*   定义
    *   提供一个统一的接口来访问子系统中的一群接口。定义了一个高层接口让子系统更容易使用
*   解决问题
    *   将客户从一个复杂子系统中解耦
    *   简化接口
*   实现思路
    *   外观类（总系统）
        *   组合各种子系统
        *   提供方便调用（简化）的接口
            *   具体功能由子系统实现
```
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

```

### 模版方法模式
*   定义
    *   在一个方法中定义一个算法的股价，而将一些步骤延迟到子类中。
*   解决问题
    *   提高代码复用的重要技巧
    *   钩子方法（超类固定调用的事件函数）
        *   影响模版方法的调用
*   实现思路
    *   超类
        *   定义算法模型
            *   以实现的方法
                *   可由子类重写
            *   未实现的方法（抽象方法）
                *   由子类实现
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePattern
{
    abstract class CaffeeineBeverageWithHook
    {
        /// <summary>
        /// 模版方法
        /// </summary>
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            if (IsNeedAddCondiments())
            {
                AddCondiments();
            }
        }

        protected void BoilWater()
        {
            Console.WriteLine("水煮开了");
        }
        abstract protected void Brew();
        protected void PourInCup()
        {
            Console.WriteLine("倒进杯子里");
        }

        abstract protected void AddCondiments();

        virtual protected bool IsNeedAddCondiments()
        {
            return true;
        }

    }

    class Coffee : CaffeeineBeverageWithHook
    {
        protected override void Brew()
        {
            Console.WriteLine("泡咖啡");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("加奶");
        }
    }

    class Tea : CaffeeineBeverageWithHook
    {
        protected override void Brew()
        {
            Console.WriteLine("泡茶");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("不加调料，你应该看不见这句");
        }
        protected override bool IsNeedAddCondiments()
        {
            return false;
        }

    }

    internal class TemplatePatternMain : IPattern
    {
        public void Main()
        {
            CaffeeineBeverageWithHook coffee = new Coffee();
            CaffeeineBeverageWithHook tea = new Tea();

            coffee.PrepareRecipe();
            tea.PrepareRecipe();

        }
    }
}

```

### 迭代器模式
*   定义
    *   提供一种方法顺序访问一个聚合对象中的各个元素，而不暴露其内部的表示
    *   遍历方法的适配器模式
*   解决问题
    *   解决具体集合与遍历方法的耦合问题
*   实现思路
    *   迭代器接口
        *   迭代对象集合
        *   索引值
        *   实现迭代器接口方法
    *   可被迭代器遍历接口
        *   创建对应的迭代器（工厂模式）
```
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

```

### 组合模式
*   定义
    *   允许将对象组成树形结构来表现“整体/部分”的层次结构。组合能让客户以一致的方式处理个别对象和对象组合
    *   树形结构存储叶子节点和根节点
        *   叶子节点和根节点实现同一个接口
            *   实现的方法不同
*   解决问题
    *   树形结构，无视叶子节点与根节点区别，拓展性很强
*   实现思路
    *   抽象组合类
        *   根节点使用的方法
        *   叶子节点使用的方法
        *   遍历方法
    *   组合叶子节点继承抽象组合
    *   组合根节点继承抽象组合
*   拓展
    *   组合迭代器
        *   栈，递归混用
```
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using IteratorPattern;

namespace CompositePattern
{
    public abstract class Component
    {
        public virtual void Add(Component component)
        {
            throw new NotImplementedException();
        }
        public virtual void Remove(Component component)
        {
            throw new NotImplementedException();
        }
        public virtual Component GetChild(int i)
        {
            throw new NotImplementedException();
        }

        public virtual string GetName()
        {
            throw new NotImplementedException();
        }

        public virtual string GetDescription()
        {
            throw new NotImplementedException();
        }

        public virtual bool IsTarget()
        {
            throw new NotImplementedException();
        }
        public virtual void Print()
        {
            throw new NotImplementedException();
        }
    }

    public class ComponentItem : Component
    {
        string name;
        string description;
        bool isTarget;

        public ComponentItem(string name, string description, bool isTarget)
        {
            this.name = name;
            this.description = description;
            this.isTarget = isTarget;
        }

        public override string GetName()
        {
            return name;
        }

        public override string GetDescription()
        {
            return description;
        }

        public override bool IsTarget()
        {
            return isTarget;
        }

        public override void Print()
        {
            Console.WriteLine(GetName());
            Console.WriteLine(GetDescription());
            if (isTarget)
                Console.WriteLine("我是目标");
        }
    }

    public class ComponentMenu : Component, IAggregate
    {
        string name;
        string description;
        List<Component> components = new List<Component>();

        public ComponentMenu(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public override void Add(Component component)
        {
            components.Add(component);
        }
        public override void Remove(Component component)
        {
            components.Remove(component);
        }
        public override Component GetChild(int i)
        {
            return components[i];
        }
        public override string GetName()
        {
            return name;
        }

        public override string GetDescription()
        {
            return description;
        }

        /// <summary>
        /// 树形后根遍历，递归打印所有子节点
        /// </summary>
        public override void Print()
        {
            //打印自己
            Console.WriteLine(GetName());
            Console.WriteLine(GetDescription());
            //如果有子节点打印子节点
            //for (int i = 0; i < components.Count; i++)
            //{
            //    GetChild(i).Print();
            //}
            //使用迭代器遍历
            IIterator iterator = CreateIterator();
            while (iterator.HasNext())
            {
                ((Component)iterator.Next()).Print();
            }
        }

        public void PrintTarget()
        {
            //使用迭代器遍历
            IIterator iterator = CreateIterator();
            while (iterator.HasNext())
            {
                Component component = (Component)iterator.Next();
                try
                {
                    if (component.IsTarget())
                        component.Print();
                }
                catch (NotImplementedException)
                {
                    //Console.WriteLine("遍历到菜单");
                    //component.Print();
                }
            }
        }

        public IIterator CreateIterator()
        {
            return new CompositeIterator(new ListIterator<Component>(components));
        }
    }

    /// <summary>
    /// 组合迭代器
    /// 组合一个数组迭代器，利用栈，遍历树形结构
    /// </summary>
    public class CompositeIterator : IIterator
    {
        Stack stack = new Stack();
        public CompositeIterator(IIterator iterator)
        {
            stack.Push(iterator);
        }

        public bool HasNext()
        {
            if (stack.Count == 0)
            {
                return false;
            }
            else
            {
                IIterator iterator = (IIterator)stack.Peek();
                if (!iterator.HasNext())
                {
                    stack.Pop();
                    return HasNext();
                }
                else
                {
                    return true;
                }
            }
        }

        public object Next()
        {
            if (HasNext())
            {
                IIterator iterator = (IIterator)stack.Peek();
                Component component = (Component)iterator.Next();
                if (component is ComponentMenu)
                {
                    stack.Push(((ComponentMenu)component).CreateIterator());
                }
                return component;
            }
            else
            {
                return null;
            }
        }
    }

    internal class CompositePatternMain : IPattern
    {
        public void Main()
        {
            Component mainComponent = new ComponentMenu("主组件", "所有组件根节点");
            Component Component1 = new ComponentMenu("1组件", "主组件1号节点");
            Component Component2 = new ComponentMenu("2组件", "主组件2号节点");
            Component Component3 = new ComponentMenu("3组件", "主组件3号节点");
            Component Component11 = new ComponentMenu("1.1组件", "1号组件1号节点组件");

            mainComponent.Add(Component1);
            mainComponent.Add(Component2);
            mainComponent.Add(Component3);
            Component1.Add(Component11);

            Component item1 = new ComponentItem("1叶子", "一号组件的叶子1", true);
            Component item2 = new ComponentItem("2叶子", "二号组件的叶子1", true);
            Component item3 = new ComponentItem("3叶子", "三号组件的叶子1", true);
            Component item4 = new ComponentItem("4叶子", "1号组件1号节点组件的叶子1", true);
            Component item5 = new ComponentItem("5叶子", "1号组件1号节点组件的叶子2", true);

            Component1.Add(item1);
            Component2.Add(item2);
            Component3.Add(item3);
            Component11.Add(item4);
            Component11.Add(item5);

            //mainComponent.Print();
            ((ComponentMenu)mainComponent).PrintTarget();//二级菜单会被遍历两次

            Console.ReadLine();

        }
    }
}

```