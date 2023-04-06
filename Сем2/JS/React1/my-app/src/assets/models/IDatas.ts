import IProduct from "./IProduct";
import ISearchBar from "./ISearchBar";

export default interface IDatas {
    products?: IProduct[];
    showed_products?: IProduct[];
    search_bar?: ISearchBar;
    setShowedProducts?: any;
    
}