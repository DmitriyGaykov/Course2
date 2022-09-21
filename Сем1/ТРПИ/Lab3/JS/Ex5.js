// 5.	Используя коллекцию Map и ее методы, реализуйте
//  корзину товаров. В корзине хранится информация о 
//  товаре: id, количество товара, цена. Пользователь
//   может добавить/удалить товар из корзины, изменить
//    количество каждого товара. Рассчитайте количество
//     позиций в корзине и сумму заказа.
let buttonsAdd = document.querySelectorAll(".product-add");
let buttonsRemove = document.querySelectorAll(".product-remove");
class Product {
    constructor(name, price) {
        this.count = {
            "shop": 0,
            "basket": 0,
        };
        this.name = name;
        this.price = price;
        this.id = Math.random().toString(36).slice(2);
    }
    get ID() {
        return this.id;
    }
}
class shopWindow {
    constructor() {
        this.products = new Map();
        this.HTMLproducts = document.querySelector(".products");
        this.HTMLProduct = `<div class="product" id="ID-product">
        <div class="product-name">Name-product</div>
        <div class="product-price">Price-product</div>
        <div class="product-count">Count-product</div>
        <button class="product-add">Add</button>
    </div>`;
    }
    addProduct(product) {
        if (this.products.get(product.ID) == undefined) {
            this.products.set(product.ID, product);
        }
        this.countProductsInShop++;
        this.products.get(product.ID).count["shop"]++;
        this.write();
    }
    removeProduct(product) {
        if (this.products.get(product.ID) !== undefined) {
            if (this.products.get(product.ID).count["shop"] === 1) {
                this.products.delete(product.ID);
                product.count["shop"] = 0;
            }
            else {
                this.products.get(product.ID).count["shop"]--;
            }
            this.countProductsInShop--;
            this.write();
        }
    }
    replaceProduct(product, to) {
        if (this.products.get(product.ID) !== undefined) {
            this.removeProduct(product);
            to.addProduct(product);
        }
    }
    write() {
        this.HTMLproducts.innerHTML = "";
        this.products.forEach((value) => {
            this.HTMLproducts.innerHTML += this.HTMLProduct.replace("ID-product", value.ID).
                replace("Name-product", value.name).
                replace("Price-product", String(value.price)).
                replace("Count-product", String(value.count["shop"]));
        });
        initButtons();
    }
}
class basketWindow {
    constructor() {
        this.products = new Map();
        this.HTMLproducts = document.querySelector(".basket-products");
        this.HTMLProduct = `<div class="product" id="ID-product">
        <div class="product-name">Name-product</div>
        <div class="product-price">Price-product</div>
        <div class="product-counts">Count: <span class="count">Count-product</span></div>
        <button class="product-remove">Remove</button>
    </div>`;
        this.countProductsInBasket = 0;
    }
    addProduct(product) {
        if (this.products.get(product.ID) == undefined) {
            this.products.set(product.ID, product);
        }
        this.countProductsInBasket++;
        this.products.get(product.ID).count["basket"]++;
        this.write();
    }
    removeProduct(product) {
        if (this.products.get(product.ID) != undefined) {
            if (this.products.get(product.ID).count["basket"] === 1) {
                this.products.delete(product.ID);
                product.count["basket"] = 0;
            }
            else {
                this.products.get(product.ID).count["basket"]--;
            }
            this.countProductsInBasket--;
            this.write();
        }
    }
    replaceProduct(product, to) {
        if (this.products.get(product.ID) != undefined) {
            this.removeProduct(product);
            to.addProduct(product);
        }
    }
    write() {
        this.HTMLproducts.innerHTML = "";
        let sum = 0;
        this.products.forEach((value) => {
            this.HTMLproducts.innerHTML += this.HTMLProduct.replace("ID-product", value.ID).
                replace("Name-product", value.name).
                replace("Price-product", String(value.price)).
                replace("Count-product", String(value.count["basket"]));
            sum += value.price * value.count["basket"];
        });
        document.querySelector(".basket-sum span").innerHTML = String(sum);
        document.querySelector(".basket-count span").innerHTML = String(this.countProductsInBasket);
        initButtons();
    }
}
let shop = new shopWindow();
let basket = new basketWindow();
let Milk100 = new Product("Молоко", 100);
let Bread50 = new Product("Хлеб", 50);
let Milk200 = new Product("Молоко", 200);
let Potato30 = new Product("Картошка красная", 30);
let Potato40 = new Product("Картошка необычная", 40);
let Pasta = new Product("Макароны", 100);
let Sosiska = new Product("Сосиска", 100);
shop.addProduct(Milk100);
shop.addProduct(Milk100);
shop.addProduct(Milk100);
shop.addProduct(Bread50);
shop.addProduct(Milk200);
shop.addProduct(Potato30);
shop.addProduct(Potato40);
shop.addProduct(Pasta);
shop.addProduct(Pasta);
shop.addProduct(Sosiska);
let isClickedAdd = false;
let isClickedRemove = false;
function initButtons() {
    buttonsAdd = document.querySelectorAll(".product-add");
    buttonsRemove = document.querySelectorAll(".product-remove");
    buttonsAdd.forEach(button => {
        button.onclick = () => {
            if (!isClickedAdd) {
                isClickedAdd = true;
                let id = button.parentElement.id;
                let product = shop.products.get(id);
                shop.replaceProduct(product, basket);
                isClickedAdd = false;
            }
        };
    });
    buttonsRemove.forEach(button => {
        button.onclick = () => {
            if (!isClickedRemove) {
                isClickedRemove = true;
                let id = button.parentElement.id;
                let product = basket.products.get(id);
                basket.replaceProduct(product, shop);
                isClickedRemove = false;
            }
        };
    });
}
