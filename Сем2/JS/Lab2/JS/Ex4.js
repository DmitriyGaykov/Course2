class Product {
    id;
    size;
    color;
    price;
    sale;
    endPrice;
    get ID() {
        return this.id;
    }
    get Size() {
        return this.size;
    }
    get Color() {
        return this.color;
    }
    get Price() {
        return this.endPrice;
    }
    set Price(v) {
        this.price = v;
        this.endPrice = (100 - this.sale) * this.price / 100;
    }
    constructor(ID, Size, Color, Price, Sale = 0) {
        this.id = ID;
        this.size = Size;
        this.color = Color;
        this.price = Price;
        this.sale = Sale;
        this.endPrice = (100 - Sale) * Price / 100;
    }
    toString() {
        return `ID: ${this.id}, Size: ${this.size}, Color: ${this.color}, Price: ${this.price}, Sale: ${this.sale}, EndPrice: ${this.endPrice}`;
    }
}
const product1 = new Product(1, 23, "Red", 100, 10);
const product2 = new Product(2, 43, "Yellow", 20, 20);
const product3 = new Product(3, 53, "Black", 300, 30);
const product4 = new Product(4, 51, "Red", 400, 40);
const products = [product1, product2, product3, product4];
console.log(`
    Exesize 4
    Один из продуктов: ${product3.toString()}
    `);
export {};
