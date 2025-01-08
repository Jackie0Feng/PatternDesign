using PatternDesign.Refactor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public class DefaultStrategy : OrderStrategy
	{
		public DefaultStrategy() { }
		public DefaultStrategy(OrderRefacted order) : base(order)
		{
		}

		public override decimal CalculateTotal()
		{
			return order.TotalAmount; // No discount
		}
	}
}
