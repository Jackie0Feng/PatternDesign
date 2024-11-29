using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public class OrSpec : CompositeSpec
	{
		public OrSpec(Spec spec1, Spec spec2)
		{
			this.Add(spec1);
			this.Add(spec2);
		}

		public override bool IsSatisfiedBy(Product product)
		{
			return Specs[0].IsSatisfiedBy(product) || Specs[1].IsSatisfiedBy(product);
		}
	}
}
