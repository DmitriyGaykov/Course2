import ICategory from "../../../assets/models/ICategory";
import Title from "../Title/Title";
import ProductRow from "./ProductRow";

const CategoryWithProducts = ({ category_name, products } : ICategory) => {
    return (
        <div className="category">
            <Title text={ category_name }/>

            { products?.map(el => <ProductRow name={ el.name } 
                                              price={ el.price }/>
                                              )}

        </div>
        );
}

export default CategoryWithProducts;