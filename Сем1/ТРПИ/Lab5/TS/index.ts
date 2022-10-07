
const Sneakers = 0;
const Boots = 1;
const Sandals = 2;

const IDGen = idMaker();
let StrType : Map<number, string> = new Map<number, string>();
StrType.set(Sneakers, "Sneakers");
StrType.set(Boots, "Boots");
StrType.set(Sandals, "Sandals");

let TypeStr : Map<string, number> = new Map<string, number>();
TypeStr.set("Кроссовки", Sneakers);
TypeStr.set("Ботинки", Boots);
TypeStr.set("Сандали", Sandals);

const MAX_COUNT : number = 20;

class Product
{
    // #region Fields

    private readonly id : number;
    private readonly size: number;
    private readonly color: string;
    private readonly type: number;
    private readonly startPrice: number;
    private sale : number = 0;
    private name: string;
    private price: number;
    private path : string;

    private ViewTemplate : string = 
    `
    <section class="product" id="ID">
            <img src="IMG" alt="" class="product-img">
            <h1 class="product-title">TITLE</h1>
            <p class="product-size">Size: <span>SIZE</span></p>
            <p class="product-color">Color: <span>COLOR</span></p>
            <p class="product-price">Цена: <span>PRICE</span>$</p>
            SALE
    </section>
    `;

    // #endregion

    // #region Props

    public get Sale() : number
    {
        return this.sale;
    }

    public set Sale(value : number)
    {
        this.sale = value;
    }

    public get Color() : string
    {
        return this.color;
    }

    public get Path() : string
    {
        return this.path;
    }

    public set Path(value : string) {
        this.path = value;
    }

    public get ID() : number
    {
        return this.id;
    }

    public get Type () : string
    {
        return StrType.get(this.type);
    }

    public get Name() : string
    {
        return this.name;
    }

    public get Price() : number
    {
        return this.price;
    }

    public get Size() : number
    {
        return this.size;
    }

   // #endregion
    
    // #region Ctors

    constructor(number: number,
                name: string,
                price: number,
                size: number,
                color: string,
                path: string,
                sale: number = 0)
    {
        this.id = IDGen.next().value;
        this.type = number;
        this.name = name;
        this.size = size;
        this.path = path;
        this.color = color;
        this.sale = sale;
        this.startPrice = price;
        this.price = Math.round(price - (price * sale / 100));

        if(sale === 0)
        {
            this.ViewTemplate = this.ViewTemplate.replace("SALE", "");
        }
        else
        {
            this.ViewTemplate = this.ViewTemplate.replace("SALE", `<div class="product-sale">${sale} %</div>`);
            this.ViewTemplate = this.ViewTemplate.replace("PRICE", `<span class="product-old-price" style="text-decoration: line-through">${this.startPrice}$</span> <span class="product-new-price">${this.price}</span>`);
        }
    }

    //#endregion

    // #region Methods

    public ToHTML() : string
    {
        return this.ViewTemplate.replace("ID", this.id.toString()).
                                 replace("IMG", this.path).
                                 replace("TITLE", this.name).
                                 replace("SIZE", this.size.toString()).
                                 replace("COLOR", this.color).
                                 replace("PRICE", this.price.toString());
    }

    //#endregion
}
 
let products: Product[] = 
[
    new Product(
         Sneakers,
         "Nike Air Forse",
         150,
         42,
         "Черный",
         "IMG/Кроссовки1.png"),

    new Product(
         Sneakers,
         "Addidas 32",
         200,
         40,
         "Черный",
         "IMG/Кроссовки2.jpg",
         20),

    new Product(
         Boots,
         "Boot Sicker",
         50,
         45,
         "Бежевый",
         "IMG/Ботинки1.jpg"),

    new Product(
         Sandals,
         "Sandals",
         30,
         39,
         "Коричневый",
         "IMG/Сандали1.png"),

    new Product(
         Sneakers,
         "Nike Morse",
         350,
         42,
         "Розовый",
         "IMG/Кроссовки3.jpg",
         30),

    new Product(
         Sandals,
         "Sandals Calvin",
         530,
         41,
         "Коричневый", "IMG/Сандали2.jpg",
         10),

    new Product(
         Boots,
         "Boots Mamble",
         50,
         41,
         "Черный",
         "IMG/Ботинки2.jpeg",
         60),

    new Product(
         Boots,
         "Military Boot Style",
         120,
         42,
         "Черный",
         "IMG/Ботинки3.jpg"),

    new Product(
         Sandals,
         "Cool Sandals",
         130,
         39,
         "Голубой",
         "IMG/Сандали3.png",
         50),
];

//#region Ex2

// 2.	Реализуйте итератор для объекта products для доступа к каждому товару

class ProductIterator implements Iterator<Product>
{
    private index : number = 0;
    private products : Product[];

    constructor(products : Product[])
    {
        this.products = products;
    }

    public next() : IteratorResult<Product>
    {
        if(this.index < this.products.length)
        {
            return {done: false, value: this.products[this.index++]};
        }
        else
        {
            return {done: true, value: null};
        }
    }
}

let iterator = new ProductIterator(products);
const Wrapper : any = document.querySelector(".products");

WriteProds(products);

//#endregion

//#region Ex3

let buttonsType : any = document.querySelectorAll(".type");
let buttonApplyFiltre : any = document.querySelector(".ApplyFiltres");

buttonsType = Array.from(buttonsType);


buttonApplyFiltre.onclick = filtration;

//#endregion

function filtration() : void
{
    let SetPrice : Set<Product> = filtreByPrice();
    let SetColor : Set<Product> = filtreByColor();
    let SetFiltres : Set<Product> = new Set<Product>();

    console.log(SetColor);

    SetPrice.forEach((value) => {
        if(SetColor.has(value))
        {
            SetFiltres.add(value);
        }
    });

    let newProducts : Product[] = Array.from(SetFiltres);
    WriteProds(newProducts);
}

function filtreByPrice() : Set<Product>
{
    let inFrom : any = document.querySelector(".price-from");
    let inBefore : any = document.querySelector(".price-before");

    let min : number = Number(inFrom.value);
    let max : number = Number(inBefore.value == "" ? 100000 : inBefore.value);

    let set : Set<Product> = new Set<Product>();

    let arr: Product[] = products.filter(
        (value) => value.Price >= min &&
                   value.Price <= max
                   );

    arr.forEach((value) => set.add(value));

    return set;
}

function filtreByColor() : Set<Product>
{
    let inColor : HTMLSelectElement = document.querySelector(".Colors");
    let color : string = inColor.value;

    if(color === "Все")
    {
        return new Set<Product>(products);
    }

    let set : Set<Product> = new Set<Product>();

    let arr: Product[] = products.filter(
        (value) => value.Color.toLowerCase() == color.toLowerCase()
                   );

    arr.forEach((value) => set.add(value));

    return set;
}

function WriteProds(products : Product[])
{
    let iterator = new ProductIterator(products);
    let result = iterator.next();
    Wrapper.innerHTML = "";
    while(!result.done)
    {
        Wrapper.innerHTML += result.value.ToHTML();
        result = iterator.next();
    }
}

function* idMaker() : Generator<number> {
    let index: number = 0;
        while(true)
            yield index++;
}