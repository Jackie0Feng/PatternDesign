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
            for (int i = 0; i < components.Count; i++)
            {
                GetChild(i).Print();
            }
            //使用迭代器遍历
            //IIterator iterator = new ListIterator<Component>(components);
            //while (iterator.HasNext())
            //{
            //    ((Component)iterator.Next()).Print();
            //}
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

            mainComponent.Print();
            //((ComponentMenu)mainComponent).PrintTarget();//二级菜单会被遍历两次

            Console.ReadLine();

        }
    }
}
