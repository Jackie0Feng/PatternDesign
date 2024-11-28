using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor.Test
{
	public class CheckingAccount : IAccount
	{
		private double m_balance;
		private string m_name;

		public CheckingAccount(string name, double currentBalance)
		{
			this.m_name = name;
			this.m_balance = currentBalance;
		}

		public double Balance { get => m_balance; }

		public void Withdraw(double amount)
		{
			if (m_balance >= amount)
			{
				m_balance -= amount;
			}
			else
			{
				throw new ArgumentException(nameof(amount), "Withdrawal exceeds balance!");
			}
		}
	}
}
