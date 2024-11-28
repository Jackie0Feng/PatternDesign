/*************************************************************************************
 *
 * 文 件 名:   ProductRepository
 * 描    述: ProductRepository
 * 
 * 版    本：  V1.0
 * 创 建 者：  jackie 
 * 创建时间：  2024/11/26 9:42:29
*************************************************************************************/

using System.Collections.Generic;

namespace PatternDesign.Refactor
{
	public class ProductRepository
	{
		// Public field

		// Private field
		private List<Product> _products = new List<Product>();

		public void AddProduct(Product product)
		{
			_products.Add(product);
		}

		public List<Product> SelectBy(Spec spec)
		{
			var result = new List<Product>();
			foreach (var product in _products)
			{
				if (spec.IsSatisfiedBy(product))
					result.Add(product);
			}
			return result;
		}
	}
}