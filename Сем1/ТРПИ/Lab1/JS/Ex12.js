let Num1 = EnterNum("A");
let Num2 = EnterNum("B");
let Sum = Num1 + Num2;
alert(`Сумма чисел ${Num1} и ${Num2} равна ${Sum}`);

function EnterNum(N) {
    let Num;
    let isNum = false;
    let Reg = new RegExp("[0-9]+");

    do {
        Num = prompt(`Введите число ${N}:`);

        if (Reg.test(Num)) {
            isNum = true;
        }
    } while (!isNum);

    return Number(Num);
}