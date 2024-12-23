using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public class Node
	{
		public string Msg;

		public Node(string msg)
		{
			Msg = msg;
		}

		public virtual String ToPlainTextString()
		{
			return Msg;
		}
	}
}
