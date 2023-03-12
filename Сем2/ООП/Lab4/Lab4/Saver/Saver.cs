using Lab4.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab4.Saver
{
    internal class Saver
    {
        private string path;
        private StreamWriter sw;
        private bool append;
        public string Path
        {
            get => path;
            set
            {
                path = value ??
                       throw new ArgumentNullException();
            }
        }

        public Saver(string path, bool append = true)
        {
            sw = null;
            this.append = append;
            this.Path = path;
        }

        public void ClearFile()
        { 
            sw = new StreamWriter(Path, false);
            sw.Close();
        }
        public void ToJson(Product product)
        {
            using (sw = new StreamWriter(Path, this.append))
            {
                string json = JsonConvert.SerializeObject(product);
                sw.WriteLine(json);
            }
        }

        public void ToJson(List<Product> prods) => prods.ForEach(p => ToJson(p));

        public List<Product> FromJson()
        {
            List<Product> products = new List<Product>();
            Product product = null;
            string json;

            if(sw != null)
            {
                sw.Close();
            }

            using(StreamReader sr = new StreamReader(Path))
            {
                while(!sr.EndOfStream)
                {
                    json = sr.ReadLine();

                    if(json is null)
                    {
                        continue;
                    }

                    try
                    {
                        product = JsonConvert.DeserializeObject<Clothes>(json);
                    }
                    catch
                    {
                        try
                        {
                            if (product is null)
                            {
                                product = JsonConvert.DeserializeObject<Food>(json);
                            }
                        } catch {
                            if (product is null)
                            {
                                product = JsonConvert.DeserializeObject<Toy>(json);
                            }
                        }
                    }

                    products.Add(product);
                }
            }

            return products;
        }
    }
}
