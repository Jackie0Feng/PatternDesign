using System;

namespace PatternDesign.Refactor
{
	public abstract class Spec
	{
		public abstract bool IsSatisfiedBy(Product product);
	}
}