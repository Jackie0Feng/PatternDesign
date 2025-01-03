using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public class MemberLess18Command : CommandBase
	{
		public override string Execute()
		{
			return "20% member youth discount";
		}
	}
}
