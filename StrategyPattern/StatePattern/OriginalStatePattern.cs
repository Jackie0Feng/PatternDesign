/*************************************************************************************
 *
 * 文 件 名:   OriginalStatePattern
 * 描    述:  最原始的，使用基本的顺序执行算法实现状态图逻辑
 * 1. 主体同一个调用在不同状态下的行为不同，特定行为会导致状态的改变
 * 2. 主体：状态类，映射状态图本身
 * 
 * 版    本：  V1.0
 * 创 建 者：  jackie 
 * 创建时间：  2024/8/26 18:23:00
*************************************************************************************/

using System;
using System.Collections.Generic;

namespace StatePattern
{
	public class OriginalStatePattern : IPattern
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
			switch (_currentState)
			{
				case EState.AState:
					FuncOutside1OnAState();
					break;
				case EState.BState:
					FuncOutside1OnBState();
					break;
				case EState.CState:
					FuncOutside1OnCState();
					break;
				default:
					break;
			}
		}
		public void FuncOutside2()
		{
			switch (_currentState)
			{
				case EState.AState:
					Console.WriteLine("FuncOutside2 Do something on " + _currentState);
					break;
				case EState.BState:
					Console.WriteLine("FuncOutside2 Do something on " + _currentState);
					break;
				case EState.CState:
					Console.WriteLine("FuncOutside2 Do something on " + _currentState);
					break;
				default:
					break;
			}
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
			_currentState = EState.BState;
			Console.WriteLine("FuncOutside1 Do something on " + _currentState);
		}
		private void FuncOutside1OnBState()
		{
			_currentState = EState.CState;
			Console.WriteLine("FuncOutside1 Do something on " + _currentState);
		}
		private void FuncOutside1OnCState()
		{
			_currentState = EState.AState;
			Console.WriteLine("FuncOutside1 Do something on " + _currentState);
		}
	}
}