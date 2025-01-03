using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public class MemberCommand : CommandBase
	{
		public override string Execute()
		{
			return "15% member senior discount";
		}
	}
}
