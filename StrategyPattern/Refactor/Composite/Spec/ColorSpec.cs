using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor
{
	public class ColorSpec : Spec
	{
		private Color _color;

		public ColorSpec(Color red)
		{
			this._color = red;
		}

		public override bool IsSatisfiedBy(Product product)
		{
			return product.Color == _color;
		}
	}
}
