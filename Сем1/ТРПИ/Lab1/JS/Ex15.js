let Limit = 100;
let EnteredNum;

do {
    EnteredNum = prompt("Введите число от 1 до 100");
} while (!isNum(EnteredNum) || EnteredNum < Limit);

function isNum(Num) {
    let Reg = new RegExp("[0-9]+");
    return Reg.test(Num);
}