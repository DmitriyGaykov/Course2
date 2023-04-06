import { useEffect } from 'react';
import getDatas from "../scripts/getDatas";

const useDatas = <T>(path : string, setDatas : any, setShowedDatas : any) => {
    useEffect(() => {
        getDatas(path).then(datas => {
            if(datas != null) {
                const d = datas.data as T[];
                setDatas(d);
                setShowedDatas(d);
            } else {
                console.warn("Error | useDate | Данные не считались!");
            }
        });
    }, []);
}

export default useDatas