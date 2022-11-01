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
