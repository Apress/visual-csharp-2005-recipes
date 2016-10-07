using System;
using System.Xml;

namespace Apress.VisualCSharpRecipes.Chapter06
{
	public class FindNodesByName
	{
		[STAThread]
		private static void Main()
		{
			// Load the document.
			XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\ProductCatalog.xml");

            // Retrieve all prices.
			XmlNodeList prices = doc.GetElementsByTagName("productPrice");
			
			// Retrieve a reference to the first product.
			//XmlNode product = doc.GetElementsByTagName("products")[0];
			// Find the price under this product.
			//XmlNode price = ((XmlElement)product).GetElementsByTagName("productPrice")[0];
            
			decimal totalPrice = 0;
            foreach (XmlNode price in prices)
			{
				// Get the inner text of each matching element.
				totalPrice += Decimal.Parse(price.ChildNodes[0].Value);
			}
			
			Console.WriteLine("Total catalog value: " + totalPrice.ToString());
        	Console.ReadLine();
		}
	}
}
