import Title from "./Title/Title";
import './../../assets/scss/ProductTable.scss';
import devideByCategories from "../../assets/scripts/devideByCategories";
import { useContext, useEffect, useState } from "react";
import IProduct from "../../assets/models/IProduct";
import CategoryWithProducts from "./CategoryWithProducts/CategoryWithProducts";
import ICategory from "../../assets/models/ICategory";
import DataSetting from "../../assets/models/DataSetting";
import { DATAS } from "../../App";
import startFiltre from "../../assets/scripts/startFiltre";
import IDatas from "../../assets/models/IDatas";

const ProductTable = () => {
    const dataSettings = useContext(DATAS);

    const [products, setProducts] = useState<IProduct[] | null | undefined>();
    const [categories, setCategs] = useState<ICategory[] | null | undefined>();
    
    useEffect(() => {
        setProducts(dataSettings?.showed_products);
        setCategs(devideByCategories(products as IProduct[]));
    }, [dataSettings?.showed_products, categories]);

    return (
        <div className="product-table">
            <div className="titles">
                <Title text="Name" />
                <Title text="Price" />
            </div>

            {
                categories?.map(cat => <CategoryWithProducts 
                                       category_name={ cat.category_name }
                                       products={ cat.products }/>) 
            }
        </div>
        );
}

export default ProductTable;