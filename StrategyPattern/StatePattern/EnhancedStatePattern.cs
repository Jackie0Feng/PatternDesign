/*************************************************************************************
 *
 * 文 件 名:   EnhancedStatePattern
 * 描    述:  改进版状态模式，重构提取了公用方法
 * 1. 主体：状态图
 * 2. 次体：状态
 * 3. 行为：判断状态，切换状态，不同状态不同的行为
 * 
 * 改进点
 * 1. 提出判断状态，切换状态的逻辑
 *		a. 新增外部行为更为方便了，不用复制粘贴一长串的switch语句，只用新增一个外部方法和数个对应状态的内部方法即可。满足开放关闭原则。
 *		b. 但是新增状态比较麻烦，需要修改判断状态方法，修改外部调用方法，新增对应状态方法。
 * 
 * 版    本：  V1.1
 * 创 建 者：  jackie 
 * 创建时间：  2024/8/27 11:47:07
*************************************************************************************/

using StatePattern;
using System;
using System.Collections.Generic;

namespace StatePattern
{
	public class EnhancedStatePattern : IPattern
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
		}

		public void FuncOutside1()
		{
			JudgeStateExecution(_currentState, FuncOutside1OnAState, FuncOutside1OnBState, FuncOutside1OnCState);
		}

		public void FuncOutside2()
		{
			JudgeStateExecution(_currentState, FuncOutside2OnAState, FuncOutside2OnBState, FuncOutside2OnCState);
		}

		// Private field
		private enum EState
		{
			AState,
			BState,
			CState
		};

		private EState _currentState = EState.AState;

		private void FuncOutside1OnAState()
		{
			ChangeState(EState.BState);
			Console.WriteLine("FuncOutside1 Do something on " + _currentState);
		}
		private void FuncOutside1OnBState()
		{
			ChangeState(EState.CState);
			Console.WriteLine("FuncOutside1 Do something on " + _currentState);
		}
		private void FuncOutside1OnCState()
		{
			ChangeState(EState.AState);
			Console.WriteLine("FuncOutside1 Do something on " + _currentState);
		}

		private void FuncOutside2OnAState()
		{
			Console.WriteLine("FuncOutside2 Do something on " + _currentState);
		}
		private void FuncOutside2OnBState()
		{
			Console.WriteLine("FuncOutside2 Do something on " + _currentState);
		}
		private void FuncOutside2OnCState()
		{
			Console.WriteLine("FuncOutside2 Do something on " + _currentState);
		}

		/// <summary>
		/// 将判断逻辑提出
		/// </summary>
		private void JudgeStateExecution(EState state, Action Aaction, Action Baction, Action Caction)
		{
			switch (state)
			{
				case EState.AState:
					Aaction.Invoke();
					break;
				case EState.BState:
					Baction.Invoke();
					break;
				case EState.CState:
					Caction.Invoke();
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// 将改变状态逻辑提出
		/// </summary>
		/// <param name="state"></param>
		private void ChangeState(EState state)
		{
			_currentState = state;
		}
	}
}