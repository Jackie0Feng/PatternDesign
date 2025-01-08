using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public class PayPalStrategy : OrderStrategy
	{
		public PayPalStrategy() { }

		public override decimal CalculateTotal()
		{
			return order.TotalAmount * 0.90m; // 10% discount
		}
	}
}
