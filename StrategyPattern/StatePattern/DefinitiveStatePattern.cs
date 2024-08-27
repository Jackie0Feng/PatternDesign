/*************************************************************************************
 *
 * 文 件 名:   DefinitiveStatePattern
 * 描    述:  终极版状态模式  组合多态消灭Switch语句
 * 1. 解决新增状态时，造成修改判断方法和外部调用方法，违反开放关闭原则的问题
 *	2. 对新增开放，对修改关闭。switch语句必然引起修改。类是最灵活的新增，多态可以用新增解决switch修改问题。
 *	3. 将状态抽象为类，同一调用在不同状态的行为不同，调用抽象为接口，状态类实现接口
 *	4. 涉及到类，就涉及到GC，目前不考虑缓存，最简单的用法就是用一个就new一个，改进可以结合工厂模式
 *	5. 状态升级到类，涉及访问权限问题，最简单的是将状态类设置为嵌套类，可以访问私有成员，就可以不改变原状态机的封装性
 *	
 *	改进点
 *	1. 将状态升级为类，新增状态时就可以新增状态类。这样删掉了switch语句，也无需修改外部接口实现
 *	2. 如果状态类要提出来不当嵌套类，要处理一些访问权限问题
 *	3. 对于修改的容忍程度
 *		a. 修改增加switch语句里有限的判断分支
 *		b. 新增的逻辑不要修改旧的逻辑
 *	4. 新增类型
 *		a. 新增方法
 *		b. 新增类
 *	
 * 版    本：  V1.2
 * 创 建 者：  jackie 
 * 创建时间：  2024/8/27 15:40:54
*************************************************************************************/

using System;
using System.Collections.Generic;

namespace StatePattern
{
	public class DefinitiveStatePattern : IPattern
	{
		// Public field
		public void Main()
		{
			FuncOutside2();
			FuncOutside1();
			FuncOutside2();
			FuncOutside1();
			FuncOutside2();
			FuncOutside1();
			FuncOutside2();
			FuncOutside2();
			FuncOutside1();
			FuncOutside2();
			FuncOutside2();
		}

		public IState CurrentState { get => _currentState; private set => _currentState = value; }

		public void FuncOutside1()
		{
			_currentState.FuncOutside1();
		}

		public void FuncOutside2()
		{
			_currentState.FuncOutside2();
		}

		public DefinitiveStatePattern()
		{
			_currentState = new AState(this);
		}

		public interface IState
		{
			void FuncOutside1();
			void FuncOutside2();
		}

		private IState _currentState;

		private abstract class State : IState
		{
			protected DefinitiveStatePattern statePattern;

			public State(DefinitiveStatePattern statePattern)
			{
				this.statePattern = statePattern;
			}

			public abstract void FuncOutside1();
			public abstract void FuncOutside2();
		}

		private class AState : State
		{
			public AState(DefinitiveStatePattern statePattern) : base(statePattern)
			{
			}

			public override void FuncOutside1()
			{
				statePattern.CurrentState = new BState(statePattern);
				Console.WriteLine("FuncOutside1 Do something on " + statePattern.CurrentState);
			}

			public override void FuncOutside2()
			{
				Console.WriteLine("FuncOutside2 Do something on " + statePattern.CurrentState);
			}
		}
		private class BState : State
		{
			public BState(DefinitiveStatePattern statePattern) : base(statePattern)
			{
			}

			public override void FuncOutside1()
			{
				statePattern.CurrentState = new CState(statePattern);
				Console.WriteLine("FuncOutside1 Do something on " + statePattern._currentState);
			}

			public override void FuncOutside2()
			{
				Console.WriteLine("FuncOutside2 Do something on " + statePattern._currentState);
			}
		}
		private class CState : State
		{
			public CState(DefinitiveStatePattern statePattern) : base(statePattern)
			{
			}

			public override void FuncOutside1()
			{
				statePattern.CurrentState = new DState(statePattern);
				Console.WriteLine("FuncOutside1 Do something on " + statePattern._currentState);
			}

			public override void FuncOutside2()
			{
				Console.WriteLine("FuncOutside2 Do something on " + statePattern._currentState);
			}
		}

		private class DState : State
		{
			public DState(DefinitiveStatePattern statePattern) : base(statePattern)
			{
			}

			public override void FuncOutside1()
			{
				statePattern.CurrentState = new AState(statePattern);
				Console.WriteLine("FuncOutside1 Do something on " + statePattern._currentState);
			}

			public override void FuncOutside2()
			{
				Console.WriteLine("FuncOutside2 Do something on " + statePattern._currentState);
			}
		}
	}
}