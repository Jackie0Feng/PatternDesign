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
	public class ShopTests
	{
		[TestMethod()]
		public void CalculateDiscountTest()
		{
			// 假设我们有一个用户对象，包含年龄和会员状态
			User user = new User
			{
				Age = 25,
				IsMember = true
			};

			Shop shop = new Shop();

			// 根据用户的年龄和会员状态计算折扣
			string discount = shop.CalculateDiscount(user);

			// 输出折扣结果
			Console.WriteLine($"Your discount is: {discount}");

			Assert.IsTrue(discount.Equals("10% member discount"));
		}

		[TestMethod()]
		public void CalculateDiscountRefactedTest()
		{
			// 假设我们有一个用户对象，包含年龄和会员状态
			User user = new User
			{
				Age = 25,
				IsMember = true
			};

			ShopRefacted shop = new ShopRefacted();

			// 根据用户的年龄和会员状态计算折扣
			string discount = shop.CalculateDiscount(user);

			// 输出折扣结果
			Console.WriteLine($"Your discount is: {discount}");

			Assert.IsTrue(discount.Equals("10% member discount"));
		}
	}
}