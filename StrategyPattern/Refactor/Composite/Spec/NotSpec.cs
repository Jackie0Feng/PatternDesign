using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public class NotSpec : CompositeSpec
	{
		public NotSpec(Spec spec1)
		{
			this.Add(spec1);
		}

		public override bool IsSatisfiedBy(Product product)
		{
			return !Specs[0].IsSatisfiedBy(product);
		}
	}
}
