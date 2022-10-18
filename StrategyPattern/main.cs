using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverPattern;
using StrategyPattern;
using DecoratorPattern;

namespace PatternDesign
{
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
            IPattern pattern = new DecoratorPatternMain();
            pattern.Main();

        }
    }
}
