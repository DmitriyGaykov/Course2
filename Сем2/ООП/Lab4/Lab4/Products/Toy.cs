using System;

namespace Lab4.Products
{
    internal class Toy : Product
    {
        private Type type;

        public Type? ToyType
        {
            get => type;
            set => type = value ??
                   throw new ArgumentNullException();
        }

        public Toy(string name,
                   string img,
                   string country,
                   string color,
                   string description,
                   double? price,
                   Toy.Type? type,
                   byte? sale = 0) : base(Lab4.Products.Category.Toys, name, img, country, color, description, price, sale)
        {
            this.ToyType = type;
        }

        public enum Type
        {
            Car,
            Animal,
            Puzzle
        }
    }
}

// Копайлот ты рабоаешь?   