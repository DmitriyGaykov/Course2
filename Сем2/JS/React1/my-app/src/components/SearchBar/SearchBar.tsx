import { useContext } from "react";
import { DATAS } from "../../App";
import IDatas from "../../assets/models/IDatas";
import IProduct from "../../assets/models/IProduct";
import ISearchBar from "../../assets/models/ISearchBar";
import startFiltre from "../../assets/scripts/startFiltre";
import "./../../assets/scss/SearchBar.scss"

const SearchBar = ({ text, placeholder } : ISearchBar) => {
    const dataSettings = useContext(DATAS);
    
    return (
        <div className="search-bar">
            <input
            type="text"
            placeholder={ placeholder }
            className="search"
            onChange={() => startFiltre(dataSettings?.products as IProduct[], dataSettings as IDatas)}
            />

            <div className="checkbox-in-stock">
                <input 
                className="in-stock"
                type="checkbox"
                onClick={() => startFiltre(dataSettings?.products as IProduct[], dataSettings as IDatas)}/>

                <span className="text">{ text ?? "No text" }</span>
            </div>
        </div>
        );
}

export default SearchBar;
