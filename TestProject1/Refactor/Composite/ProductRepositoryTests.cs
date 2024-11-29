using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternDesign.Refactor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDesign.Refactor.Tests
{
	[TestClass()]
	public class ProductRepositoryTests
	{
		private Product _fireTruck = new Product("f1234", "Fire Truck", Color.Red, 8.95f, EProductSize.Medium);
		private Product _barbieClassic = new Product("b7654", "barbieClassic", Color.Yellow, 15.95f, EProductSize.Small);
		private Product _frisbee = new Product("f4321", "_frisbee", Color.Pink, 9.99f, EProductSize.Large);
		private Product _baseball = new Product("b2343", "_baseball", Color.White, 8.95f, EProductSize.NotApplicable);
		private Product _toyConvertible = new Product("p1112", "_toyConvertible", Color.Red, 230.00f, EProductSize.NotApplicable);

		protected ProductRepository SetUp()
		{
			var repository = new ProductRepository();
			repository.AddProduct(_fireTruck);
			repository.AddProduct(_barbieClassic);
			repository.AddProduct(_frisbee);
			repository.AddProduct(_baseball);
			repository.AddProduct(_toyConvertible);
			return repository;
		}

		[TestMethod()]
		public void TestFindByColor()
		{
			ProductRepository repository = SetUp();
			List<Product> products = repository.SelectBy(new ColorSpec(Color.Red));
			Assert.AreEqual(2, products.Count);
			Assert.IsTrue(products.Contains(_fireTruck));
			Assert.IsTrue(products.Contains(_toyConvertible));
		}

		[TestMethod()]
		public void TestFindByColorSizeAndBelowPrice()
		{
			ProductRepository repository = SetUp();
			CompositeSpec specs = new CompositeSpec();
			specs.Add(new ColorSpec(Color.Red));
			specs.Add(new SizeSpec(EProductSize.Small));
			specs.Add(new BelowPriceSpec(10.00f));

			List<Product> products = repository.SelectBy(specs);
			Assert.AreEqual(0, products.Count);
		}

		[TestMethod()]
		public void TestFindByRedOrYellowAndUpTenAndSmall()
		{
			ProductRepository repository = SetUp();
			CompositeSpec specs = new CompositeSpec();
			specs.Add(new OrSpec(new ColorSpec(Color.Red), new ColorSpec(Color.Yellow)));
			specs.Add(new SizeSpec(EProductSize.Small));
			specs.Add(new NotSpec(new BelowPriceSpec(10.00f)));

			List<Product> products = repository.SelectBy(specs);
			Assert.AreEqual(1, products.Count);
			Assert.IsTrue(products.Contains(_barbieClassic));
		}
	}
}