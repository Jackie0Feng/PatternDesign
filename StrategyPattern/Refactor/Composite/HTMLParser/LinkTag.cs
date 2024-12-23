using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace PatternDesign.Refactor
{
	public class LinkTag : CompositeTag
	{
		public LinkTag(int tagBegin, int tagEnd, string tagContent, string tagLine) : base(tagBegin, tagEnd, tagContent, tagLine)
		{
		}

		protected override IEnumerable<Node> GetChildren()
		{
			return children.Nodes.ToArray();
		}
	}
}
