import IProduct from "./IProduct";

export default interface ICategory {
    category_name?: string;
    products?: IProduct[];
}