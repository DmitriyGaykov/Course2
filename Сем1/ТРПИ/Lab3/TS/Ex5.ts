// 5.	Используя коллекцию Map и ее методы, реализуйте
//  корзину товаров. В корзине хранится информация о 
//  товаре: id, количество товара, цена. Пользователь
//   может добавить/удалить товар из корзины, изменить
//    количество каждого товара. Рассчитайте количество
//     позиций в корзине и сумму заказа.
let buttonsAdd: NodeListOf<HTMLButtonElement> = document.querySelectorAll(".product-add");
let buttonsRemove: NodeListOf<HTMLButtonElement> = document.querySelectorAll(".product-remove");

interface IProduct {
    addProduct(product: Product): void;
    removeProduct(product: Product): void;
    replaceProduct(product: Product, to: shopWindow | basketWindow): void;
}

class Product
{
    private readonly id: string;
    public count: object = 
    {
        "shop": 0,
        "basket": 0,
    };
    public price: number;
    public readonly name: string;

    constructor(name: string, price: number) {
        this.name = name;
        this.price = price;
        this.id = Math.random().toString(36).slice(2);
    }

    public get ID(): string 
    { 
        return this.id; 
    }
}

class shopWindow implements IProduct
{ 
    public products: Map<string, Product> = new Map();
    private readonly HTMLproducts: any = document.querySelector(".products");

    private HTMLProduct: string = 
    `<div class="product" id="ID-product">
        <div class="product-name">Name-product</div>
        <div class="product-price">Price-product</div>
        <div class="product-count">Count-product</div>
        <button class="product-add">Add</button>
    </div>`;

    public countProductsInShop: number;

    constructor() {}

    public addProduct(product: Product): void 
    {
        if (this.products.get(product.ID) == undefined) {
            this.products.set(product.ID, product);
        }
        this.countProductsInShop++;
        this.products.get(product.ID).count["shop"]++;
        this.write();
    }

    public removeProduct(product: Product): void 
    {
        if (this.products.get(product.ID) !== undefined) {
            if(this.products.get(product.ID).count["shop"] === 1)
            {
                this.products.delete(product.ID);
                product.count["shop"] = 0;
            }
            else 
            {
                this.products.get(product.ID).count["shop"]--;
            }
            this.countProductsInShop--;
            
            this.write();
        }
    }

    public replaceProduct(product: Product, to: basketWindow): void 
    {
        if (this.products.get(product.ID) !== undefined) 
        {
            this.removeProduct(product);
            to.addProduct(product);
        }
    }

    private write(): void {
        this.HTMLproducts.innerHTML = "";

        this.products.forEach((value: Product) => {
            this.HTMLproducts.innerHTML += this.HTMLProduct.replace("ID-product", value.ID).
                                                            replace("Name-product", value.name).
                                                            replace("Price-product", String(value.price)).
                                                            replace("Count-product", String(value.count["shop"]));
        });



        initButtons();
    }
}

class basketWindow implements IProduct
{
    public products: Map<string, Product> = new Map();
    private readonly HTMLproducts: any = document.querySelector(".basket-products");

    private HTMLProduct: string = 
    `<div class="product" id="ID-product">
        <div class="product-name">Name-product</div>
        <div class="product-price">Price-product</div>
        <div class="product-counts">Count: <span class="count">Count-product</span></div>
        <button class="product-remove">Remove</button>
    </div>`;

    public countProductsInBasket: number = 0;

    constructor() {}

    public addProduct(product: Product): void {
        if (this.products.get(product.ID) == undefined) {
            this.products.set(product.ID, product);
        }
        
        this.countProductsInBasket++;
        this.products.get(product.ID).count["basket"]++;
        this.write();
    }

    public removeProduct(product: Product): void 
    {
        if (this.products.get(product.ID) != undefined) {
            if(this.products.get(product.ID).count["basket"] === 1)
            {
                this.products.delete(product.ID);
                product.count["basket"] = 0;
            }
            else
            {
                this.products.get(product.ID).count["basket"]--;
            }

            this.countProductsInBasket--;
            
            this.write();
        }
    }

    public replaceProduct(product: Product, to: shopWindow): void 
    {
        if (this.products.get(product.ID) != undefined) 
        {
            this.removeProduct(product);
            to.addProduct(product);
        }
    }

    private write(): void 
    {
        this.HTMLproducts.innerHTML = "";
        let sum : number = 0;
        
        this.products.forEach((value: Product) => {
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

let shop : shopWindow = new shopWindow();
let basket : basketWindow = new basketWindow();

let Milk100 : Product = new Product("Молоко", 100);
let Bread50 : Product = new Product("Хлеб", 50);
let Milk200 : Product = new Product("Молоко", 200);
let Potato30 : Product = new Product("Картошка красная", 30);
let Potato40 : Product = new Product("Картошка необычная", 40);
let Pasta : Product = new Product("Макароны", 100);
let Sosiska : Product = new Product("Сосиска", 100);

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


let isClickedAdd : boolean = false;
let isClickedRemove : boolean = false;
function initButtons()
{
    buttonsAdd = document.querySelectorAll(".product-add");
    buttonsRemove = document.querySelectorAll(".product-remove");

    buttonsAdd.forEach(button => {
        button.onclick = () => {
            if(!isClickedAdd)
            {
                isClickedAdd = true;
                let id : string = button.parentElement.id;
                let product : Product = shop.products.get(id);
                
                shop.replaceProduct(product, basket);
                isClickedAdd = false;
            }
        };
    });

    buttonsRemove.forEach(button => {
        button.onclick = () => {
            if(!isClickedRemove)
            {
                isClickedRemove = true;
                let id : string = button.parentElement.id;
                let product : Product = basket.products.get(id);
                
                basket.replaceProduct(product, shop);
                isClickedRemove = false;
            }
        };
    } );
}
