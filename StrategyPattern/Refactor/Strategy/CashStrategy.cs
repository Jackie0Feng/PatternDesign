using PatternDesign.Refactor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public class CashStrategy : OrderStrategy
	{
		public CashStrategy() { }
		public CashStrategy(OrderRefacted order) : base(order)
		{
		}

		public override decimal CalculateTotal()
		{
			return order.TotalAmount * 0.98m; // 2% discount
		}
	}
}