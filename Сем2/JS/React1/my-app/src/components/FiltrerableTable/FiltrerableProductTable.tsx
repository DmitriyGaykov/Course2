import { useContext } from 'react';
import { DATAS } from '../../App';
import '../../assets/scss/FiltrerableTable.scss'
import ProductTable from '../ProductTable/ProductTable';
import SearchBar from "../SearchBar/SearchBar";

const FiltrerableProductTable = () => {
    const text = useContext(DATAS)?.search_bar?.text;
    const placeholder = useContext(DATAS)?.search_bar?.placeholder;

    return (
        <div className="filtre-table">

            <SearchBar 
            text={ text }
            placeholder={ placeholder }/>

            <ProductTable />

        </div>
        );
}

export default FiltrerableProductTable;