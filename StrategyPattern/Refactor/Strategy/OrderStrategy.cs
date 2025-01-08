using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public abstract class OrderStrategy
	{
		protected OrderRefacted order;
		public OrderStrategy() { }

		public OrderStrategy(OrderRefacted order)
		{
			this.order = order;
		}

		public OrderRefacted Order { get => order; set => order = value; }

		public abstract decimal CalculateTotal();
	}
}
