using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern
{
    /// <summary>
    /// 备忘录类
    /// </summary>
    public class Memento<T>
    {
        T state;
        public Memento(T state)
        {
            this.state = state;
        }

        public T GetState()
        {
            return state;
        }
    }

    public class Originator<T>
    {
        T state;

        public void SetState(T memento)
        {
            this.state = memento;
        }

        public T GetState()
        {
            return state;
        }

        public Memento<T> SaveStateToMemento()
        {
            return new Memento<T>(state);
        }

        public void GetStateFromMemento(Memento<T> Memento)
        {
            state = Memento.GetState();
        }
    }

    public class CareTaker<T>
    {
        List<Memento<T>> mementos = new List<Memento<T>>();

        public void Add(Memento<T> memento)
        {
            mementos.Add(memento);
        }

        public Memento<T> GetMemento(int index)
        {
            return mementos[index];
        }
    }


    internal class MementoPatternMain : IPattern
    {
        public void Main()
        {
            Originator<string> originator = new Originator<string>();
            CareTaker<string> careTaker = new CareTaker<string>();
            originator.SetState("State #1");
            originator.SetState("State #2");
            careTaker.Add(originator.SaveStateToMemento());
            originator.SetState("State #3");
            careTaker.Add(originator.SaveStateToMemento());
            originator.SetState("State #4");

            Console.WriteLine(("Current State: " + originator.GetState()));
            originator.GetStateFromMemento(careTaker.GetMemento(0));
            Console.WriteLine("First saved State: " + originator.GetState());
            originator.GetStateFromMemento(careTaker.GetMemento(1));
            Console.WriteLine("Second saved State: " + originator.GetState());
        }
    }
}
