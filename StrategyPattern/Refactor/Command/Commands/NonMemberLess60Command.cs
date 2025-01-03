using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public class NonMemberLess60Command : CommandBase
	{
		public override string Execute()
		{
			return "5% discount";
		}
	}
}
