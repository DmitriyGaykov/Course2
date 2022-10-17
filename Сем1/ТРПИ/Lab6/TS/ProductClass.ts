let idMaker = makeID();

class Product
{
    //#region Fields

    private wrapper : HTMLElement = document.querySelector(".wrapper");

    private readonly id: number;
    private name : string;
    private price : number;
    private pathToImg : string;
    private isInABasket : boolean = false;
    private htmlElement : HTMLElement;
    
    //#endregion

    //#region Properties

    public get ID() : number 
    {
        return this.id;
    }

    public get Wrapper() : HTMLElement
    {
        return this.wrapper;
    }

    public set Wrapper(value : HTMLElement)
    {
        this.wrapper = value;
    }

    public get Name() : string
    {
        return this.name;
    }

    public set Name(value : string)
    {
        this.name = value;
    }

    public get Price() : number
    {
        return this.price;
    }

    public set Price(value : number)
    {
        this.price = value;
    }

    public get PathToImg() : string
    {
        return this.pathToImg;
    }

    public set PathToImg(value : string)
    {
        this.pathToImg = value;
    }

    public get IsInABasket() : boolean
    {
        return this.isInABasket;
    }

    //#endregion

    //#region Constructors

    constructor(name: string,
                price: number,
                pathToImg: string)
    {
        this.id = idMaker.next().value;
        this.Name = name;
        this.Price = price;
        this.PathToImg = pathToImg;
        this.Wrapper = document.querySelector(".products");
    }

    //#endregion

    //#region Methods

    public ToString() : string
    {
        return `
            <img class="product-img" src="${this.pathToImg}" alt="${this.Name}">
            <div class="product-name">${this.Name}</div>
            <div class="product-price">$${this.price}</div>
            ${this.IsInABasket ? `<button class="product-btn-in">Remove from basket</button>` : `<button class="product-btn-to">Add to basket</button>`}
        `
    }

    public toHTML() : void
    {
        let product : HTMLElement = document.createElement("div");
        product.classList.add("product");

        product.id = this.id.toString();

        product.innerHTML = this.ToString();

        console.log();

        this.Wrapper.appendChild(product);

        this.htmlElement = product;
    }

    public Remove() : void
    {
        this.Wrapper.removeChild(this.htmlElement);
    }

    //#endregion
}

function* makeID() : Generator<number>
{
    let i : number = 0;
    while(true)
    {
        yield i++;
    }
}