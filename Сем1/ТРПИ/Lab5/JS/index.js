const Sneakers = 0;
const Boots = 1;
const Sandals = 2;
const IDGen = idMaker();
let StrType = new Map();
StrType.set(Sneakers, "Sneakers");
StrType.set(Boots, "Boots");
StrType.set(Sandals, "Sandals");
let TypeStr = new Map();
TypeStr.set("Кроссовки", Sneakers);
TypeStr.set("Ботинки", Boots);
TypeStr.set("Сандали", Sandals);
const MAX_COUNT = 20;
class Product {
    // #endregion
    // #region Ctors
    constructor(number, name, price, size, color, path, sale = 0) {
        this.sale = 0;
        this.ViewTemplate = `
    <section class="product" id="ID">
            <img src="IMG" alt="" class="product-img">
            <h1 class="product-title">TITLE</h1>
            <p class="product-size">Size: <span>SIZE</span></p>
            <p class="product-color">Color: <span>COLOR</span></p>
            <p class="product-price">Цена: <span>PRICE</span>$</p>
            SALE
    </section>
    `;
        this.id = IDGen.next().value;
        this.type = number;
        this.name = name;
        this.size = size;
        this.path = path;
        this.color = color;
        this.sale = sale;
        this.startPrice = price;
        this.price = Math.round(price - (price * sale / 100));
        if (sale === 0) {
            this.ViewTemplate = this.ViewTemplate.replace("SALE", "");
        }
        else {
            this.ViewTemplate = this.ViewTemplate.replace("SALE", `<div class="product-sale">${sale} %</div>`);
            this.ViewTemplate = this.ViewTemplate.replace("PRICE", `<span class="product-old-price" style="text-decoration: line-through">${this.startPrice}$</span> <span class="product-new-price">${this.price}</span>`);
        }
    }
    // #endregion
    // #region Props
    get Sale() {
        return this.sale;
    }
    set Sale(value) {
        this.sale = value;
    }
    get Color() {
        return this.color;
    }
    get Path() {
        return this.path;
    }
    set Path(value) {
        this.path = value;
    }
    get ID() {
        return this.id;
    }
    get Type() {
        return StrType.get(this.type);
    }
    get Name() {
        return this.name;
    }
    get Price() {
        return this.price;
    }
    get Size() {
        return this.size;
    }
    //#endregion
    // #region Methods
    ToHTML() {
        return this.ViewTemplate.replace("ID", this.id.toString()).
            replace("IMG", this.path).
            replace("TITLE", this.name).
            replace("SIZE", this.size.toString()).
            replace("COLOR", this.color).
            replace("PRICE", this.price.toString());
    }
}
let products = [
    new Product(Sneakers, "Nike Air Forse", 150, 42, "Черный", "IMG/Кроссовки1.png"),
    new Product(Sneakers, "Addidas 32", 200, 40, "Черный", "IMG/Кроссовки2.jpg", 20),
    new Product(Boots, "Boot Sicker", 50, 45, "Бежевый", "IMG/Ботинки1.jpg"),
    new Product(Sandals, "Sandals", 30, 39, "Коричневый", "IMG/Сандали1.png"),
    new Product(Sneakers, "Nike Morse", 350, 42, "Розовый", "IMG/Кроссовки3.jpg", 30),
    new Product(Sandals, "Sandals Calvin", 530, 41, "Коричневый", "IMG/Сандали2.jpg", 10),
    new Product(Boots, "Boots Mamble", 50, 41, "Черный", "IMG/Ботинки2.jpeg"),
    new Product(Boots, "Military Boot Style", 120, 42, "Черный", "IMG/Ботинки3.jpg"),
    new Product(Sandals, "Cool Sandals", 130, 39, "Голубой", "IMG/Сандали3.png", 50),
];
//#region Ex2
// 2.	Реализуйте итератор для объекта products для доступа к каждому товару
class ProductIterator {
    constructor(products) {
        this.index = 0;
        this.products = products;
    }
    next() {
        if (this.index < this.products.length) {
            return { done: false, value: this.products[this.index++] };
        }
        else {
            return { done: true, value: null };
        }
    }
}
let iterator = new ProductIterator(products);
const Wrapper = document.querySelector(".products");
WriteProds(products);
//#endregion
//#region Ex3
let buttonsType = document.querySelectorAll(".type");
let buttonApplyFiltre = document.querySelector(".ApplyFiltres");
buttonsType = Array.from(buttonsType);
buttonApplyFiltre.onclick = filtration;
//#endregion
function filtration() {
    let SetPrice = filtreByPrice();
    let SetColor = filtreByColor();
    let SetFiltres = new Set();
    console.log(SetColor);
    SetPrice.forEach((value) => {
        if (SetColor.has(value)) {
            SetFiltres.add(value);
        }
    });
    let newProducts = Array.from(SetFiltres);
    WriteProds(newProducts);
}
function filtreByPrice() {
    let inFrom = document.querySelector(".price-from");
    let inBefore = document.querySelector(".price-before");
    let min = Number(inFrom.value);
    let max = Number(inBefore.value == "" ? 100000 : inBefore.value);
    let set = new Set();
    let arr = products.filter((value) => value.Price >= min &&
        value.Price <= max);
    arr.forEach((value) => set.add(value));
    return set;
}
function filtreByColor() {
    let inColor = document.querySelector(".Colors");
    let color = inColor.value;
    if (color === "Все") {
        return new Set(products);
    }
    let set = new Set();
    let arr = products.filter((value) => value.Color.toLowerCase() == color.toLowerCase());
    arr.forEach((value) => set.add(value));
    return set;
}
function WriteProds(products) {
    let iterator = new ProductIterator(products);
    let result = iterator.next();
    Wrapper.innerHTML = "";
    while (!result.done) {
        Wrapper.innerHTML += result.value.ToHTML();
        result = iterator.next();
    }
}
function* idMaker() {
    let index = 0;
    while (true)
        yield index++;
}
