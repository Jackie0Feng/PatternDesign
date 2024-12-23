using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public class NodeVector
	{
		public List<Node> Nodes = new List<Node>();

		public NodeVector(List<Node> nodes)
		{
			Nodes = nodes;
		}
	}
}
