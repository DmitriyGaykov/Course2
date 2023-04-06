import axios from "axios";

/* 
    getDatas — ассихронная функция для получения информации из json файла
    path - имя файла, который находится в папке public/datas
*/

const getDatas = async (path : string) => {
    try {
        path = `http://localhost:3000/datas/${path}`;
        const datas : any = await axios.get(path);
        return datas;
    } catch(e : any) {
        const error = e as Error;
        console.warn(`Error | getDatas() | Не получилось получить данные из файла ${ path } | ${ error.message }}`);
        return null;
    }
}

export default getDatas;