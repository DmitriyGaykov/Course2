import IProductRow from "../../../assets/models/IProductRow";

const ProductRow = ({ name, price } : IProductRow) => {
    return (
        <div className="product-row">
            <span>{ name }</span>
            <span>{ price }</span>
        </div>
        );
}

export default ProductRow;