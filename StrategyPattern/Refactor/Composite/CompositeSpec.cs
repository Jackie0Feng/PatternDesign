using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public class CompositeSpec : Spec
	{
		private List<Spec> _specs = new List<Spec>();

		public void Add(Spec spec)
		{
			_specs.Add(spec);
		}

		public ReadOnlyCollection<Spec> Specs { get => _specs.AsReadOnly(); }

		public override bool IsSatisfiedBy(Product product)
		{
			bool result = true;
			foreach (var spec in Specs)
			{
				result &= spec.IsSatisfiedBy(product);
				if (!result) break;
			}
			return result;
		}
	}
}
