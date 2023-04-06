import React, {useRef, useState} from 'react';
import './assets/scss/App.scss';
import IProduct from './assets/models/IProduct';
import useDatas from './assets/Hooks/useDatas';
import FiltrerableProductTable from './components/FiltrerableTable/FiltrerableProductTable';
import IDatas from './assets/models/IDatas';
import DataSetting from './assets/models/DataSetting';
import fillDatas from './assets/scripts/fillDatas';

export const DATAS = React.createContext<IDatas | null | undefined>(null);

const App = () => {
  const [datas, setDatas] = useState<IProduct[]>();
  const [showed_products, setShowedProducts] = useState<IProduct[] | null | undefined>();

  useDatas<IProduct>("products.json", setDatas, setShowedProducts);

  fillDatas(datas as IProduct[]);

  DataSetting.setShowedProducts = setShowedProducts;
  DataSetting.showed_products = showed_products as IProduct[];
  
  return (
    <div className="App">
      <DATAS.Provider value={ DataSetting }>
          <FiltrerableProductTable />
      </DATAS.Provider>
    </div>
  );
}

export default App;
