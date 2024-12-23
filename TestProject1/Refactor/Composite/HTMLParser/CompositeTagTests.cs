using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternDesign.Refactor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor.Tests
{
	[TestClass()]
	public class CompositeTagTests
	{
		[TestMethod()]
		public void FormTagToPlainTextStringTest()
		{
			string tagStr = "fomeTag";
			FormTag formTag = new FormTag(1, 2, tagStr, "_");

			string str = formTag.ToPlainTextString();

			Assert.IsTrue(str.Equals(tagStr));
		}

		[TestMethod()]
		public void LineTagToPlainTextStringTest()
		{
			string tagStr = "LinkTag";
			FormTag formTag = new FormTag(1, 2, tagStr, "_");

			string str = formTag.ToPlainTextString();

			Assert.IsTrue(str.Equals(tagStr));
		}
	}
}