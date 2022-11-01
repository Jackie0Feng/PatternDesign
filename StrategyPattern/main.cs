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
using IteratorPattern;

public interface IPattern
{
    void Main();
}


internal class main
{
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
        IPattern pattern = new IteratorPatternMain();
        pattern.Main();

    }
}
