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
