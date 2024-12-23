using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternDesign.Refactor
{
	public class FormTag : CompositeTag
	{
		public FormTag(int tagBegin, int tagEnd, string tagContent, string tagLine) : base(tagBegin, tagEnd, tagContent, tagLine)
		{
		}
	}
}
