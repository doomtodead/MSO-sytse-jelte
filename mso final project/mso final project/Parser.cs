using System;
using System.Collections.Generic;
using System.Text;

namespace mso_final_project
{
    public class Parser
    {
        String filePath;
        List<string[]> descriptions = new List<string[]>();
        public List<Product> allProducts = new List<Product>();
        public Parser()
        {
            filePath = Environment.CurrentDirectory + "/itemInfo.txt";
            foreach (string line in System.IO.File.ReadAllLines(filePath))
            {
                descriptions.Add(line.Split('-'));
            }

            foreach (string[] description in descriptions)
            {
                if (description[1] == "Digital")
                    allProducts.Add(new DigitalProduct(description[0], description[2], float.Parse(description[3]), description[4]));

                else if (description[1] == "Physical")
                    allProducts.Add(new PhysicalProduct(description[0], description[2], float.Parse(description[3])));
            }
        }

        public Product Parse(string name)
        {
            foreach(string[] description in descriptions)
            {
                if (name == description[0])
                {
                    if (description[1] == "Digital")
                        return new DigitalProduct(description[0], description[2], float.Parse(description[3]), description[4]);

                    else if (description[1] == "Physical")
                        return new PhysicalProduct(description[0], description[2], float.Parse(description[3]));

                    else
                    {
                        Console.WriteLine("het tweede argument van product " + name + "is niet herkent");
                    }
                }
            }

            Console.WriteLine("er is een niet bestaant product opgevraagd");
            return null;
        }

    }
}
