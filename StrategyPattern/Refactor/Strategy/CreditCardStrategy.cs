using PatternDesign.Refactor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public class CreditCardStrategy : OrderStrategy
	{
		public CreditCardStrategy() { }

		public CreditCardStrategy(OrderRefacted order) : base(order)
		{
		}

		public override decimal CalculateTotal()
		{
			return order.TotalAmount * 0.95m; // 5% discount
		}
	}
}
