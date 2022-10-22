let idMaker = makeID();
class Product {
    //#region Fields
    wrapper = document.querySelector(".products");
    id;
    name;
    price;
    pathToImg;
    isInABasket = false;
    htmlElement;
    //#endregion
    //#region Properties
    get ID() {
        return this.id;
    }
    get Wrapper() {
        return this.wrapper;
    }
    set Wrapper(value) {
        this.wrapper = value;
    }
    get Name() {
        return this.name;
    }
    set Name(value) {
        this.name = value;
    }
    get Price() {
        return this.price;
    }
    set Price(value) {
        this.price = value;
    }
    get PathToImg() {
        return this.pathToImg;
    }
    set PathToImg(value) {
        this.pathToImg = value;
    }
    get IsInABasket() {
        return this.isInABasket;
    }
    set IsInABasket(value) {
        this.isInABasket = value;
    }
    //#endregion
    //#region Constructors
    constructor(name, price, pathToImg) {
        this.id = idMaker.next().value;
        this.Name = name;
        this.Price = price;
        this.PathToImg = pathToImg;
        this.Wrapper = document.querySelector(".products");
    }
    //#endregion
    //#region Methods
    ToString() {
        return `
            <img class="product-img" src="${this.pathToImg}" alt="${this.Name}">
            <div class="product-name">${this.Name}</div>
            <div class="product-price">$${this.price}</div>
            ${this.IsInABasket ? (new ButtonClass("product-btn-in product-btn", "Вынуть из корзины")).toHTML() : (new ButtonClass("product-btn-to product-btn", "В корзину")).toHTML()}
        `;
    }
    toHTML() {
        let product = document.createElement("div");
        product.classList.add("product");
        product.id = this.id.toString();
        product.innerHTML = this.ToString();
        this.Wrapper.innerHTML += product.outerHTML;
        this.htmlElement = product;
        buttonsAddToBasket = document.querySelectorAll(".product-btn");
    }
    Remove() {
        this.Wrapper.removeChild(document.getElementById(this.id.toString()));
    }
}
function* makeID() {
    let i = 0;
    while (true) {
        yield i++;
    }
}
