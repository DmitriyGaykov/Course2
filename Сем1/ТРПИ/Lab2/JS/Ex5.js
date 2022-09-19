// 5.	Пользователь вводит данные. Если он ввел число, то преобразуйте его
//  в 16-ричную систему счисления (вывод в верхнем регистре). Если число дробное
// – округлите его до наибольшего, наименьшего и ближайшего целого. Если пользователь 
// ввел текст, то преобразуйте его к верхнему и нижнему регистру.
let datas = prompt("Enter data");
if (isFinite(Number(datas)) && !datas.includes(".")) {
    let number = Number(datas);
    let hexNumber = number.toString(16).toUpperCase();
    alert(`В восьмиричной системе: ${hexNumber}`);
}
else if (isFinite(Number(datas)) && Number(datas) % 1 !== 0) {
    let number = Number(datas);
    alert(`
        Набольшую сторону: ${Math.ceil(number)}\n
        Наименьшую: ${Math.floor(number)}\n
        Ближайшее целое: ${Math.round(number)}\n
    `);
}
else {
    alert(`
        Upper: ${datas.toUpperCase()}\n
        Lower: ${datas.toLowerCase()}\n
    `);
}
