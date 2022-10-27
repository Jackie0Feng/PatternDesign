using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverPattern;
using StrategyPattern;
using DecoratorPattern;
using FactoryPattern;
using AbstractFactoryPattern;
using SingletonPattern;
using CommandPattern;
using AdapterPattern;
using FacadePattern;
using TemplatePattern;

public interface IPattern
{
    void Main();
}




internal class main
{
    public void Delete()
    {
        int[] a = { 1, 2, 3, 2, 3, 2, 5, 6, 7 };

        int j = 0;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == 2)
            {
                j++;
            }
            if ((i + j) < a.Length)
                a[i] = a[i + j];
            else
                a[i] = 0;
        }

        foreach (var item in a)
        {
            Console.WriteLine(item);
        }
    }
    public static void Main()
    {
        //IPattern pattern = new StrategyPatternMain();
        //IPattern pattern = new ObserverPatternMain();
        //IPattern pattern = new DecoratorPatternMain();
        //IPattern pattern = new FactoryPatternMain();
        //IPattern pattern = new AbstractFactoryPatternMain();
        //IPattern pattern = new SingletonPatternMain();
        //IPattern pattern = new CommandPatternMain();
        //IPattern pattern = new AdapterPatternMain();
        //IPattern pattern = new FacadePatternMain();
        IPattern pattern = new TemplatePatternMain();
        pattern.Main();
    }
}
