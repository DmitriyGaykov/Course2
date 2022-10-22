// 4.	Имеется список товаров. Пользователь
//  может добавить/удалить товар из списка,
//   проверить наличие товара. Определите 
//   количество имеющего товара. Используйте
//    коллекцию Set. 

let products: Set<string> = new Set<string>();

(function menu() : void
{
    let choice: string;
    let isExit: boolean = false;
    do
    {
        choice = 
        prompt(
        `
        1. Добавить товар
        2. Удалить товар
        3. Проверить наличие товара
        4. Посмотреть список товаров
        5. Выход
        `
        );
        switch(choice)
        {
            case "1":
                addProduct(prompt("Введите название товара").toLowerCase().trim());
                break;
            case "2":
                removeProduct(prompt("Введите название товара").toLowerCase().trim());
                break;
            case "3":
                alert(
                    isHere(prompt("Введите название товара").toLowerCase().trim()) ?
                        "Товар есть в наличии" :
                        "Товара нет в наличии"
                      );
                break;
            case "4":
                alert(`Количество товаров в наличии: ${products.size}`);
                break;
            case "5":
                isExit = true;
                break;
            default:
                alert("Неверный ввод");
                break;
        }
    } while(!isExit);
})()

function addProduct(el: string): void {
    products.add(el);
}

function removeProduct(el: string): void {
    products.delete(el);
}

function isHere(el: string): boolean {
    return products.has(el);
}