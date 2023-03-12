using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Products
{
    internal class Clothes : Product
    {
        private ushort size;

        public ushort? Size
        {
            get => size;
            set => size = value ??
                   throw new ArgumentNullException();
        }

        public Clothes(string name,
                       string img,
                       string country,
                       string color,
                       string description,
                       double? price,
                       ushort? size,
                       byte? sale = 0) : base(Lab4.Products.Category.Clothes, name, img, country, color, description, price, sale)
        {
            this.Size = size; 
        }

        public override bool Equals(object obj) => base.Equals(obj) &&
                                                   obj is Clothes p &&
                                                   p.Size == this.Size;
    }
}