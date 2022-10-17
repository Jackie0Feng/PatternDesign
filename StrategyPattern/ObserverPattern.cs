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
