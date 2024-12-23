using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public abstract class CompositeTag : Tag
	{
		protected NodeVector children;
		public CompositeTag(int tagBegin, int tagEnd, string tagContent, string tagLine) : base(tagBegin, tagEnd, tagContent, tagLine)
		{
			children = new NodeVector(new List<Node>() { new Node(tagContent) });
		}

		public string ToPlainTextString()
		{
			StringBuilder sb = new StringBuilder();
			foreach (Node node in GetChildren())
			{
				sb.Append(node.ToPlainTextString());
			}
			return sb.ToString();
		}

		protected virtual IEnumerable<Node> GetChildren()
		{
			return children.Nodes;
		}
	}
}
