let idMaker = makeID();
class Product {
    //#endregion
    //#region Constructors
    constructor(name, price, pathToImg) {
        //#region Fields
        this.wrapper = document.querySelector(".wrapper");
        this.isInABasket = false;
        this.id = idMaker.next().value;
        this.Name = name;
        this.Price = price;
        this.PathToImg = pathToImg;
        this.Wrapper = document.querySelector(".products");
    }
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
    //#endregion
    //#region Methods
    ToString() {
        return `
            <img class="product-img" src="${this.pathToImg}" alt="${this.Name}">
            <div class="product-name">${this.Name}</div>
            <div class="product-price">$${this.price}</div>
            ${this.IsInABasket ? `<button class="product-btn-in">Remove from basket</button>` : `<button class="product-btn-to">Add to basket</button>`}
        `;
    }
    toHTML() {
        let product = document.createElement("div");
        product.classList.add("product");
        product.id = this.id.toString();
        product.innerHTML = this.ToString();
        console.log();
        this.Wrapper.appendChild(product);
        this.htmlElement = product;
    }
    Remove() {
        this.Wrapper.removeChild(this.htmlElement);
    }
}
function* makeID() {
    let i = 0;
    while (true) {
        yield i++;
    }
}
