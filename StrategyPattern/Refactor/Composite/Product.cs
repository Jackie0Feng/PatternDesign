/*************************************************************************************
 *
 * 文 件 名:   Product
 * 描    述: Product
 * 
 * 版    本：  V1.0
 * 创 建 者：  jackie 
 * 创建时间：  2024/11/26 9:43:20
*************************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;

namespace PatternDesign.Refactor
{
	public class Product
	{
		// Public field
		public string ID;
		public string Name;
		public Color Color;
		public float Price;
		public EProductSize Size;

		public Product(string iD, string name, Color color, float price, EProductSize size)
		{
			ID = iD;
			Name = name;
			Color = color;
			Price = price;
			Size = size;
		}

		// Private field

	}

	public enum EProductSize
	{
		NotApplicable,
		Small,
		Medium,
		Large,
	}
}