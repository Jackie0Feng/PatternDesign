using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public class Order
	{
		public decimal TotalAmount { get; set; }
		public EPayType PaymentMethod { get; set; }
		public enum EPayType
		{
			CreditCard,
			PayPal,
			Cash
		}

		public decimal CalculateTotal()
		{
			switch (PaymentMethod)
			{
				case EPayType.CreditCard:
					return TotalAmount * 0.95m; // 5% discount
				case EPayType.PayPal:
					return TotalAmount * 0.90m; // 10% discount
				case EPayType.Cash:
					return TotalAmount * 0.98m; // 2% discount
				default:
					return TotalAmount; // No discount
			}
		}
	}
}

