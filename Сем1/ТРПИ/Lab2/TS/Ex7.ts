// 7.	Разработайте геометрический калькулятор для расчета
//  параметров треугольника: площадь, периметр, высота, cos,
//   sin, tg, ctg. Пользователь указывает длину катетов.

class Triagle
{
    kat1 : number;
    kat2 : number;

    constructor(kat1 : number, kat2 : number)
    {
        this.kat1 = kat1;
        this.kat2 = kat2;
    }

    hypotenuse : () => number = () => Number((Math.sqrt(Math.pow(this.kat1, 2) + Math.pow(this.kat2, 2))).toFixed(2));

    perimeter : () => number = () => Number((this.kat1 + this.kat2 + this.hypotenuse()).toFixed(2));

    square : () => number = () => Number(((this.kat1 * this.kat2) / 2).toFixed(2));

    height : () => number = () => Number(((2 * this.square()) / this.kat1).toFixed(2));

    cos : () => number = () => Number((this.kat1 / this.hypotenuse()).toFixed(2));

    sin : () => number = () => Number((this.kat2 / this.hypotenuse()).toFixed(2));

    tg : () => number = () => Number((this.kat2 / this.kat1).toFixed(2));
    
    ctg : () => number = () => Number((this.kat1 / this.kat2).toFixed(2));
}

let checkVal : string;

do{
    checkVal = prompt("Введите длину первого катета?");
} while(!isFinite(Number(checkVal)));

let kat1 : number = Number(checkVal);

do{
    checkVal = prompt("Введите длину второго катета?");
} while(!isFinite(Number(checkVal)));

let kat2 : number = Number(checkVal);

let newTriagle : Triagle = new Triagle(kat1, kat2);

alert
(`
    Катет1: ${kat1}
    Катет2: ${kat2}
    Гипотенуза: ${newTriagle.hypotenuse()}
    Периметр: ${newTriagle.perimeter()}
    Площадь: ${newTriagle.square()}
    Высота: ${newTriagle.height()}
    cos: ${newTriagle.cos()}
    sin: ${newTriagle.sin()}
    tg: ${newTriagle.tg()}
    ctg: ${newTriagle.ctg()}
`);