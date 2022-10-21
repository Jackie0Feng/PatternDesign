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
