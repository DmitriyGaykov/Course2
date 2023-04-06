import IDatas from "../models/IDatas";
import IProduct from "../models/IProduct";

const startFiltre = (prods : IProduct[], dataSettings : IDatas) => {
    const search = document.getElementsByClassName('search')[0] as HTMLInputElement;
    const in_stock = document.getElementsByClassName('in-stock')[0] as HTMLInputElement;

    const setSearch = prods.filter(el => el.name?.toLowerCase().includes(search.value.toLocaleLowerCase()));
    let setInStock = new Set(prods.filter(el => el.stocked === in_stock.checked && el.stocked));

    if(!in_stock.checked) {
        setInStock = new Set(dataSettings.products);
    }

    const res = setSearch?.filter(el => setInStock.has(el));
    console.log(res)
    dataSettings.setShowedProducts(res as IProduct[]);
}

export default startFiltre;