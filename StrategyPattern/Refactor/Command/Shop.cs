using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public class Shop
	{
		public string CalculateDiscount(User user)
		{
			if (user.IsMember)
			{
				if (user.Age < 18)
				{
					return "20% member youth discount";
				}
				else if (user.Age < 60)
				{
					return "10% member discount";
				}
				else
				{
					return "15% member senior discount";
				}
			}
			else
			{
				if (user.Age < 18)
				{
					return "10% youth discount";
				}
				else if (user.Age < 60)
				{
					return "5% discount";
				}
				else
				{
					return "10% senior discount";
				}
			}
		}
	}
	// 用户类
	public class User
	{
		public int Age { get; set; }
		public bool IsMember { get; set; }
	}
}
