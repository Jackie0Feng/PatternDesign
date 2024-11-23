using PatternDesign;

namespace TestProject1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			string Expected = "Hello World!";

			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);

				TestClass testClass = new TestClass();
				testClass.HelloWorld();

				var result = sw.ToString().Trim();
				Assert.AreEqual(Expected, result);
			}
		}
	}
}