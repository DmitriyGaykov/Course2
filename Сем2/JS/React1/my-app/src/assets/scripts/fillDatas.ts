import DataSetting from "../models/DataSetting";
import IProduct from "../models/IProduct";

const fillDatas = (datas : IProduct[]) => {
    DataSetting.showed_products = DataSetting.products = datas;
    DataSetting.search_bar = {};
    DataSetting.search_bar.placeholder = "Search...";
    DataSetting.search_bar.text = "Only show products in stock";
}

export default fillDatas;