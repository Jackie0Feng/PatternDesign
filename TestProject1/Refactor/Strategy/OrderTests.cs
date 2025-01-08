using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternDesign.Refactor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor.Tests
{
	[TestClass()]
	public class OrderTests
	{
		[TestMethod()]
		public void CalculateTotalTest()
		{
			var order = new Order();
			order.TotalAmount = 100;
			order.PaymentMethod = Order.EPayType.CreditCard;

			decimal result = 95;
			Assert.IsTrue(order.CalculateTotal() == result);
		}

		[TestMethod()]
		public void CalculateRefactedTotalTest()
		{
			var order = new OrderRefacted();
			order.TotalAmount = 100;
			order.PaymentMethod = OrderRefacted.EPayType.CreditCard;

			decimal result = 95;
			Assert.IsTrue(order.CalculateTotal(new CreditCardStrategy()) == result);
		}
	}
}