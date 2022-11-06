let buttonAdd : HTMLButtonElement = document.querySelector(".Add");
let buttonRemove : HTMLButtonElement = document.querySelector(".Remove");
let buttonChangeBack : HTMLButtonElement = document.querySelector(".ChangeBack");
let buttonAddReady : HTMLButtonElement = document.querySelector(".AddReady");

let products : Map<number, Product> = new Map<number, Product>();

var buttonsAddToBasket : NodeListOf<HTMLButtonElement> = document.querySelectorAll(".product-btn");

try
{

    buttonAdd.onclick = () =>
    {
        let name : string = prompt("Введите название товара:");

        if (name == null)
        {
            throw new Error("Вы не ввели название товара!");
        }

        let price : number = Number(prompt("Введите цену товара:"));

        if(
            price == null ||
            isFinite(price) == false)
        {
            throw new Error("Некорректная цена товара!");
        }

        let pathToImg : string = prompt("Введите путь к изображению товара:");

        if (pathToImg == null)
        {
            throw new Error("Вы не ввели путь к изображению товара!");
        }

        let product : Product = new Product(name, price, pathToImg);
        
        product.Wrapper = document.querySelector(".products");
        
        products.set(product.ID, product);

        product.toHTML();

        initButtonsAddToBasket();
    };

    buttonRemove.onclick = () =>
    {
        let answer : string;

        answer = prompt("Введите название товара или айди:") ??
                 "default";

        if (answer == "default")
        {
            throw new Error("Вы не ввели название товара или айди!");
        }

        let product : Product = products.get(Number(answer));

        if (product == undefined)
        {
            product = Array.from(products.values()).
                            find(product => product.Name === answer);
        }

        product.Remove();
    };

    buttonChangeBack.onclick = () =>
    {
        let prods : HTMLElement[] = Array.from(document.querySelectorAll(".product"));

        for(let i = 0; i < prods.length; i++)
        {
            if((i + 1) % 2 != 0)
            {
                prods[i].style.backgroundColor = "RGBA(233,233,233,0.6)";
            }
        }
    };

    buttonAddReady.onclick = () =>
    {
        let name : string = "Asus";
        let price : number = 2220;
        let pathToImg : string = "https://fk.by/uploads/images/cache/2022/04/03/noutbuk-asus-x515fa-br037-1100x500.jpeg";

        let product : Product = new Product(name, price, pathToImg);
        
        product.Name += " " + product.ID;

        product.Wrapper = document.querySelector(".products");
        
        products.set(product.ID, product);

        product.toHTML();

        initButtonsAddToBasket();
    }

} catch(error)
{
    alert(error.message);
}

function initButtonsAddToBasket()
{
    buttonsAddToBasket.forEach(button =>
    {
        button.onclick = () =>
        {
            let id : number = Number(button.parentElement.id);
            console.log(id);
            
            let product : Product = products.get(id);

            product.IsInABasket = !product.IsInABasket;

            product.Remove();

            product.Wrapper = product.IsInABasket ?  
                              document.querySelector(".basket") :
                              document.querySelector(".products");

            product.toHTML();

            initButtonsAddToBasket();
        }
    });
}