using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Products
{
    public abstract class Product
    {
        protected readonly string id = Guid.NewGuid().ToString();
        protected Category category;
        protected string name;
        protected string img;
        protected string country;
        protected string color;
        protected string description;
        protected double price;
        protected byte sale;

        public string ID => id;
        public Category? Category
        {
            get => this.category;
            set => this.category = value ??
                   throw new ArgumentNullException();
        }

        public string Name
        {
            get => this.name;
            set => this.name = value ??
                   throw new ArgumentNullException();
        }

        public string Img
        {
            get => this.img;
            set => this.img = value ??
                   throw new ArgumentNullException();
        }
        
        public string Country
        {
            get => this.country;
            set => this.country = value ??
                   throw new ArgumentNullException();
        }

        public string Color
        {
            get => this.color;
            set => this.color = value ??
                   throw new ArgumentNullException();
        }

        public string Description
        {
            get => this.description;
            set => this.description = value ??
                   throw new ArgumentNullException();
        }

        public byte? Sale
        {
            get => this.sale;
            set
            {
                this.sale = value ??
                            throw new ArgumentNullException();

                if (value < 0 || value > 100)
                {
                    throw new Exception("Скидка должна быть от 0 до 100%");
                }
            }
        }

        public double? Price
        {
            get => Math.Round(this.price * (100.0 - sale) / 100.0);
            set
            {
                if(value < 0)
                {
                    throw new Exception("Цена не может быть меньше 0");
                }

                if(value is null)
                {
                    throw new ArgumentNullException();
                }

                this.price = value.Value;
            }
        }


        public Product(Category? category,
                       string name,
                       string img,
                       string country,
                       string color,
                       string description,
                       double? price,
                       byte? sale = 0)
        {
            this.Category = category;
            this.Name = name;
            this.Img = img;
            this.Country = country;
            this.Color = color;
            this.Description = description;
            this.Price = price;
            this.Sale = sale;
        }

        public override string ToString() => $"Category: {this.Category}\t Name: {this.Name}\t Price: {this.Price}";
        public override bool Equals(object obj) => obj is Product p &&
                                                   p.Category == this.Category &&
                                                   p.Name == this.Name;
    }

    public enum Category
    {
        Toys,
        Food,
        Clothes
    }
}
