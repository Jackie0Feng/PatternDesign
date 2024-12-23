using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public class Tag
	{
		public int TagBegin;
		public int TagEnd;
		public string TagContent;
		public string TagLine;

		public Tag(int tagBegin, int tagEnd, string tagContent, string tagLine)
		{
			TagBegin = tagBegin;
			TagEnd = tagEnd;
			TagContent = tagContent;
			TagLine = tagLine;
		}
	}
}
