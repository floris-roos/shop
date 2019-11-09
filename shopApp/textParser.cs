using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace shop
{
    public class TextParser : Parser
    {
        private List<Product> finalProducts;
        public override List<Product> ParseProducts(string fileName)
        {
            finalProducts = new List<Product>();

            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            foreach (XmlNode product in doc.SelectNodes("/products/*"))
            {
                string type = product.Name;
                string title = product.Attributes["title"].Value;
                float price = float.Parse(product.Attributes["price"].Value);
                string description = product.Attributes["description"].Value;

                if (type == "digital")
                {
                    string downloadLink = product.Attributes["downloadLink"].Value;

                    finalProducts.Add(new DigitalProduct(title, price, description, downloadLink));
                } else if(type == "physical")
                {

                    float length = float.Parse(product.Attributes["length"].Value);
                    float width = float.Parse(product.Attributes["width"].Value);
                    float height = float.Parse(product.Attributes["height"].Value);
                    Tuple<float, float, float> size = new Tuple<float, float, float>(length, width, height);

                    float weight = float.Parse(product.Attributes["weight"].Value);

                    finalProducts.Add(new PhysicalProduct(title, price, description, size, weight));
                }
            }
            return finalProducts;
        }      
    }
}
