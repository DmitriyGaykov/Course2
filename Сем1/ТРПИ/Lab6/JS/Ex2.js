let buttonAdd = document.querySelector(".Add");
try {
    buttonAdd.onclick = () => {
        let name = prompt("Введите название товара:");
        if (name == null) {
            throw new Error("Вы не ввели название товара!");
        }
        let price = Number(prompt("Введите цену товара:"));
        if (price == null ||
            isFinite(price) == false) {
            throw new Error("Некорректная цена товара!");
        }
        let pathToImg = prompt("Введите путь к изображению товара:");
        if (pathToImg == null) {
            throw new Error("Вы не ввели путь к изображению товара!");
        }
        let product = new Product(name, price, pathToImg);
        product.Wrapper = document.querySelector(".wrapper");
        product.toHTML();
    };
}
catch (error) {
    alert(error.message);
}
