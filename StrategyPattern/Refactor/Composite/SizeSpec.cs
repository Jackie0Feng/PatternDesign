using System;

namespace PatternDesign.Refactor
{
	public class SizeSpec : Spec
	{
		private EProductSize _size;

		public SizeSpec(EProductSize size)
		{
			this._size = size;
		}

		public override bool IsSatisfiedBy(Product product)
		{
			return product.Size == _size;
		}
	}
}