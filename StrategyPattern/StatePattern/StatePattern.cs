using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern0
{
	abstract class State
	{
		public abstract void Start();

		public abstract void End();
	}

	class Context
	{
		public State beginState;
		public State endState;

		State state;

		public Context()
		{
			beginState = new BeginState(this);
			endState = new EndState(this);

			state = beginState;
		}

		public void SetState(State state)
		{
			this.state = state;
		}

		public void Start()
		{
			state.Start();
		}

		public void End()
		{
			state.End();
		}

	}



	class BeginState : State
	{

		Context context;
		public BeginState(Context context)
		{
			this.context = context;
		}
		public override void Start()
		{
			Console.WriteLine("开始了");
			context.SetState(context.endState);
		}

		public override void End()
		{
			throw new NotImplementedException();
		}
	}

	class EndState : State
	{
		Context context;
		public EndState(Context context)
		{
			this.context = context;
		}

		public override void Start()
		{
			throw new NotImplementedException();
		}

		public override void End()
		{
			Console.WriteLine("结束了");
			context.SetState(context.beginState);
		}
	}


	internal class StatePatternMain : IPattern
	{
		public void Main()
		{
			Context context = new Context();
			context.Start();
			context.End();
		}
	}
}
