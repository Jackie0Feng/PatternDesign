
namespace PatternDesign.Refactor
{
	public class BelowPriceSpec : Spec
	{
		private float _price;

		public BelowPriceSpec(float price)
		{
			this._price = price;
		}

		public override bool IsSatisfiedBy(Product product)
		{
			return product.Price < _price;
		}
	}
}