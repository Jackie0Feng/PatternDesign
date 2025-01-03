using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public class ShopRefacted
	{
		public string CalculateDiscount(User user)
		{
			Dictionary<int, CommandBase> commands = InitCommandDic();

			return commands[GetCommandID(user)].Execute();
		}

		private Dictionary<int, CommandBase> InitCommandDic()
		{
			Dictionary<int, CommandBase> commands = new Dictionary<int, CommandBase>();
			commands.Add(11018, new MemberLess18Command());
			commands.Add(11060, new MemberLess60Command());
			commands.Add(11000, new MemberCommand());
			commands.Add(10018, new NonMemberLess18Command());
			commands.Add(10060, new NonMemberLess60Command());
			commands.Add(10000, new NonMemberCommand());

			return commands;
		}

		private int GetCommandID(User user)
		{
			int result = 0;

			if (user.IsMember)
			{
				if (user.Age < 18)
				{
					result = 11018;
				}
				else if (user.Age < 60)
				{
					result = 11060;
				}
				else
				{
					result = 11000;
				}
			}
			else
			{
				if (user.Age < 18)
				{
					result = 10018;
				}
				else if (user.Age < 60)
				{
					result = 10060;
				}
				else
				{
					result = 10000;
				}
			}

			return result;
		}
	}
}
