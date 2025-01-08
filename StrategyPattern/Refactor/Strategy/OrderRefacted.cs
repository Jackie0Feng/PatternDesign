using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public class OrderRefacted
	{
		public decimal TotalAmount { get; set; }
		public EPayType PaymentMethod { get; set; }
		public enum EPayType
		{
			CreditCard,
			PayPal,
			Cash
		}

		public decimal CalculateTotal(OrderStrategy orderStrategy)
		{
			if (orderStrategy.Order == null)
				orderStrategy.Order = this;
			return orderStrategy.CalculateTotal();
		}
	}
}
