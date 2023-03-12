using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Products
{
    internal class Food : Product
    {
        private Type type;

        public Type? FoodType
        {
            get => type;
            set => type = value ??
                   throw new ArgumentNullException();
        }

        public Food(string name,
                    string img,
                    string country,
                    string color,
                    string description,
                    double? price,
                    Type? type,
                    byte? sale = 0) : base(Lab4.Products.Category.Food, name, img, country, color, description, price, sale)
        {
            this.FoodType = type;
        }

        public enum Type
        {
            Chocolate,
            Vegetable,
            Meat,
            Candy
        }
    }
}
